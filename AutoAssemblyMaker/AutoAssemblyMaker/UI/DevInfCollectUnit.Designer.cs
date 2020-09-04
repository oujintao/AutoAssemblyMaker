namespace AutoAssemblyMaker.UI
{
    partial class DevInfCollectUnit
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
            this.baseAddrNameTextBox = new System.Windows.Forms.TextBox();
            this.baseAddrNumTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // baseAddrNameTextBox
            // 
            this.baseAddrNameTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseAddrNameTextBox.Location = new System.Drawing.Point(3, 3);
            this.baseAddrNameTextBox.Name = "baseAddrNameTextBox";
            this.baseAddrNameTextBox.Size = new System.Drawing.Size(154, 26);
            this.baseAddrNameTextBox.TabIndex = 0;
            // 
            // baseAddrNumTextBox
            // 
            this.baseAddrNumTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseAddrNumTextBox.Location = new System.Drawing.Point(163, 3);
            this.baseAddrNumTextBox.Name = "baseAddrNumTextBox";
            this.baseAddrNumTextBox.Size = new System.Drawing.Size(154, 26);
            this.baseAddrNumTextBox.TabIndex = 1;
            // 
            // DevInfCollectUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseAddrNumTextBox);
            this.Controls.Add(this.baseAddrNameTextBox);
            this.Name = "DevInfCollectUnit";
            this.Size = new System.Drawing.Size(320, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox baseAddrNameTextBox;
        private System.Windows.Forms.TextBox baseAddrNumTextBox;
    }
}
