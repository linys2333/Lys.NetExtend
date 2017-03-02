namespace AnyControl
{
    partial class SingleCombox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sgcbButton = new System.Windows.Forms.Button();
            this.sgcbData = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sgcbData)).BeginInit();
            this.SuspendLayout();
            // 
            // sgcbButton
            // 
            this.sgcbButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sgcbButton.Location = new System.Drawing.Point(300, 0);
            this.sgcbButton.Name = "sgcbButton";
            this.sgcbButton.Size = new System.Drawing.Size(30, 30);
            this.sgcbButton.TabIndex = 0;
            this.sgcbButton.Tag = "";
            this.sgcbButton.Text = "点";
            this.sgcbButton.UseVisualStyleBackColor = true;
            this.sgcbButton.Click += new System.EventHandler(this.sgcbButton_Click);
            // 
            // sgcbData
            // 
            this.sgcbData.AllowUserToAddRows = false;
            this.sgcbData.AllowUserToResizeColumns = false;
            this.sgcbData.AllowUserToResizeRows = false;
            this.sgcbData.BackgroundColor = System.Drawing.Color.White;
            this.sgcbData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sgcbData.ColumnHeadersVisible = false;
            this.sgcbData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.sgcbData.GridColor = System.Drawing.Color.White;
            this.sgcbData.Location = new System.Drawing.Point(0, 35);
            this.sgcbData.MultiSelect = false;
            this.sgcbData.Name = "sgcbData";
            this.sgcbData.ReadOnly = true;
            this.sgcbData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sgcbData.RowTemplate.Height = 23;
            this.sgcbData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sgcbData.ShowCellToolTips = false;
            this.sgcbData.Size = new System.Drawing.Size(330, 165);
            this.sgcbData.TabIndex = 1;
            // 
            // Key
            // 
            this.Key.HeaderText = "文本";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "值";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Visible = false;
            // 
            // SingleCombox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sgcbData);
            this.Controls.Add(this.sgcbButton);
            this.Name = "SingleCombox";
            this.Size = new System.Drawing.Size(330, 200);
            ((System.ComponentModel.ISupportInitialize)(this.sgcbData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sgcbButton;
        private System.Windows.Forms.DataGridView sgcbData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
