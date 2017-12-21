namespace FlightForms.Forms
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.favoriteFligthsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flyFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flyToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nog0030DataSet = new FlightForms.nog0030DataSet();
            this.bookedFlightsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookedFlightsTableAdapter = new FlightForms.nog0030DataSetTableAdapters.BookedFlightsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.favoriteFligthsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nog0030DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookedFlightsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vítejte uživateli: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vyhledat let";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flyFromDataGridViewTextBoxColumn,
            this.flyToDataGridViewTextBoxColumn,
            this.datefromDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.Delete});
            this.dataGridView1.DataSource = this.favoriteFligthsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(556, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // favoriteFligthsBindingSource
            // 
            this.favoriteFligthsBindingSource.DataSource = typeof(DBHandler.DataMapper.FavoriteFligths);
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
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oblíbené lety";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vaše rezervované letenky";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 426);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 5;
            // 
            // nog0030DataSet
            // 
            this.nog0030DataSet.DataSetName = "nog0030DataSet";
            this.nog0030DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookedFlightsBindingSource
            // 
            this.bookedFlightsBindingSource.DataMember = "BookedFlights";
            this.bookedFlightsBindingSource.DataSource = this.nog0030DataSet;
            // 
            // bookedFlightsTableAdapter
            // 
            this.bookedFlightsTableAdapter.ClearBeforeFill = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 596);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.favoriteFligthsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nog0030DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookedFlightsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource favoriteFligthsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private nog0030DataSet nog0030DataSet;
        private System.Windows.Forms.BindingSource bookedFlightsBindingSource;
        private nog0030DataSetTableAdapters.BookedFlightsTableAdapter bookedFlightsTableAdapter;
    }
}