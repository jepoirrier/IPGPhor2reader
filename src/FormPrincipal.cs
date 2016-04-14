using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
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
	/// Summary description for Form1.
	/// </summary>
	public class FormPrincipal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MainMenu menuPrincipal;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItemSaveChart;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemHelpMain;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblSerial;
		private System.Windows.Forms.Label lblProtocol;
		private System.Windows.Forms.Label lblTitleGenInfo;
		private System.Windows.Forms.Label lblRehydratation;
		private System.Windows.Forms.Label lblTitleProtocol;
		private System.Windows.Forms.Label lblIEF;
		private System.Windows.Forms.DataGrid dgSteps;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ZedGraph.ZedGraphControl zedGraphControl1;
		private System.Windows.Forms.Label lblStrips;
		private System.Windows.Forms.MenuItem menuItemCopy;

		/* Not smart but it's late and I want to go to sleep 
		 * This hack solves the problem of the 3rd Yaxis that become a 4th one when the second log file is opened */
		private bool firsttime;

		public FormPrincipal()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			Text = "IPGphor2 Reader";
			statusBar.Text = "Welcome to IPGphor 2 Reader - (c) Jean-Etienne Poirrier (CNCM, ULg), 2006";
			menuItemSaveChart.Enabled = false;
			firsttime = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormPrincipal));
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.panelTop = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblStrips = new System.Windows.Forms.Label();
			this.dgSteps = new System.Windows.Forms.DataGrid();
			this.lblIEF = new System.Windows.Forms.Label();
			this.lblTitleProtocol = new System.Windows.Forms.Label();
			this.lblRehydratation = new System.Windows.Forms.Label();
			this.lblTitleGenInfo = new System.Windows.Forms.Label();
			this.lblProtocol = new System.Windows.Forms.Label();
			this.lblSerial = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.menuPrincipal = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItemSaveChart = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemEdit = new System.Windows.Forms.MenuItem();
			this.menuItemCopy = new System.Windows.Forms.MenuItem();
			this.menuItemHelpMain = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemAbout = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.panelTop.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSteps)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 507);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(704, 22);
			this.statusBar.TabIndex = 0;
			this.statusBar.Text = "statusBar";
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.zedGraphControl1);
			this.panelTop.Controls.Add(this.panel1);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(704, 507);
			this.panelTop.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblStrips);
			this.panel1.Controls.Add(this.dgSteps);
			this.panel1.Controls.Add(this.lblIEF);
			this.panel1.Controls.Add(this.lblTitleProtocol);
			this.panel1.Controls.Add(this.lblRehydratation);
			this.panel1.Controls.Add(this.lblTitleGenInfo);
			this.panel1.Controls.Add(this.lblProtocol);
			this.panel1.Controls.Add(this.lblSerial);
			this.panel1.Controls.Add(this.lblVersion);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(704, 136);
			this.panel1.TabIndex = 0;
			// 
			// lblStrips
			// 
			this.lblStrips.Location = new System.Drawing.Point(7, 104);
			this.lblStrips.Name = "lblStrips";
			this.lblStrips.Size = new System.Drawing.Size(185, 23);
			this.lblStrips.TabIndex = 10;
			this.lblStrips.Text = "No of strips: ";
			this.lblStrips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgSteps
			// 
			this.dgSteps.AllowSorting = false;
			this.dgSteps.CaptionText = "Steps:";
			this.dgSteps.DataMember = "";
			this.dgSteps.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSteps.Location = new System.Drawing.Point(392, 8);
			this.dgSteps.Name = "dgSteps";
			this.dgSteps.ReadOnly = true;
			this.dgSteps.RowHeadersVisible = false;
			this.dgSteps.Size = new System.Drawing.Size(304, 120);
			this.dgSteps.TabIndex = 9;
			// 
			// lblIEF
			// 
			this.lblIEF.Location = new System.Drawing.Point(200, 56);
			this.lblIEF.Name = "lblIEF";
			this.lblIEF.Size = new System.Drawing.Size(185, 23);
			this.lblIEF.TabIndex = 7;
			this.lblIEF.Text = "IEF:";
			this.lblIEF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTitleProtocol
			// 
			this.lblTitleProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitleProtocol.Location = new System.Drawing.Point(200, 8);
			this.lblTitleProtocol.Name = "lblTitleProtocol";
			this.lblTitleProtocol.Size = new System.Drawing.Size(184, 23);
			this.lblTitleProtocol.TabIndex = 6;
			this.lblTitleProtocol.Text = "Protocol";
			this.lblTitleProtocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRehydratation
			// 
			this.lblRehydratation.Location = new System.Drawing.Point(200, 32);
			this.lblRehydratation.Name = "lblRehydratation";
			this.lblRehydratation.Size = new System.Drawing.Size(184, 23);
			this.lblRehydratation.TabIndex = 5;
			this.lblRehydratation.Text = "Rehydratation:";
			this.lblRehydratation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTitleGenInfo
			// 
			this.lblTitleGenInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitleGenInfo.Location = new System.Drawing.Point(8, 8);
			this.lblTitleGenInfo.Name = "lblTitleGenInfo";
			this.lblTitleGenInfo.Size = new System.Drawing.Size(184, 23);
			this.lblTitleGenInfo.TabIndex = 3;
			this.lblTitleGenInfo.Text = "General Information";
			this.lblTitleGenInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblProtocol
			// 
			this.lblProtocol.Location = new System.Drawing.Point(8, 80);
			this.lblProtocol.Name = "lblProtocol";
			this.lblProtocol.Size = new System.Drawing.Size(184, 23);
			this.lblProtocol.TabIndex = 2;
			this.lblProtocol.Text = "Protocol: ";
			this.lblProtocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSerial
			// 
			this.lblSerial.Location = new System.Drawing.Point(8, 56);
			this.lblSerial.Name = "lblSerial";
			this.lblSerial.Size = new System.Drawing.Size(184, 23);
			this.lblSerial.TabIndex = 1;
			this.lblSerial.Text = "Serial: ";
			this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(8, 32);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(184, 23);
			this.lblVersion.TabIndex = 0;
			this.lblVersion.Text = "Version: ";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// menuPrincipal
			// 
			this.menuPrincipal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItemFile,
																						  this.menuItemEdit,
																						  this.menuItemHelpMain});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemOpen,
																						 this.menuItem3,
																						 this.menuItemSaveChart,
																						 this.menuItem5,
																						 this.menuItemExit});
			this.menuItemFile.Text = "&File";
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 0;
			this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItemOpen.Text = "&Open";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuItemSaveChart
			// 
			this.menuItemSaveChart.Index = 2;
			this.menuItemSaveChart.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItemSaveChart.Text = "&Save chart";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 4;
			this.menuItemExit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItemEdit
			// 
			this.menuItemEdit.Index = 1;
			this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemCopy});
			this.menuItemEdit.Text = "&Edit";
			// 
			// menuItemCopy
			// 
			this.menuItemCopy.Enabled = false;
			this.menuItemCopy.Index = 0;
			this.menuItemCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuItemCopy.Text = "&Copy chart";
			this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
			// 
			// menuItemHelpMain
			// 
			this.menuItemHelpMain.Index = 2;
			this.menuItemHelpMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuItemHelp,
																							 this.menuItem2,
																							 this.menuItemAbout});
			this.menuItemHelpMain.Text = "&Help";
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Enabled = false;
			this.menuItemHelp.Index = 0;
			this.menuItemHelp.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuItemHelp.Text = "&Help";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Index = 2;
			this.menuItemAbout.Text = "&About IPGphor 2 reader ...";
			this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraphControl1.IsAutoScrollRange = false;
			this.zedGraphControl1.IsEnableHPan = true;
			this.zedGraphControl1.IsEnableHZoom = true;
			this.zedGraphControl1.IsEnableVPan = true;
			this.zedGraphControl1.IsEnableVZoom = true;
			this.zedGraphControl1.IsPrintFillPage = true;
			this.zedGraphControl1.IsPrintKeepAspectRatio = true;
			this.zedGraphControl1.IsScrollY2 = false;
			this.zedGraphControl1.IsShowContextMenu = true;
			this.zedGraphControl1.IsShowCopyMessage = true;
			this.zedGraphControl1.IsShowCursorValues = false;
			this.zedGraphControl1.IsShowHScrollBar = false;
			this.zedGraphControl1.IsShowPointValues = false;
			this.zedGraphControl1.IsShowVScrollBar = false;
			this.zedGraphControl1.IsZoomOnMouseCenter = false;
			this.zedGraphControl1.Location = new System.Drawing.Point(0, 136);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
			this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.PointDateFormat = "g";
			this.zedGraphControl1.PointValueFormat = "G";
			this.zedGraphControl1.ScrollMaxX = 0;
			this.zedGraphControl1.ScrollMaxY = 0;
			this.zedGraphControl1.ScrollMaxY2 = 0;
			this.zedGraphControl1.ScrollMinX = 0;
			this.zedGraphControl1.ScrollMinY = 0;
			this.zedGraphControl1.ScrollMinY2 = 0;
			this.zedGraphControl1.Size = new System.Drawing.Size(704, 371);
			this.zedGraphControl1.TabIndex = 1;
			this.zedGraphControl1.Visible = false;
			this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
			this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.ZoomStepFraction = 0.1;
			// 
			// FormPrincipal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 529);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.menuPrincipal;
			this.Name = "FormPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormPrincipal";
			this.panelTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSteps)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormPrincipal());
		}

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			StreamReader txtfile;
			IPGPhorData id = new IPGPhorData();

			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "log files (*.txt)|*.txt|log files (*.dat)|*.dat|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 1 ;
			openFileDialog.RestoreDirectory = true ;

			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if((txtfile = new StreamReader(openFileDialog.FileName))!=null)
				{
					int counter = 0; // to count the number of lines read
					string line;

					// Some variables to split strings and change window title
					string delimStrF = "\\";
					char [] delimiterF = delimStrF.ToCharArray();
					string [] split = null;

					split = openFileDialog.FileName.Split(delimiterF);

					/* Test to see if it's an IPGPhor2 file */

					if((line = txtfile.ReadLine()) != null)
					{
						if(line.Equals("Amersham Biosciences"))
						{
							statusBar.Text = "IPGPhor2 Reader opened file: " + split[split.Length-1];
							counter++;
						}
						else
						{
							statusBar.Text = "Wrong IPGPhor2 log file! Please choose another IPGPhor log file";
							MessageBox.Show("This file doesn't seem to be an IPGPhor2 data file:\n" + split[split.Length-1],
								"Error loading file",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
						}
					}

					/* Processing of the file */

					if(counter > 0)
					{
						while((line = txtfile.ReadLine()) != null)
						{
							counter++;
							id.parseString(line);
							if(id.isTableReady())
							{
								dgSteps.SetDataBinding(id.getView(), "");
							}
							//
						}
					} // end of test if we have at least one line (main processing of file)

					txtfile.Close();

				} // end of test filename not null
			} // end of test result of DialogBox Open File

			setData(id);

			CreateGraph(zedGraphControl1, id);
			zedGraphControl1.Refresh();

		} // end of function menuItemOpen_Click()

		private void setData(IPGPhorData id)
		{
			/* external function to set all the data in the GUI */

			lblVersion.Text = "Version: " + id.getVersion();
			lblSerial.Text = "Serial: " + id.getSerial();
			lblProtocol.Text = "Protocol: " + id.getProtocol();
			lblStrips.Text = "No of strips: " + id.getStrips();
			lblRehydratation.Text = "Rehydratation: " + id.getRehydratation();
			lblIEF.Text = "IEF: " + id.getIEF();
		} // end of function setData()

		private void CreateGraph(ZedGraphControl zg1, IPGPhorData id)
		{
			// get a reference to the GraphPane
			GraphPane myPane = zg1.GraphPane;
			myPane.CurveList.Clear();
			zg1.Visible = true;

			// Make up some data arrays based on the Sine function
			PointPairList listVoltage = new PointPairList();
			PointPairList listAmperage = new PointPairList();
			PointPairList listVhrs = new PointPairList();

			// Set the Titles
			myPane.Title = "Run for " + id.getStrips() + " strips with protocol: " + id.getProtocol();
			myPane.XAxis.Title = "Time (hours)";
			myPane.YAxis.Title = "Voltage (V)";
			myPane.Y2Axis.Title = "Amperage (µA)";
			myPane.XAxis.IsShowGrid = true;

			// Set data
			listVoltage = id.getListVoltage();
			listAmperage = id.getListAmperage();
			listVhrs = id.getListVhrs();

			// Generate curves, symbols, and legends
			LineItem myCurve = myPane.AddCurve("Voltage (V)", listVoltage, Color.Red, SymbolType.None);
			myCurve = myPane.AddCurve("Amperage (µA)", listAmperage, Color.Green, SymbolType.None);
			myCurve.IsY2Axis = true;
			//myCurve = myPane.AddCurve("Total (Vhrs)", listVhrs, Color.Blue, SymbolType.None);

			myPane.YAxis.IsVisible = true;
			// Make the Y axis scale blue
			myPane.YAxis.ScaleFontSpec.FontColor = Color.Red;
			myPane.YAxis.TitleFontSpec.FontColor = Color.Red;
			// turn off the opposite tics so the Y tics don't show up on the Y axis
			myPane.YAxis.IsOppositeTic = false;
			myPane.YAxis.IsMinorOppositeTic = false;
			// Display the Y axis grid lines
			myPane.YAxis.IsShowGrid = false;
			// Align the Y2 axis labels so they are flush to the axis
			myPane.YAxis.ScaleAlign = AlignP.Inside;

			myPane.Y2Axis.IsVisible = true;
			// Make the Y2 axis scale blue
			myPane.Y2Axis.ScaleFontSpec.FontColor = Color.Green;
			myPane.Y2Axis.TitleFontSpec.FontColor = Color.Green;
			// turn off the opposite tics so the Y2 tics don't show up on the Y axis
			myPane.Y2Axis.IsOppositeTic = false;
			myPane.Y2Axis.IsMinorOppositeTic = false;
			// Display the Y2 axis grid lines
			myPane.Y2Axis.IsShowGrid = true;
			// Align the Y2 axis labels so they are flush to the axis
			myPane.Y2Axis.ScaleAlign = AlignP.Inside;

			if(firsttime)
			{
				// Create a second Y Axis, green
				YAxis yAxis3 = new YAxis("Total (Vhrs)");
				myPane.YAxisList.Add(yAxis3);
				yAxis3.ScaleFontSpec.FontColor = Color.Blue;
				yAxis3.TitleFontSpec.FontColor = Color.Blue;
				yAxis3.Color = Color.Blue;
				// turn off the opposite tics so the Y2 tics don't show up on the Y axis
				yAxis3.IsInsideTic = false;
				yAxis3.IsMinorInsideTic = false;
				yAxis3.IsOppositeTic = false;
				yAxis3.IsMinorOppositeTic = false;
				// Align the Y2 axis labels so they are flush to the axis
				yAxis3.ScaleAlign = AlignP.Inside;
			}

			firsttime = false;

			myCurve = myPane.AddCurve("Total (Vhrs)", listVhrs, Color.Blue, SymbolType.None);
			myCurve.YAxisIndex = 1;

			// Tell ZedGraph to refigure the axes since the data have changed
			zg1.AxisChange();
			menuItemCopy.Enabled = true;
		}

		private void menuItemCopy_Click(object sender, System.EventArgs e)
		{ 
			Clipboard.SetDataObject(zedGraphControl1.GraphPane.Image, true);
		}

		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout hellomyself = new FormAbout();
			hellomyself.ShowDialog();
			hellomyself.Dispose();
		}
	}
}
