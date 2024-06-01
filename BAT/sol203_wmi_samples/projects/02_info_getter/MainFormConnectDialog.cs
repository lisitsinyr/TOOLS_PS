using System;
using System.Drawing;
using System.Management;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WMI.NET
{
	/// <summary>
	/// Summary description for MainFormConnectDialog.
	/// </summary>
	public class MainFormConnectDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox computer;
		private System.Windows.Forms.TextBox domain;
		private System.Windows.Forms.TextBox user;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;

		public System.Management.ManagementScope resultScope;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTip1;

		public const string ntlmDomain = "NTLMDOMAIN:";

		public MainFormConnectDialog()
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
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.computer = new System.Windows.Forms.TextBox();
			this.domain = new System.Windows.Forms.TextBox();
			this.user = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Remote computer name/ip";
			this.toolTip1.SetToolTip(this.label1, "Local computer can be accesed as \".\"");
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "User domain";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "User name";
			this.toolTip1.SetToolTip(this.label3, "(can be in the form DOMAIN\\user)");
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "User Password";
			// 
			// computer
			// 
			this.computer.Location = new System.Drawing.Point(280, 32);
			this.computer.Name = "computer";
			this.computer.Size = new System.Drawing.Size(128, 20);
			this.computer.TabIndex = 1;
			this.computer.Text = "";
			this.toolTip1.SetToolTip(this.computer, "Local computer can be accesed as \".\"");
			// 
			// domain
			// 
			this.domain.Location = new System.Drawing.Point(280, 80);
			this.domain.Name = "domain";
			this.domain.Size = new System.Drawing.Size(128, 20);
			this.domain.TabIndex = 1;
			this.domain.Text = "";
			// 
			// user
			// 
			this.user.Location = new System.Drawing.Point(280, 136);
			this.user.Name = "user";
			this.user.Size = new System.Drawing.Size(128, 20);
			this.user.TabIndex = 1;
			this.user.Text = "";
			this.toolTip1.SetToolTip(this.user, "(can be in the form DOMAIN\\user)");
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(280, 200);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(128, 20);
			this.password.TabIndex = 1;
			this.password.Text = "";
			// 
			// ok
			// 
			this.ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ok.Location = new System.Drawing.Point(56, 280);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(96, 24);
			this.ok.TabIndex = 2;
			this.ok.Text = "OK";
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancel.Location = new System.Drawing.Point(296, 280);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(96, 24);
			this.cancel.TabIndex = 2;
			this.cancel.Text = "Cancel";
			// 
			// MainFormConnectDialog
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(456, 318);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.computer);
			this.Controls.Add(this.domain);
			this.Controls.Add(this.user);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cancel);
			this.Name = "MainFormConnectDialog";
			this.Text = "MainFormConnectDialog";
			this.Load += new System.EventHandler(this.MainFormConnectDialog_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ok_Click(object sender, System.EventArgs e)
		{
			try
			{
				resultScope = null;

				ConnectionOptions options = new ConnectionOptions();

				if (!MainForm.isLocalServerName(computer.Text))
				{
					options.Username = user.Text;
					options.Password = password.Text;
					password.Text = "";
					if (domain.Text != "")
					{
						options.Authority = "NTLMDOMAIN:" + domain.Text;
					}
				}

				//Make a connection to a remote computer using these options
				ManagementScope scope = new ManagementScope("\\\\" + computer.Text + "\\root\\cimv2", options);
				scope.Connect();
				resultScope = scope;
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK);
				resultScope = null;
			}
		}

		private void MainFormConnectDialog_Load(object sender, System.EventArgs e)
		{
			if (resultScope != null)
			{
				user.Text = resultScope.Options.Username;
				String strDomain = resultScope.Options.Authority;
				if (strDomain.StartsWith(ntlmDomain))
				{
					domain.Text = strDomain.Substring(ntlmDomain.Length);
				}
				computer.Text = resultScope.Path.Server;
				resultScope = null;

			}
		}
	}
}
