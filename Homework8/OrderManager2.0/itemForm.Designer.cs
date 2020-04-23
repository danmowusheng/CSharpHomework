namespace OrderManager2._0
{
    partial class itemForm
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
            this.labName = new System.Windows.Forms.Label();
            this.labPrice = new System.Windows.Forms.Label();
            this.labNum = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(48, 64);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(52, 15);
            this.labName.TabIndex = 0;
            this.labName.Text = "商品名";
            // 
            // labPrice
            // 
            this.labPrice.AutoSize = true;
            this.labPrice.Location = new System.Drawing.Point(48, 121);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new System.Drawing.Size(37, 15);
            this.labPrice.TabIndex = 1;
            this.labPrice.Text = "单价";
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(48, 188);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(67, 15);
            this.labNum.TabIndex = 2;
            this.labNum.Text = "购买数量";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(127, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 25);
            this.txtName.TabIndex = 3;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(127, 178);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(163, 25);
            this.txtNum.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(127, 118);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(163, 25);
            this.txtPrice.TabIndex = 5;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(51, 248);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(91, 46);
            this.btnok.TabIndex = 6;
            this.btnok.Text = "确定";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(199, 248);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(91, 46);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(OrderManager2._0.OrderItem);
            // 
            // itemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 319);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labNum);
            this.Controls.Add(this.labPrice);
            this.Controls.Add(this.labName);
            this.Name = "itemForm";
            this.Text = "itemForm";
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labPrice;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.BindingSource itemBindingSource;
    }
}