using System;
using System.Data;
using ZedGraph;

// IPGPhor2Reader, a tool to read IPGPhor2 log files and plot graphs
// Copyright (C) 2006 Jean-Etienne Poirrier
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// 
// For any further information, please contact me at jepoirrier@gmail.com
// Latest version of this software is at: http://www.poirrier.be/~jean-etienne/software/ipgphor2reader

namespace IPGphor2reader
{
	/// <summary>
	/// Summary description for IPGPhorData.
	/// </summary>
	public class IPGPhorData
	{
		/* My variables */
		private int location;
		private bool finished; // Becomes true if a string ends with "***"
		private bool paused; // To protect parsing of string marked with "Paused"
		
		/* to split string to build the steps table (at least) */
		//private string delimStr = "  ";
		private char[] delimiter = " ".ToCharArray(); // used for the step table and data
		private char[] delimiter2 = ":".ToCharArray(); // used for the time in data
		private string[] split = null; // default split strings
		private string[] split2 = null; // split strings for time in data

		private string logSerial;
		private string logVersion;
		private string logProtocol;
		private string logStrips; // We should have used an integer
		private string logRehydratation;
		private string logIEF;

		/* variables to build the steps table */
		private DataTable myTable;
		private DataColumn colItem1; // step number (int ; cut the S in the beginning)
		private DataColumn colItem2; // type of step (snh / gradient ; string)
		private DataColumn colItem3; // voltage (int ; cut the final V)
		private DataColumn colItem4; // duration (string)
		private DataRow NewRow;
		private DataView myView;

		/* variables to collect data for the graph */
		private PointPairList listVoltage;
		private PointPairList listAmperage;
		private PointPairList listVhrs;

		public IPGPhorData()
		{
			location = 0;
			finished = false;
			paused = false;

			logSerial = "(not set/found)";
			logVersion = "(not set/found)";
			logProtocol = "(not set/found)";
			logStrips = "(not set/found)";
			logRehydratation = "(not set/found)";
			logIEF = "(not set/found)";

			/* Initialise the data for the steps table */
			myTable = new DataTable("myTable");
			colItem1 = new DataColumn("Step",Type.GetType("System.Int32"));
			colItem2 = new DataColumn("Type",Type.GetType("System.String"));
			colItem3 = new DataColumn("Voltage (V)",Type.GetType("System.Int32"));
			colItem4 = new DataColumn("Duration (hh:mm)",Type.GetType("System.String"));
			myTable.Columns.Add(colItem1);
			myTable.Columns.Add(colItem2);
			myTable.Columns.Add(colItem3);
			myTable.Columns.Add(colItem4);
			myView = null;

			/* Initialise the list/data for the graph */
			listVoltage = new PointPairList();
			listAmperage = new PointPairList();
			listVhrs = new PointPairList();

		} // end of constructor logic

		private void buildStepTable(string s)
		{
			split = s.Split(delimiter);

			int inewrow = 0; // iterator for newrow

			NewRow = myTable.NewRow();
			for(int i = 0; i < split.Length; i++)
			{
				if(!split[i].Equals(""))
				{
					switch(inewrow)
					{
						case 0:
							NewRow[inewrow] = Convert.ToInt32(split[i].Substring(1,1)); // Step
							break;
						case 1:
							NewRow[inewrow] = split[i]; // Type
							break;
						case 2:
							NewRow[inewrow] = Convert.ToInt32(split[i].Substring(0,(split[i].Length)-1)); // Voltage
							break;
						case 3:
							NewRow[inewrow] = split[(split.Length)-1]; // Duration
							break;
					}
					inewrow++;
				}
			}

			myTable.Rows.Add(NewRow);
		} // end of buildStepTable()

