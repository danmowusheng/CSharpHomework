namespace OrderManager2._0
{
    partial class AddOrder
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
            this.labCustomer = new System.Windows.Forms.Label();
            this.labAddress = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.itemdgv = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnadditem = new System.Windows.Forms.Button();
            this.btndeleteitem = new System.Windows.Forms.Button();
            this.btnmodifyitem = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labCustomer
            // 
            this.labCustomer.AutoSize = true;
            this.labCustomer.Location = new System.Drawing.Point(174, 44);
            this.labCustomer.Name = "labCustomer";
            this.labCustomer.Size = new System.Drawing.Size(52, 15);
            this.labCustomer.TabIndex = 0;
            this.labCustomer.Text = "客户名";
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Location = new System.Drawing.Point(174, 85);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(37, 15);
            this.labAddress.TabIndex = 1;
            this.labAddress.Text = "地址";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(298, 34);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(293, 25);
            this.txtCustomer.TabIndex = 2;
            this.txtCustomer.Text = "LJ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(298, 82);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(293, 25);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "WHU";
            // 
            // itemdgv
            // 
            this.itemdgv.AutoGenerateColumns = false;
            this.itemdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn});
            this.itemdgv.DataSource = this.itemBindingSource;
            this.itemdgv.Location = new System.Drawing.Point(177, 136);
            this.itemdgv.Name = "itemdgv";
            this.itemdgv.ReadOnly = true;
            this.itemdgv.RowHeadersWidth = 51;
            this.itemdgv.RowTemplate.Height = 27;
            this.itemdgv.Size = new System.Drawing.Size(769, 302);
            this.itemdgv.TabIndex = 4;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "商品名";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 175;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "单价";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 175;
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "num";
            this.numDataGridViewTextBoxColumn.HeaderText = "数量";
            this.numDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            this.numDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDataGridViewTextBoxColumn.Width = 175;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataMember = "OrderItems";
            this.itemBindingSource.DataSource = typeof(OrderManager2._0.Order);
            // 
            // btnadditem
            // 
            this.btnadditem.Location = new System.Drawing.Point(12, 154);
            this.btnadditem.Name = "btnadditem";
            this.btnadditem.Size = new System.Drawing.Size(121, 40);
            this.btnadditem.TabIndex = 5;
            this.btnadditem.Text = "添加明细";
            this.btnadditem.UseVisualStyleBackColor = true;
            this.btnadditem.Click += new System.EventHandler(this.btnadditem_Click);
            // 
            // btndeleteitem
            // 
            this.btndeleteitem.Location = new System.Drawing.Point(12, 223);
            this.btndeleteitem.Name = "btndeleteitem";
            this.btndeleteitem.Size = new System.Drawing.Size(121, 40);
            this.btndeleteitem.TabIndex = 6;
            this.btndeleteitem.Text = "删除明细";
            this.btndeleteitem.UseVisualStyleBackColor = true;
            this.btndeleteitem.Click += new System.EventHandler(this.btndeleteitem_Click);
            // 
            // btnmodifyitem
            // 
            this.btnmodifyitem.Location = new System.Drawing.Point(12, 304);
            this.btnmodifyitem.Name = "btnmodifyitem";
            this.btnmodifyitem.Size = new System.Drawing.Size(121, 40);
            this.btnmodifyitem.TabIndex = 7;
            this.btnmodifyitem.Text = "修改明细";
            this.btnmodifyitem.UseVisualStyleBackColor = true;
            this.btnmodifyitem.Click += new System.EventHandler(this.btnmodifyitem_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(12, 371);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(121, 40);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "保存订单";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 452);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnmodifyitem);
            this.Controls.Add(this.btndeleteitem);
            this.Controls.Add(this.btnadditem);
            this.Controls.Add(this.itemdgv);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.labAddress);
            this.Controls.Add(this.labCustomer);
            this.Name = "AddOrder";
            this.Text = "AddOrder";
            ((System.ComponentModel.ISupportInitialize)(this.itemdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labCustomer;
        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DataGridView itemdgv;
        private System.Windows.Forms.Button btnadditem;
        private System.Windows.Forms.Button btndeleteitem;
        private System.Windows.Forms.Button btnmodifyitem;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
    }
}