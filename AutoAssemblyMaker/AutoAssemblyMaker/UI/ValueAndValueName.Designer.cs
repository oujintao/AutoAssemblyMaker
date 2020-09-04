namespace AutoAssemblyMaker.UI
{
    partial class ValueAndValueName
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
            this.value = new System.Windows.Forms.TextBox();
            this.valueName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // value
            // 
            this.value.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.value.Location = new System.Drawing.Point(3, 3);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(42, 26);
            this.value.TabIndex = 0;
            // 
            // valueName
            // 
            this.valueName.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.valueName.Location = new System.Drawing.Point(51, 3);
            this.valueName.Name = "valueName";
            this.valueName.Size = new System.Drawing.Size(131, 26);
            this.valueName.TabIndex = 2;
            // 
            // valueAndValueName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueName);
            this.Controls.Add(this.value);
            this.Name = "valueAndValueName";
            this.Size = new System.Drawing.Size(185, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.TextBox valueName;
    }
}
