namespace AutoAssemblyMaker.UI
{
    partial class RegInf
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
            this.label2 = new System.Windows.Forms.Label();
            this.regNameTextBox = new System.Windows.Forms.TextBox();
            this.regAddrTextBox = new System.Windows.Forms.TextBox();
            this.AddBitFiledInfButton = new System.Windows.Forms.Button();
            this.bitFiledShowPanel = new System.Windows.Forms.Panel();
            this.regDelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteSelectedBitFiledInfButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "寄存器名字";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "寄存器偏移地址";
            // 
            // regNameTextBox
            // 
            this.regNameTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regNameTextBox.Location = new System.Drawing.Point(18, 28);
            this.regNameTextBox.Name = "regNameTextBox";
            this.regNameTextBox.Size = new System.Drawing.Size(131, 26);
            this.regNameTextBox.TabIndex = 2;
            // 
            // regAddrTextBox
            // 
            this.regAddrTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regAddrTextBox.Location = new System.Drawing.Point(168, 28);
            this.regAddrTextBox.Name = "regAddrTextBox";
            this.regAddrTextBox.Size = new System.Drawing.Size(131, 26);
            this.regAddrTextBox.TabIndex = 3;
            // 
            // AddBitFiledInfButton
            // 
            this.AddBitFiledInfButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddBitFiledInfButton.Location = new System.Drawing.Point(327, 28);
            this.AddBitFiledInfButton.Name = "AddBitFiledInfButton";
            this.AddBitFiledInfButton.Size = new System.Drawing.Size(130, 26);
            this.AddBitFiledInfButton.TabIndex = 4;
            this.AddBitFiledInfButton.Text = "添加位域信息";
            this.AddBitFiledInfButton.UseVisualStyleBackColor = true;
            this.AddBitFiledInfButton.Click += new System.EventHandler(this.AddBitFiledInfButton_Click);
            // 
            // bitFiledShowPanel
            // 
            this.bitFiledShowPanel.AutoScroll = true;
            this.bitFiledShowPanel.AutoScrollMinSize = new System.Drawing.Size(924, 560);
            this.bitFiledShowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bitFiledShowPanel.Location = new System.Drawing.Point(18, 60);
            this.bitFiledShowPanel.Name = "bitFiledShowPanel";
            this.bitFiledShowPanel.Size = new System.Drawing.Size(980, 560);
            this.bitFiledShowPanel.TabIndex = 5;
            // 
            // regDelectedCheckBox
            // 
            this.regDelectedCheckBox.AutoSize = true;
            this.regDelectedCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regDelectedCheckBox.Location = new System.Drawing.Point(623, 34);
            this.regDelectedCheckBox.Name = "regDelectedCheckBox";
            this.regDelectedCheckBox.Size = new System.Drawing.Size(59, 20);
            this.regDelectedCheckBox.TabIndex = 6;
            this.regDelectedCheckBox.Text = "删除";
            this.regDelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteSelectedBitFiledInfButton
            // 
            this.deleteSelectedBitFiledInfButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteSelectedBitFiledInfButton.Location = new System.Drawing.Point(464, 28);
            this.deleteSelectedBitFiledInfButton.Name = "deleteSelectedBitFiledInfButton";
            this.deleteSelectedBitFiledInfButton.Size = new System.Drawing.Size(153, 26);
            this.deleteSelectedBitFiledInfButton.TabIndex = 7;
            this.deleteSelectedBitFiledInfButton.Text = "删除选中值域信息";
            this.deleteSelectedBitFiledInfButton.UseVisualStyleBackColor = true;
            this.deleteSelectedBitFiledInfButton.Click += new System.EventHandler(this.deleteSelectedBitFiledInfButton_Click);
            // 
            // RegInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.deleteSelectedBitFiledInfButton);
            this.Controls.Add(this.regDelectedCheckBox);
            this.Controls.Add(this.bitFiledShowPanel);
            this.Controls.Add(this.AddBitFiledInfButton);
            this.Controls.Add(this.regAddrTextBox);
            this.Controls.Add(this.regNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegInf";
            this.Size = new System.Drawing.Size(1010, 640);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox regNameTextBox;
        private System.Windows.Forms.TextBox regAddrTextBox;
        private System.Windows.Forms.Button AddBitFiledInfButton;
        private System.Windows.Forms.Panel bitFiledShowPanel;
        private System.Windows.Forms.CheckBox regDelectedCheckBox;
        private System.Windows.Forms.Button deleteSelectedBitFiledInfButton;
    }
}
