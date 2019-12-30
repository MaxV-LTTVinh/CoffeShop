namespace CoffeShop.GUI
{
    partial class fBillPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBillPrint));
            this.uSPGetPrintBillWithCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coffeShopDataSet = new CoffeShop.CoffeShopDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_GetPrintBillWithCustomerTableAdapter = new CoffeShop.CoffeShopDataSetTableAdapters.USP_GetPrintBillWithCustomerTableAdapter();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetPrintBillWithCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coffeShopDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPGetPrintBillWithCustomerBindingSource
            // 
            this.uSPGetPrintBillWithCustomerBindingSource.DataMember = "USP_GetPrintBillWithCustomer";
            this.uSPGetPrintBillWithCustomerBindingSource.DataSource = this.coffeShopDataSet;
            // 
            // coffeShopDataSet
            // 
            this.coffeShopDataSet.DataSetName = "CoffeShopDataSet";
            this.coffeShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPGetPrintBillWithCustomerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CoffeShop.GUI.reportBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 33);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(498, 537);
            this.reportViewer1.TabIndex = 0;
            // 
            // uSP_GetPrintBillWithCustomerTableAdapter
            // 
            this.uSP_GetPrintBillWithCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(465, 1);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 32);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // fBillPrint
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 570);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fBillPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fBillPrint_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetPrintBillWithCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coffeShopDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPGetPrintBillWithCustomerBindingSource;
        private CoffeShopDataSet coffeShopDataSet;
        private CoffeShopDataSetTableAdapters.USP_GetPrintBillWithCustomerTableAdapter uSP_GetPrintBillWithCustomerTableAdapter;
        private System.Windows.Forms.Button btnExit;
    }
}