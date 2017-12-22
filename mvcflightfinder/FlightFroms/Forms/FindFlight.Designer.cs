namespace FlightFroms.Forms
{
    partial class FindFlight
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
            this.panelflight = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.listResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dt_Dep = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_To = new System.Windows.Forms.TextBox();
            this.tb_From = new System.Windows.Forms.TextBox();
            this.panelMap = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelflight.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelflight
            // 
            this.panelflight.AutoScroll = true;
            this.panelflight.Controls.Add(this.label4);
            this.panelflight.Controls.Add(this.listResult);
            this.panelflight.Controls.Add(this.label3);
            this.panelflight.Controls.Add(this.button1);
            this.panelflight.Controls.Add(this.dt_Dep);
            this.panelflight.Controls.Add(this.label2);
            this.panelflight.Controls.Add(this.label1);
            this.panelflight.Controls.Add(this.tb_To);
            this.panelflight.Controls.Add(this.tb_From);
            this.panelflight.Location = new System.Drawing.Point(0, 0);
            this.panelflight.Name = "panelflight";
            this.panelflight.Size = new System.Drawing.Size(407, 800);
            this.panelflight.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(391, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pro přidání položky do oblíbených nebo zakoupení letenky\r\n musíte kliknout pravým" +
    " tlačítkem myši na položku v seznamu";
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listResult.Location = new System.Drawing.Point(12, 178);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(391, 619);
            this.listResult.TabIndex = 7;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            this.listResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listResult_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Odkud letím";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kam letím";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kdy letím";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Jak dlouho letím";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kdy odlétám ?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Vyhledat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dt_Dep
            // 
            this.dt_Dep.CustomFormat = "";
            this.dt_Dep.Location = new System.Drawing.Point(34, 96);
            this.dt_Dep.MinDate = new System.DateTime(2017, 12, 21, 0, 0, 0, 0);
            this.dt_Dep.Name = "dt_Dep";
            this.dt_Dep.Size = new System.Drawing.Size(192, 20);
            this.dt_Dep.TabIndex = 4;
            this.dt_Dep.Value = new System.DateTime(2017, 12, 22, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kam letím?";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odkud letím?";
            // 
            // tb_To
            // 
            this.tb_To.Location = new System.Drawing.Point(236, 35);
            this.tb_To.Name = "tb_To";
            this.tb_To.Size = new System.Drawing.Size(100, 20);
            this.tb_To.TabIndex = 1;
            // 
            // tb_From
            // 
            this.tb_From.Location = new System.Drawing.Point(31, 35);
            this.tb_From.Name = "tb_From";
            this.tb_From.Size = new System.Drawing.Size(100, 20);
            this.tb_From.TabIndex = 0;
            // 
            // panelMap
            // 
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMap.Location = new System.Drawing.Point(409, 0);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(740, 797);
            this.panelMap.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem1.Text = "Přidat do oblíbených";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem2.Text = "Zakoupit letenku";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "id";
            this.columnHeader6.Width = 30;
            // 
            // FindFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 800);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelflight);
            this.Name = "FindFlight";
            this.Text = "z";
            this.panelflight.ResumeLayout(false);
            this.panelflight.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelflight;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.FlowLayoutPanel panelMap;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dt_Dep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}