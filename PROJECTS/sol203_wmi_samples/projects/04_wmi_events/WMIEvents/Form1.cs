using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;

namespace WMIEvents
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(19, 29);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(243, 204);
			this.textBox1.TabIndex = 0;
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.textBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		ManagementEventWatcher watcher = null;
		private void Form1_Load(object sender, EventArgs e)
		{
			// Create event query to be notified within 1 second of 
        // a new process being created
        WqlEventQuery query = 
            new WqlEventQuery("__InstanceCreationEvent", 
            new TimeSpan(0,0,1), 
            "TargetInstance isa \"Win32_Process\"");

        // Initialize an event watcher and subscribe to events 
        // that match this query
        watcher =
            new ManagementEventWatcher(query);
      
		watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
		watcher.Start();



		}

		void watcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			
        //Display information from the event
        textBox1.Text += String.Format(
            "\n\nProcess {0} has been created, path is: {1}", 
            ((ManagementBaseObject)e.NewEvent
                ["TargetInstance"])["Name"],
            ((ManagementBaseObject)e.NewEvent
                ["TargetInstance"])["ExecutablePath"]);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			watcher.Stop();
		}
	}
}
