using System;
using System.Collections;
using System.ComponentModel;
using System.Management;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WMI.NET
{	/// <summary>
	/// This application browses WMI classes available in the local namespace entered.
	/// </summary>
public class Form2 : System.Windows.Forms.Form
{
	private System.Windows.Forms.TextBox namespaceValue;
	private System.Windows.Forms.Button searchButton;
    private System.Windows.Forms.ListBox classList;
    private Label statusValue;
	/*protected Label Label1;
	protected TextBox namespaceValue;
	protected Button searchButton;
	protected ListBox classList;
	protected Label Label3;
	protected Label statusValue;
	protected Label Label2;
	private System.Windows.Forms.TextBox textBox1;*/
	private int count;
   
	public Form2() 
	{
		this.Load += new System.EventHandler(Page_Init);
	}

	private void Page_Init(object sender, EventArgs e) 
	{
		count = 0;
		InitializeComponent();
	}

	private void InitializeComponent() 
	{
        this.namespaceValue = new System.Windows.Forms.TextBox();
        this.searchButton = new System.Windows.Forms.Button();
        this.classList = new System.Windows.Forms.ListBox();
        this.statusValue = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // namespaceValue
        // 
        this.namespaceValue.Location = new System.Drawing.Point(400, 16);
        this.namespaceValue.Name = "namespaceValue";
        this.namespaceValue.Size = new System.Drawing.Size(96, 20);
        this.namespaceValue.TabIndex = 0;
        this.namespaceValue.Text = "\\root\\CIMV2";
        // 
        // searchButton
        // 
        this.searchButton.Location = new System.Drawing.Point(392, 56);
        this.searchButton.Name = "searchButton";
        this.searchButton.Size = new System.Drawing.Size(152, 48);
        this.searchButton.TabIndex = 1;
        this.searchButton.Text = "Get Classes list in namespace";
        this.searchButton.Click += new System.EventHandler(this.searchButton_Click_1);
        // 
        // classList
        // 
        this.classList.Location = new System.Drawing.Point(16, 64);
        this.classList.Name = "classList";
        this.classList.ScrollAlwaysVisible = true;
        this.classList.Size = new System.Drawing.Size(312, 264);
        this.classList.TabIndex = 2;
        // 
        // statusValue
        // 
        this.statusValue.Location = new System.Drawing.Point(376, 280);
        this.statusValue.Name = "statusValue";
        this.statusValue.Size = new System.Drawing.Size(192, 24);
        this.statusValue.TabIndex = 3;
        // 
        // Form2
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(608, 358);
        this.Controls.Add(this.statusValue);
        this.Controls.Add(this.classList);
        this.Controls.Add(this.searchButton);
        this.Controls.Add(this.namespaceValue);
        this.Name = "Form2";
        this.ResumeLayout(false);
        this.PerformLayout();

	}

	private void searchButton_Click(object sender, System.EventArgs e) 
	{
	}

	private void AddNamespacesToList() 
	{
		try 
		{
			// Enumerate all WMI instances of __namespace WMI class.
			ManagementClass nsClass = new ManagementClass(
				new ManagementScope("root"),
				new ManagementPath("__namespace"),
				null);
			foreach(ManagementObject ns in nsClass.GetInstances()) 
			{
				this.classList.Items.Add(ns["Name"].ToString());
				count++;
			}
			this.statusValue.Text = count + " namespaces found.";
		}
		catch (Exception e)   
		{
			this.statusValue.Text = e.Message;
		}
	}

	private void AddClassesToList() 
	{
		try 
		{   
			// Perform WMI object query on selected namespace.
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(
				new ManagementScope(namespaceValue.Text),
				new WqlObjectQuery("select * from meta_class"),
				null);               
			foreach (ManagementClass wmiClass in searcher.Get()) 
			{
				this.classList.Items.Add(wmiClass["__CLASS"].ToString());
				Debug.WriteLine(wmiClass["__CLASS"].ToString());
				count++;
			}
			this.statusValue.Text = count + " classes found.";
		}
		catch (Exception ex) 
		{
			this.statusValue.Text = ex.Message;
		}
	}

	private void searchButton_Click_1(object sender, System.EventArgs e)
	{
		// Initialize class counter and clear list view.
		count = 0;
		this.classList.Items.Clear();

		if (namespaceValue.Text.Equals("")) 
		{
			this.AddNamespacesToList();
		}
		else 
		{
			this.AddClassesToList();
		}
	
	}
}
}