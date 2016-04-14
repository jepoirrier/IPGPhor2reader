using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


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
	/// Summary description for FormAbout.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.LinkLabel linkToWebsite;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAbout));
			this.linkToWebsite = new System.Windows.Forms.LinkLabel();
			this.buttonClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// linkToWebsite
			// 
			this.linkToWebsite.Location = new System.Drawing.Point(48, 240);
			this.linkToWebsite.Name = "linkToWebsite";
			this.linkToWebsite.Size = new System.Drawing.Size(312, 23);
			this.linkToWebsite.TabIndex = 0;
			this.linkToWebsite.TabStop = true;
			this.linkToWebsite.Text = "http://www.poirrier.be/~jean-etienne/software/ipgphor2reader";
			this.linkToWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToWebsite_LinkClicked);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(280, 336);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "&Close";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "IPGPhor 2 Reader is a tool to read IPGPhor 2 log files and plot graphs.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 80);
			this.label2.TabIndex = 4;
			this.label2.Text = @"IPGPhor is a device from GE Healthcare (formerly Amersham Biosciences) that performs an isoelectrofocusing of proteins. Version 2 of IPGPhor allows the connection of the device to any computer via a serial cable. GE Healthcare provides a monitoring software but no post-hoc analysis software. This gap is efficiently filled by IPGPhor2Reader.";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 120);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(312, 56);
			this.label3.TabIndex = 6;
			this.label3.Text = "This software is written by Jean-Etienne Poirrier, Ph.D. student at the Centre fo" +
				"r Cellular and Molecular Neurosciences (University of Liege, Belgium). You can f" +
				"ind more information about the Centre at:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(48, 176);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(152, 23);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.cncm.ulg.ac.be/";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(48, 208);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(312, 32);
			this.label4.TabIndex = 8;
			this.label4.Text = "You can find the latest version of this software and a short manual at:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(48, 272);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(312, 56);
			this.label5.TabIndex = 9;
			this.label5.Text = "IPGPhor 2 Reader is written in C#. Its code is licenced under the GNU General Pub" +
				"lic Licence. It uses the ZedGraph library to plot graphs. IPGPhor is a trademark" +
				" of GE Healthcare.";
			// 
			// FormAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 367);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.linkToWebsite);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About IPGPhor 2 Reader ...";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			string target = e.Link.LinkData as string;
			System.Diagnostics.Process.Start("IExplore", "www.cncm.ulg.ac.be");
		}

		private void linkToWebsite_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			string target = e.Link.LinkData as string;
			System.Diagnostics.Process.Start("IExplore", "www.poirrier.be/~jean-etienne/software/ipgphor2reader");
		}
	}
}
