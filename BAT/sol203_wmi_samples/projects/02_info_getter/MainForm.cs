using System;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Management;
using System.Data;
using System.Diagnostics;


namespace WMI.NET
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button loadAll;
		private System.Data.DataSet oneMachineDataSet;

		private DateTime gettingTime = DateTime.Now;
		internal System.Data.SqlClient.SqlConnection allMachinesDataConnection;
		private System.Data.SqlClient.SqlCommand insertDataCommand;
		private System.Data.SqlClient.SqlCommand sqlCommandGetXml;
		private System.Windows.Forms.DataGrid mainDataGrid;
		private System.Windows.Forms.MenuItem menuItem2;

		ManagementScope mainScope = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public static void Main()
		{
			/*
			Debug.WriteLine(isLocalServerName("marat"));
			Debug.WriteLine(isLocalServerName("127.0.0.1"));
			Debug.WriteLine(isLocalServerName("192.0.0.80"));
			Debug.WriteLine(isLocalServerName("."));
			Debug.WriteLine(isLocalServerName("localhost"));
			*/

			Application.EnableVisualStyles();
            //Application.Run(new ClassesListForm());
            Application.Run(new MainForm());
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
			this.oneMachineDataSet = new System.Data.DataSet();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.mainDataGrid = new System.Windows.Forms.DataGrid();
			this.loadAll = new System.Windows.Forms.Button();
			this.allMachinesDataConnection = new System.Data.SqlClient.SqlConnection();
			this.insertDataCommand = new System.Data.SqlClient.SqlCommand();
			this.sqlCommandGetXml = new System.Data.SqlClient.SqlCommand();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.oneMachineDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// oneMachineDataSet
			// 
			this.oneMachineDataSet.DataSetName = "AllData";
			this.oneMachineDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "Main menu";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Exit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 467);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(640, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "Not connected";
			// 
			// mainDataGrid
			// 
			this.mainDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.mainDataGrid.DataMember = "";
			this.mainDataGrid.DataSource = this.oneMachineDataSet;
			this.mainDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.mainDataGrid.Location = new System.Drawing.Point(16, 56);
			this.mainDataGrid.Name = "mainDataGrid";
			this.mainDataGrid.Size = new System.Drawing.Size(608, 400);
			this.mainDataGrid.TabIndex = 1;
			// 
			// loadAll
			// 
			this.loadAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.loadAll.Location = new System.Drawing.Point(16, 16);
			this.loadAll.Name = "loadAll";
			this.loadAll.Size = new System.Drawing.Size(160, 24);
			this.loadAll.TabIndex = 2;
			this.loadAll.Text = "Get Current Data";
			this.loadAll.Click += new System.EventHandler(this.loadAll_Click);
			// 
			// insertDataCommand
			// 
			this.insertDataCommand.CommandText = "INSERT INTO computer_data (DateTime, COMPUTERNAME, DATA) VALUES (@DateTime, @Comp" +
				"uterName, @Data); SELECT ID, DateTime, COMPUTERNAME, DATA FROM computer_data WHE" +
				"RE (ID = @@IDENTITY)";
			this.insertDataCommand.Connection = this.allMachinesDataConnection;
			this.insertDataCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime", System.Data.SqlDbType.DateTime, 8, "DateTime"));
			this.insertDataCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ComputerName", System.Data.SqlDbType.VarChar, 100, "COMPUTERNAME"));
			this.insertDataCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.VarChar, 2147483647, "DATA"));
			// 
			// sqlCommandGetXml
			// 
			this.sqlCommandGetXml.CommandText = "SELECT DATA FROM computer_data WHERE (ID = @ID)";
			this.sqlCommandGetXml.Connection = this.allMachinesDataConnection;
			this.sqlCommandGetXml.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.BigInt, 8, "ID"));
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Classes List";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 489);
			this.Controls.Add(this.mainDataGrid);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.loadAll);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.oneMachineDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainDataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		public static bool isLocalServerName(String strServerName) 
		{
			return (strServerName.ToLower() == "." || strServerName.ToLower() == "localhost"
				||Dns.Resolve(Dns.GetHostName()).HostName == Dns.Resolve(strServerName).HostName);
		}

		private void RefreshStatusBar() 
		{
			//      if (mainScope != null) {
			//        statusBar1.Text = "подключение к" + mainScope.Path;
			//      }
			//      if (oneMachineDataSet.Tables.Count > 0) {
			//        statusBar1.Text += ", данные получены " + gettingTime.ToLongTimeString();
			//      }
			if (mainScope != null) 
			{
				statusBar1.Text = "Connection to " + mainScope.Path;
			}
			if (oneMachineDataSet.Tables.Count > 0) 
			{
				statusBar1.Text += ", data received " + gettingTime.ToLongTimeString();
			}
		}

		public static void LoadDataFromScope(String strClassName, DataSet dataSet, ManagementScope scope)
		{
			try
			{
				ManagementClass mgmClass = new ManagementClass(scope,new ManagementPath(strClassName), new ObjectGetOptions());
				if (mgmClass == null)
				{
					MessageBox.Show("cannot access class" + strClassName,"error",MessageBoxButtons.OK);
					return;
				}
				if (dataSet.Tables[strClassName] == null)
				{
					DataTable tableInner = dataSet.Tables.Add(strClassName);
				}
				DataTable table = dataSet.Tables[strClassName];
				table.BeginInit();
				foreach (PropertyData data in  mgmClass.Properties)
				{
					if (!table.Columns.Contains(data.Name))
					{
						DataColumn column = table.Columns.Add(data.Name);
						column.DataType = typeof(String);
					}
				}
				table.EndInit();
				
				ManagementObjectCollection objects = mgmClass.GetInstances();
				table.Rows.Clear();
				foreach (ManagementObject mgmObject in objects)
				{
					DataRow newRow = table.NewRow();
					foreach (PropertyData data in  mgmObject.Properties)
					{
						if (table.Columns.Contains(data.Name))
						{
							if (data.Value == null)
							{
								newRow[data.Name] = System.DBNull.Value;
							}
							else
							{
								newRow[data.Name] = data.Value.ToString();
							}
						}
					}
					table.Rows.Add(newRow);
					newRow.AcceptChanges();
				}
				
				table.AcceptChanges();
				dataSet.AcceptChanges();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(),"error",MessageBoxButtons.OK);
				dataSet.RejectChanges();
			}

		}

		private void DoLoad(String strClassName)
		{
			LoadDataFromScope(strClassName,oneMachineDataSet,mainScope);
		}

		private void loadAll_Click(object sender, System.EventArgs e)
		{
			MainFormConnectDialog connect = new MainFormConnectDialog();
			connect.resultScope = mainScope;
			DialogResult result =  connect.ShowDialog();
			if (result == DialogResult.Cancel) 
			{
				return;
			}
			if (connect.resultScope != null) 
			{
				mainScope = connect.resultScope;
				oneMachineDataSet.Clear();
				oneMachineDataSet.Tables.Clear();
				mainDataGrid.Refresh();
			}
			else 
			{
				MessageBox.Show("не могу подключиться к коммпьютеру");
				return;
			}

			RefreshStatusBar();

			gettingTime = DateTime.Now;

            //DoLoad("Win32_IP4RouteTable");
            //DoLoad("Win32_ActiveRoute");
            //DoLoad("Win32_IP4PersistedRouteTable");
			
			DoLoad("Win32_LogicalDisk");
			DoLoad("Win32_OperatingSystem");
            //DoLoad("Win32_Account");       // can be slow
            //DoLoad("Win32_UserAccount");   // can be slow
            //DoLoad("Win32_SystemAccount"); // can be slow
            //DoLoad("Win32_Group");         // can be slow
            DoLoad("Win32_Share");
            DoLoad("Win32_DiskDrive");
            //DoLoad("Win32_SerialPort");
            //DoLoad("Win32_ParallelPort");
            DoLoad("Win32_Printer");
            //DoLoad("Win32_NetworkAdapter");
            //DoLoad("Win32_NetworkAdapterConfiguration");
            //DoLoad("Win32_NetworkAdapterSetting");
 			
			/*DoLoad("__Event");
			DoLoad("__ClassOperationEvent");
			DoLoad("__ClassModificationEvent");
			DoLoad("__ClassCreationEvent");
			DoLoad("__ClassDeletionEvent");

			DoLoad("__NamespaceOperationEvent");
			DoLoad("__NamespaceDeletionEvent");
			DoLoad("__NamespaceCreationEvent");
			DoLoad("__NamespaceModificationEvent");
			DoLoad("__InstanceOperationEvent");
			DoLoad("__MethodInvocationEvent");
			DoLoad("__InstanceCreationEvent");
			DoLoad("__InstanceModificationEvent");
			DoLoad("__InstanceDeletionEvent");
			DoLoad("__ExtrinsicEvent");
			DoLoad("__SystemEvent");
			DoLoad("__EventDroppedEvent");
			DoLoad("__ConsumerFailureEvent");
			DoLoad("__QOSFailureEvent");
			DoLoad("__EventQueueOverflowEvent");
			DoLoad("MSFT_WMI_GenericNonCOMEvent");
			DoLoad("MSFT_WmiSelfEvent");
			DoLoad("Msft_WmiProvider_OperationEvent");
			DoLoad("Msft_WmiProvider_ComServerLoadOperationEvent");
			DoLoad("Msft_WmiProvider_InitializationOperationFailureEvent");
			DoLoad("Msft_WmiProvider_LoadOperationEvent");
			*/
			
      
			mainDataGrid.DataSource = null;
			mainDataGrid.DataSource = oneMachineDataSet;

			RefreshStatusBar();
		
		}

		private void MainForm_Load(object sender, System.EventArgs e) 
		{
			try 
			{
				//allMachinesDataConnection.Open();
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
		{
			if (allMachinesDataConnection.State == ConnectionState.Open) 
			{
				allMachinesDataConnection.Close();
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			new Form2().ShowDialog();
		}

	}
}
