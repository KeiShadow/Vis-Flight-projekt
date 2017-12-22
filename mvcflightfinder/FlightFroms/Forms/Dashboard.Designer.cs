namespace FlightFroms.Forms
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flyFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flyToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.favoriteFligthsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.flyFromDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flyToDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peoplesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateofresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookedFlightsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.labelNick = new System.Windows.Forms.Label();
            this.bt_RefreshFav = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.favoriteFligthsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookedFlightsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vítejte uživateli:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flyFromDataGridViewTextBoxColumn,
            this.flyToDataGridViewTextBoxColumn,
            this.datefromDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.favoriteFligthsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(571, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // flyFromDataGridViewTextBoxColumn
            // 
            this.flyFromDataGridViewTextBoxColumn.DataPropertyName = "FlyFrom";
            this.flyFromDataGridViewTextBoxColumn.HeaderText = "Fly From";
            this.flyFromDataGridViewTextBoxColumn.Name = "flyFromDataGridViewTextBoxColumn";
            // 
            // flyToDataGridViewTextBoxColumn
            // 
            this.flyToDataGridViewTextBoxColumn.DataPropertyName = "FlyTo";
            this.flyToDataGridViewTextBoxColumn.HeaderText = "Fly To";
            this.flyToDataGridViewTextBoxColumn.Name = "flyToDataGridViewTextBoxColumn";
            // 
            // datefromDataGridViewTextBoxColumn
            // 
            this.datefromDataGridViewTextBoxColumn.DataPropertyName = "Datefrom";
            this.datefromDataGridViewTextBoxColumn.HeaderText = "Date from";
            this.datefromDataGridViewTextBoxColumn.Name = "datefromDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // favoriteFligthsBindingSource
            // 
            this.favoriteFligthsBindingSource.DataSource = typeof(DBHandler.DataMapper.FavoriteFligths);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Oblíbené Lety";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zakoupené lety";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flyFromDataGridViewTextBoxColumn1,
            this.flyToDataGridViewTextBoxColumn1,
            this.datefromDataGridViewTextBoxColumn1,
            this.peoplesDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn1,
            this.dateofresDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.bookedFlightsBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(12, 413);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1093, 155);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // flyFromDataGridViewTextBoxColumn1
            // 
            this.flyFromDataGridViewTextBoxColumn1.DataPropertyName = "FlyFrom";
            this.flyFromDataGridViewTextBoxColumn1.HeaderText = "Fly From";
            this.flyFromDataGridViewTextBoxColumn1.Name = "flyFromDataGridViewTextBoxColumn1";
            // 
            // flyToDataGridViewTextBoxColumn1
            // 
            this.flyToDataGridViewTextBoxColumn1.DataPropertyName = "FlyTo";
            this.flyToDataGridViewTextBoxColumn1.HeaderText = "Fly To";
            this.flyToDataGridViewTextBoxColumn1.Name = "flyToDataGridViewTextBoxColumn1";
            // 
            // datefromDataGridViewTextBoxColumn1
            // 
            this.datefromDataGridViewTextBoxColumn1.DataPropertyName = "Datefrom";
            this.datefromDataGridViewTextBoxColumn1.HeaderText = "Date From";
            this.datefromDataGridViewTextBoxColumn1.Name = "datefromDataGridViewTextBoxColumn1";
            // 
            // peoplesDataGridViewTextBoxColumn
            // 
            this.peoplesDataGridViewTextBoxColumn.DataPropertyName = "Peoples";
            this.peoplesDataGridViewTextBoxColumn.HeaderText = "Peoples";
            this.peoplesDataGridViewTextBoxColumn.Name = "peoplesDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn1
            // 
            this.priceDataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn1.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn1.Name = "priceDataGridViewTextBoxColumn1";
            // 
            // dateofresDataGridViewTextBoxColumn
            // 
            this.dateofresDataGridViewTextBoxColumn.DataPropertyName = "Dateofres";
            this.dateofresDataGridViewTextBoxColumn.HeaderText = "Date of reservation";
            this.dateofresDataGridViewTextBoxColumn.Name = "dateofresDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            // 
            // bookedFlightsBindingSource
            // 
            this.bookedFlightsBindingSource.DataSource = typeof(DBHandler.DataMapper.BookedFlights);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Vyhledej let";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNick.Location = new System.Drawing.Point(285, 45);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(112, 31);
            this.labelNick.TabIndex = 6;
            this.labelNick.Text = "Uživatel";
            // 
            // bt_RefreshFav
            // 
            this.bt_RefreshFav.Location = new System.Drawing.Point(1016, 12);
            this.bt_RefreshFav.Name = "bt_RefreshFav";
            this.bt_RefreshFav.Size = new System.Drawing.Size(89, 30);
            this.bt_RefreshFav.TabIndex = 7;
            this.bt_RefreshFav.Text = "Refresh";
            this.bt_RefreshFav.UseVisualStyleBackColor = true;
            this.bt_RefreshFav.Click += new System.EventHandler(this.bt_RefreshFav_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1030, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ukončit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1030, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Odhlásit se";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 583);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_RefreshFav);
            this.Controls.Add(this.labelNick);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.favoriteFligthsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookedFlightsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource favoriteFligthsBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyFromDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyToDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefromDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn peoplesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateofresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bookedFlightsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bt_RefreshFav;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}