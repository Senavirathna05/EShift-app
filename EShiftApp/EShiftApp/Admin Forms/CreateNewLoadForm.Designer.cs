namespace EShiftApp.Admin_Forms
{
    partial class CreateNewLoadForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAssignTransportUnit = new System.Windows.Forms.ComboBox();
            this.txtJobId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvNewTransportUnits = new System.Windows.Forms.DataGridView();
            this.btnTransport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddProductRow = new System.Windows.Forms.Button();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewTransportUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a new Load";
            // 
            // cmbAssignTransportUnit
            // 
            this.cmbAssignTransportUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssignTransportUnit.FormattingEnabled = true;
            this.cmbAssignTransportUnit.Location = new System.Drawing.Point(217, 93);
            this.cmbAssignTransportUnit.Name = "cmbAssignTransportUnit";
            this.cmbAssignTransportUnit.Size = new System.Drawing.Size(378, 32);
            this.cmbAssignTransportUnit.TabIndex = 1;
            // 
            // txtJobId
            // 
            this.txtJobId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobId.Location = new System.Drawing.Point(60, 96);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(100, 29);
            this.txtJobId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "JOB ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "Assign Transport Unit";
            // 
            // dgvNewTransportUnits
            // 
            this.dgvNewTransportUnits.AllowUserToAddRows = false;
            this.dgvNewTransportUnits.AllowUserToDeleteRows = false;
            this.dgvNewTransportUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewTransportUnits.Location = new System.Drawing.Point(60, 152);
            this.dgvNewTransportUnits.Name = "dgvNewTransportUnits";
            this.dgvNewTransportUnits.ReadOnly = true;
            this.dgvNewTransportUnits.Size = new System.Drawing.Size(1091, 343);
            this.dgvNewTransportUnits.TabIndex = 5;
            // 
            // btnTransport
            // 
            this.btnTransport.BackColor = System.Drawing.Color.Blue;
            this.btnTransport.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransport.ForeColor = System.Drawing.Color.White;
            this.btnTransport.Location = new System.Drawing.Point(892, 82);
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.Size = new System.Drawing.Size(259, 43);
            this.btnTransport.TabIndex = 58;
            this.btnTransport.Text = "+ Transport Units";
            this.btnTransport.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(735, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 50);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(957, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(196, 50);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAddProductRow
            // 
            this.btnAddProductRow.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAddProductRow.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProductRow.ForeColor = System.Drawing.Color.White;
            this.btnAddProductRow.Location = new System.Drawing.Point(60, 521);
            this.btnAddProductRow.Name = "btnAddProductRow";
            this.btnAddProductRow.Size = new System.Drawing.Size(259, 43);
            this.btnAddProductRow.TabIndex = 61;
            this.btnAddProductRow.Text = "Add Product Row";
            this.btnAddProductRow.UseVisualStyleBackColor = false;
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.BackColor = System.Drawing.Color.DeepPink;
            this.btnAddNewProduct.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddNewProduct.Location = new System.Drawing.Point(336, 521);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(259, 43);
            this.btnAddNewProduct.TabIndex = 62;
            this.btnAddNewProduct.Text = "Add New Product";
            this.btnAddNewProduct.UseVisualStyleBackColor = false;
            // 
            // CreateNewLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 589);
            this.Controls.Add(this.btnAddNewProduct);
            this.Controls.Add(this.btnAddProductRow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTransport);
            this.Controls.Add(this.dgvNewTransportUnits);
            this.Controls.Add(this.txtJobId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAssignTransportUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "CreateNewLoadForm";
            this.Text = "CreateNewLoadForm";
            this.Load += new System.EventHandler(this.CreateNewLoadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewTransportUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAssignTransportUnit;
        private System.Windows.Forms.TextBox txtJobId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvNewTransportUnits;
        private System.Windows.Forms.Button btnTransport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddProductRow;
        private System.Windows.Forms.Button btnAddNewProduct;
    }
}