		private void parsedata(string s)
		{
			bool tmp1 = s.StartsWith("Step");
			int tmp2 = s.IndexOf("Lid opened at");

			if((s.IndexOf("Lid opened at") == -1) & (!s.StartsWith("Step")))
			{
				int item = 0; // iterator for the number of items
				double hour = 0.0;
				double voltage = 0.0;
				double amperes = 0.0;
				double vhrs = 0;

				split = s.Split(delimiter);

				if(s.EndsWith("***"))
					finished = true;

				for(int i = 0; i < split.Length; i++)
				{
					if(!split[i].Equals("") && !finished && !s.EndsWith("***"))
					{
						switch(item)
						{
							case 0: // Time
								split2 = split[i].Split(delimiter2);
								if(split2.Length == 2)
									hour = Convert.ToDouble(split2[item]) + Convert.ToDouble(split2[split2.Length-1])*100/6000;
								else
									hour = 0.0;
								break;
							case 1: // ->
								// Do Nothing
								break;
							case 2: // Voltage
								if(split[i].StartsWith("Paused"))
									paused = true;
								if(!paused)
								{
									voltage = Convert.ToDouble(split[i].Substring(0, split[i].Length-1));
									listVoltage.Add(hour, voltage);
								}
								break;
							case 3: // at
								// Do Nothing
								break;
							case 4: // Amperes
								if(!paused)
								{
									amperes = Convert.ToDouble(split[i].Substring(0, split[i].Length-2));
									listAmperage.Add(hour, amperes);
								}
								break;
							case 5: // Vhrs
								if(!paused)
								{
									vhrs = Convert.ToDouble(split[i].Substring(0, split[i].Length-4));
									listVhrs.Add(hour, vhrs);
								}
								break;
							default:
								paused = false;
								break;
						}
						item++;
					}
				}
			}
		} // end of parsedata()

		private void parseheader(string s)
		{
			if(s.StartsWith("Protocol: "))
				setProtocol(s.Substring(10));
			if(s.StartsWith("No. of strips: "))
				setStrips(s.Substring(15));
			if(s.StartsWith("Rehydraton:"))
				setRehydratation(s.Substring(11));
			if(s.StartsWith("IEF Params: "))
				setIEF(s.Substring(11));
			if(s.StartsWith("S"))
				buildStepTable(s);
		} // end of parseheader()

		private void parsepreamble(string s) // preamble is the first block of text
		{
			if(s.StartsWith("Version "))
				setVersion(s.Substring(8));
			if(s.StartsWith("Serial No. "))
				setSerial(s.Substring(11));

		} // end of parsepreamble()

		public void parseString(string s)
		{
			/* Receives strings from the StreamReader */

			if(s.Length <= 3)
				location++;
			else
			{
				switch(location)
				{
					case 0:          // beginning
						parsepreamble(s);
						break;
					case 1:          // after 1 blank line
						parseheader(s);
						break;
					case 2:          // after 2nd blank line, tells to build the steps table
						myView = new DataView(myTable);
						break;
					case 3:
						if(s.EndsWith("***"))
							finished = true;
						if(!finished)
                            parsedata(s);
						break;
				}
			}
		} // end of parseString()

		/* ACCESSORS */

		public string getIEF()
		{
			return logIEF;
		}

		public string getProtocol()
		{
			return logProtocol;
		}

		public string getRehydratation()
		{
			return logRehydratation;
		}

		public string getSerial()
		{
			return logSerial;
		}

		public string getStrips()
		{
			return logStrips;
		}

		public string getVersion()
		{
			return logVersion;
		}

		
		/* DEFINORS ;-) */

		private void setIEF(string s)
		{
			logIEF = s;
		}

		private void setProtocol(string s)
		{
			logProtocol = s;
		}

		private void setRehydratation(string s)
		{
			logRehydratation = s;
		}

		private void setSerial(string s)
		{
			logSerial = s.Trim();
		}

		private void setStrips(string s)
		{
			logStrips = s;
		}

		private void setVersion(string s)
		{
			logVersion = s;
		}

		/* FOR STEPS TABLE */

		public bool isTableReady()
		{
			if(location == 2)
				return true;
			else
				return false;
		}

		public DataView getView()
		{
			/* Please check isTableReady() before calling this function */
			myView = new DataView(myTable);
			myView.AllowDelete = false;
			myView.AllowEdit = false;
			myView.AllowNew = false;
			return myView;
		}

		/* TO BUILD THE GRAPH */

		public bool isFinished()
		{
			return finished;
		}

		public PointPairList getListAmperage()
		{
			return listAmperage;
		}

		public PointPairList getListVhrs()
		{
			return listVhrs;
		}

		public PointPairList getListVoltage()
		{
			return listVoltage;
		}

	} // end of class definition
}
