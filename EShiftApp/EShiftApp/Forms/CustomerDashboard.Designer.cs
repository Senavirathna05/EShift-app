namespace EShiftApp.Forms
{
    partial class CustomerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDashbord = new System.Windows.Forms.Button();
            this.btnJobs = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCreateJob = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblReject = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Controls.Add(this.pbProfile);
            this.panel1.Controls.Add(this.pbBack);
            this.panel1.Location = new System.Drawing.Point(261, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 77);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer Dashboard";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(889, 22);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(155, 34);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Sahan Lakmal ";
            // 
            // pbProfile
            // 
            this.pbProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbProfile.Image = ((System.Drawing.Image)(resources.GetObject("pbProfile.Image")));
            this.pbProfile.Location = new System.Drawing.Point(851, 21);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(32, 29);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfile.TabIndex = 2;
            this.pbProfile.TabStop = false;
            this.pbProfile.Click += new System.EventHandler(this.pbProfile_Click);
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.White;
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(1105, 21);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(28, 29);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 1;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.btnDashbord);
            this.panel2.Controls.Add(this.btnJobs);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(-2, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 671);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnDashbord
            // 
            this.btnDashbord.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDashbord.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashbord.ForeColor = System.Drawing.Color.White;
            this.btnDashbord.Image = ((System.Drawing.Image)(resources.GetObject("btnDashbord.Image")));
            this.btnDashbord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashbord.Location = new System.Drawing.Point(3, 138);
            this.btnDashbord.Name = "btnDashbord";
            this.btnDashbord.Size = new System.Drawing.Size(262, 64);
            this.btnDashbord.TabIndex = 4;
            this.btnDashbord.Text = "     Dashboard";
            this.btnDashbord.UseVisualStyleBackColor = false;
            // 
            // btnJobs
            // 
            this.btnJobs.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnJobs.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobs.ForeColor = System.Drawing.Color.White;
            this.btnJobs.Image = ((System.Drawing.Image)(resources.GetObject("btnJobs.Image")));
            this.btnJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobs.Location = new System.Drawing.Point(3, 234);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Size = new System.Drawing.Size(262, 64);
            this.btnJobs.TabIndex = 3;
            this.btnJobs.Text = "My Jobs";
            this.btnJobs.UseVisualStyleBackColor = false;
            this.btnJobs.Click += new System.EventHandler(this.btnJobs_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-31, -44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnCreateJob);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblWelcome);
            this.panel3.Location = new System.Drawing.Point(276, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1151, 89);
            this.panel3.TabIndex = 4;
            // 
            // btnCreateJob
            // 
            this.btnCreateJob.BackColor = System.Drawing.Color.Blue;
            this.btnCreateJob.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateJob.ForeColor = System.Drawing.Color.White;
            this.btnCreateJob.Location = new System.Drawing.Point(899, 23);
            this.btnCreateJob.Name = "btnCreateJob";
            this.btnCreateJob.Size = new System.Drawing.Size(233, 43);
            this.btnCreateJob.TabIndex = 6;
            this.btnCreateJob.Text = "+ Create Job";
            this.btnCreateJob.UseVisualStyleBackColor = false;
            this.btnCreateJob.Click += new System.EventHandler(this.btnCreateJob_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(432, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Manage your transport jobs and track your deliveries";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(224, 42);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome, sahan";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.lblAccepted);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.pictureBox8);
            this.panel8.Location = new System.Drawing.Point(574, 196);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(262, 91);
            this.panel8.TabIndex = 9;
            // 
            // lblAccepted
            // 
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Font = new System.Drawing.Font("Poppins Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccepted.Location = new System.Drawing.Point(92, 39);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(30, 37);
            this.lblAccepted.TabIndex = 7;
            this.lblAccepted.Text = "3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(94, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 34);
            this.label11.TabIndex = 6;
            this.label11.Text = "Accepted Jobs";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(20, 18);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(61, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 5;
            this.pictureBox8.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblCompleted);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Controls.Add(this.pictureBox9);
            this.panel9.Location = new System.Drawing.Point(871, 196);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(262, 91);
            this.panel9.TabIndex = 10;
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Font = new System.Drawing.Font("Poppins Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(82, 39);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(30, 37);
            this.lblCompleted.TabIndex = 7;
            this.lblCompleted.Text = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(83, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 34);
            this.label13.TabIndex = 6;
            this.label13.Text = "Completed Jobs";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(15, 18);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(61, 50);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 5;
            this.pictureBox9.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.lblReject);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Controls.Add(this.pictureBox10);
            this.panel10.Location = new System.Drawing.Point(1165, 196);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(262, 91);
            this.panel10.TabIndex = 11;
            // 
            // lblReject
            // 
            this.lblReject.AutoSize = true;
            this.lblReject.Font = new System.Drawing.Font("Poppins Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(93, 39);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(30, 37);
            this.lblReject.TabIndex = 7;
            this.lblReject.Text = "3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(92, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 34);
            this.label15.TabIndex = 6;
            this.label15.Text = "Decline Jobs";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(21, 18);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(61, 50);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 5;
            this.pictureBox10.TabStop = false;
            // 
            // dgvJobs
            // 
            this.dgvJobs.AllowUserToAddRows = false;
            this.dgvJobs.AllowUserToDeleteRows = false;
            this.dgvJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Location = new System.Drawing.Point(-1, 52);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.ReadOnly = true;
            this.dgvJobs.Size = new System.Drawing.Size(1150, 302);
            this.dgvJobs.TabIndex = 12;
            this.dgvJobs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobs_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.dgvJobs);
            this.groupBox1.Font = new System.Drawing.Font("Poppins Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(277, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1150, 354);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recent Jobs";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1115, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(91, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 34);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total Jobs";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Poppins Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(92, 39);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(30, 37);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "3";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.lblTotal);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.pictureBox7);
            this.panel7.Location = new System.Drawing.Point(277, 196);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(262, 91);
            this.panel7.TabIndex = 8;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(19, 18);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(61, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 5;
            this.pictureBox7.TabStop = false;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 671);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerDashboard";
            this.Text = "CustomerDashboard";
            this.Load += new System.EventHandler(this.CustomerDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnCreateJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.Button btnJobs;
        private System.Windows.Forms.Button btnDashbord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel7;
    }
}