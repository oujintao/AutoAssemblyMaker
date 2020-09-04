namespace AutoAssemblyMaker.UI
{
    partial class DevInf
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
            this.label1 = new System.Windows.Forms.Label();
            this.baseAddrNumTextBox = new System.Windows.Forms.TextBox();
            this.baseAddrNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.regInfShowPanel = new System.Windows.Forms.Panel();
            this.addRegButton = new System.Windows.Forms.Button();
            this.deleteSelectedRegButon = new System.Windows.Forms.Button();
            this.devDelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.multipleDevCheckBox = new System.Windows.Forms.CheckBox();
            this.configSameDevBaseAddrButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "外围设备基地址名称";
            // 
            // baseAddrNumTextBox
            // 
            this.baseAddrNumTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseAddrNumTextBox.Location = new System.Drawing.Point(196, 28);
            this.baseAddrNumTextBox.Name = "baseAddrNumTextBox";
            this.baseAddrNumTextBox.Size = new System.Drawing.Size(156, 26);
            this.baseAddrNumTextBox.TabIndex = 1;
            // 
            // baseAddrNameTextBox
            // 
            this.baseAddrNameTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseAddrNameTextBox.Location = new System.Drawing.Point(18, 28);
            this.baseAddrNameTextBox.Name = "baseAddrNameTextBox";
            this.baseAddrNameTextBox.Size = new System.Drawing.Size(156, 26);
            this.baseAddrNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(193, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "外围设备基地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "例：.equ GPIO,0x20000100";
            // 
            // regInfShowPanel
            // 
            this.regInfShowPanel.AutoScroll = true;
            this.regInfShowPanel.AutoScrollMinSize = new System.Drawing.Size(990, 650);
            this.regInfShowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regInfShowPanel.Location = new System.Drawing.Point(18, 76);
            this.regInfShowPanel.Name = "regInfShowPanel";
            this.regInfShowPanel.Size = new System.Drawing.Size(1040, 650);
            this.regInfShowPanel.TabIndex = 5;
            // 
            // addRegButton
            // 
            this.addRegButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addRegButton.Location = new System.Drawing.Point(358, 28);
            this.addRegButton.Name = "addRegButton";
            this.addRegButton.Size = new System.Drawing.Size(104, 26);
            this.addRegButton.TabIndex = 6;
            this.addRegButton.Text = "添加寄存器";
            this.addRegButton.UseVisualStyleBackColor = true;
            this.addRegButton.Click += new System.EventHandler(this.addRegButton_Click);
            // 
            // deleteSelectedRegButon
            // 
            this.deleteSelectedRegButon.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteSelectedRegButon.Location = new System.Drawing.Point(468, 29);
            this.deleteSelectedRegButon.Name = "deleteSelectedRegButon";
            this.deleteSelectedRegButon.Size = new System.Drawing.Size(147, 25);
            this.deleteSelectedRegButon.TabIndex = 7;
            this.deleteSelectedRegButon.Text = "删除选中寄存器";
            this.deleteSelectedRegButon.UseVisualStyleBackColor = true;
            this.deleteSelectedRegButon.Click += new System.EventHandler(this.deleteSelectedRegButon_Click);
            // 
            // devDelectedCheckBox
            // 
            this.devDelectedCheckBox.AutoSize = true;
            this.devDelectedCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.devDelectedCheckBox.Location = new System.Drawing.Point(621, 34);
            this.devDelectedCheckBox.Name = "devDelectedCheckBox";
            this.devDelectedCheckBox.Size = new System.Drawing.Size(59, 20);
            this.devDelectedCheckBox.TabIndex = 8;
            this.devDelectedCheckBox.Text = "删除";
            this.devDelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // multipleDevCheckBox
            // 
            this.multipleDevCheckBox.AutoSize = true;
            this.multipleDevCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multipleDevCheckBox.Location = new System.Drawing.Point(686, 34);
            this.multipleDevCheckBox.Name = "multipleDevCheckBox";
            this.multipleDevCheckBox.Size = new System.Drawing.Size(155, 20);
            this.multipleDevCheckBox.TabIndex = 9;
            this.multipleDevCheckBox.Text = "多个相同类型设备";
            this.multipleDevCheckBox.UseVisualStyleBackColor = true;
            this.multipleDevCheckBox.CheckedChanged += new System.EventHandler(this.multipleDevCheckBox_CheckedChanged);
            // 
            // configSameDevBaseAddrButton
            // 
            this.configSameDevBaseAddrButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.configSameDevBaseAddrButton.Location = new System.Drawing.Point(847, 29);
            this.configSameDevBaseAddrButton.Name = "configSameDevBaseAddrButton";
            this.configSameDevBaseAddrButton.Size = new System.Drawing.Size(167, 25);
            this.configSameDevBaseAddrButton.TabIndex = 10;
            this.configSameDevBaseAddrButton.Text = "配置多个设备基地址";
            this.configSameDevBaseAddrButton.UseVisualStyleBackColor = true;
            this.configSameDevBaseAddrButton.Click += new System.EventHandler(this.configSameDevBaseAddrButton_Click);
            // 
            // DevInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.configSameDevBaseAddrButton);
            this.Controls.Add(this.multipleDevCheckBox);
            this.Controls.Add(this.devDelectedCheckBox);
            this.Controls.Add(this.deleteSelectedRegButon);
            this.Controls.Add(this.addRegButton);
            this.Controls.Add(this.regInfShowPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baseAddrNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.baseAddrNumTextBox);
            this.Controls.Add(this.label1);
            this.Name = "DevInf";
            this.Size = new System.Drawing.Size(1070, 740);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox baseAddrNumTextBox;
        private System.Windows.Forms.TextBox baseAddrNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel regInfShowPanel;
        private System.Windows.Forms.Button addRegButton;
        private System.Windows.Forms.Button deleteSelectedRegButon;
        private System.Windows.Forms.CheckBox devDelectedCheckBox;
        private System.Windows.Forms.CheckBox multipleDevCheckBox;
        private System.Windows.Forms.Button configSameDevBaseAddrButton;
    }
}
