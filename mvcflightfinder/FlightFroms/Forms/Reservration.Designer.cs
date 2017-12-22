namespace FlightFroms.Forms
{
    partial class Reservration
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
            this.tb_LastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_FrstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nupPeoples = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.fromTo = new System.Windows.Forms.Label();
            this.lcena = new System.Windows.Forms.Label();
            this.bt_Pay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupPeoples)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_LastName
            // 
            this.tb_LastName.Enabled = false;
            this.tb_LastName.Location = new System.Drawing.Point(203, 120);
            this.tb_LastName.Name = "tb_LastName";
            this.tb_LastName.Size = new System.Drawing.Size(100, 20);
            this.tb_LastName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(200, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Příjmení";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(50, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Jméno";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tb_FrstName
            // 
            this.tb_FrstName.Enabled = false;
            this.tb_FrstName.Location = new System.Drawing.Point(53, 120);
            this.tb_FrstName.Name = "tb_FrstName";
            this.tb_FrstName.Size = new System.Drawing.Size(100, 20);
            this.tb_FrstName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Počet lidí";
            // 
            // nupPeoples
            // 
            this.nupPeoples.Location = new System.Drawing.Point(53, 197);
            this.nupPeoples.Name = "nupPeoples";
            this.nupPeoples.Size = new System.Drawing.Size(100, 20);
            this.nupPeoples.TabIndex = 10;
            this.nupPeoples.ValueChanged += new System.EventHandler(this.nupPeoples_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(200, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pohlaví";
            // 
            // cbGender
            // 
            this.cbGender.AutoCompleteCustomSource.AddRange(new string[] {
            "M",
            "Ž"});
            this.cbGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "M",
            "Ž"});
            this.cbGender.Location = new System.Drawing.Point(203, 197);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(100, 21);
            this.cbGender.TabIndex = 12;
            // 
            // fromTo
            // 
            this.fromTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTo.Location = new System.Drawing.Point(94, 20);
            this.fromTo.Name = "fromTo";
            this.fromTo.Size = new System.Drawing.Size(185, 41);
            this.fromTo.TabIndex = 13;
            this.fromTo.Text = "FROM TO";
            // 
            // lcena
            // 
            this.lcena.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcena.Location = new System.Drawing.Point(199, 257);
            this.lcena.Name = "lcena";
            this.lcena.Size = new System.Drawing.Size(128, 32);
            this.lcena.TabIndex = 14;
            this.lcena.Text = "Cena: ";
            // 
            // bt_Pay
            // 
            this.bt_Pay.Location = new System.Drawing.Point(204, 305);
            this.bt_Pay.Name = "bt_Pay";
            this.bt_Pay.Size = new System.Drawing.Size(75, 23);
            this.bt_Pay.TabIndex = 15;
            this.bt_Pay.Text = "Zaplatit";
            this.bt_Pay.UseVisualStyleBackColor = true;
            this.bt_Pay.Click += new System.EventHandler(this.bt_Pay_Click);
            // 
            // Reservration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 355);
            this.Controls.Add(this.bt_Pay);
            this.Controls.Add(this.lcena);
            this.Controls.Add(this.fromTo);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nupPeoples);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_LastName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_FrstName);
            this.Name = "Reservration";
            this.Text = "Reservration";
            ((System.ComponentModel.ISupportInitialize)(this.nupPeoples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_LastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_FrstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupPeoples;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label fromTo;
        private System.Windows.Forms.Label lcena;
        private System.Windows.Forms.Button bt_Pay;
    }
}