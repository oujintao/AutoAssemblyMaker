namespace AutoAssemblyMaker.UI
{
    partial class BitFieldInf
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
            this.enableTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.setValueRadioButton = new System.Windows.Forms.RadioButton();
            this.setModeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bitNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.highLowBitTextBox = new System.Windows.Forms.TextBox();
            this.TypeSelectPanel = new System.Windows.Forms.Panel();
            this.stackSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.defineSomeValueCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.writeAndReadRadioButton = new System.Windows.Forms.RadioButton();
            this.writeRadioButton = new System.Windows.Forms.RadioButton();
            this.readRadioButton = new System.Windows.Forms.RadioButton();
            this.tipLabel = new System.Windows.Forms.Label();
            this.bitFiledDelectedcheckBox = new System.Windows.Forms.CheckBox();
            this.seizeCheckBox = new System.Windows.Forms.CheckBox();
            this.localScopeTextBox = new System.Windows.Forms.TextBox();
            this.valueAndValueNameInfPanel = new System.Windows.Forms.Panel();
            this.modeSingleCheckBox = new System.Windows.Forms.CheckBox();
            this.addValueAndValueNameButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.localScopeCheckBox = new System.Windows.Forms.CheckBox();
            this.TypeSelectPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableTypeRadioButton
            // 
            this.enableTypeRadioButton.AutoSize = true;
            this.enableTypeRadioButton.Checked = true;
            this.enableTypeRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enableTypeRadioButton.Location = new System.Drawing.Point(3, 3);
            this.enableTypeRadioButton.Name = "enableTypeRadioButton";
            this.enableTypeRadioButton.Size = new System.Drawing.Size(74, 20);
            this.enableTypeRadioButton.TabIndex = 0;
            this.enableTypeRadioButton.TabStop = true;
            this.enableTypeRadioButton.Text = "使能位";
            this.enableTypeRadioButton.UseVisualStyleBackColor = true;
            this.enableTypeRadioButton.CheckedChanged += new System.EventHandler(this.enableTypeRadioButton_CheckedChanged);
            // 
            // setValueRadioButton
            // 
            this.setValueRadioButton.AutoSize = true;
            this.setValueRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setValueRadioButton.Location = new System.Drawing.Point(3, 29);
            this.setValueRadioButton.Name = "setValueRadioButton";
            this.setValueRadioButton.Size = new System.Drawing.Size(122, 20);
            this.setValueRadioButton.TabIndex = 1;
            this.setValueRadioButton.Text = "设置数值位域";
            this.setValueRadioButton.UseVisualStyleBackColor = true;
            this.setValueRadioButton.CheckedChanged += new System.EventHandler(this.setValueRadioButton_CheckedChanged);
            // 
            // setModeRadioButton
            // 
            this.setModeRadioButton.AutoSize = true;
            this.setModeRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setModeRadioButton.Location = new System.Drawing.Point(3, 55);
            this.setModeRadioButton.Name = "setModeRadioButton";
            this.setModeRadioButton.Size = new System.Drawing.Size(122, 20);
            this.setModeRadioButton.TabIndex = 2;
            this.setModeRadioButton.Text = "设置模式位域";
            this.setModeRadioButton.UseVisualStyleBackColor = true;
            this.setModeRadioButton.CheckedChanged += new System.EventHandler(this.setModeRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入位（位域）名字";
            // 
            // bitNameTextBox
            // 
            this.bitNameTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bitNameTextBox.Location = new System.Drawing.Point(18, 29);
            this.bitNameTextBox.Name = "bitNameTextBox";
            this.bitNameTextBox.Size = new System.Drawing.Size(160, 26);
            this.bitNameTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(204, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "所占位的范围（例：31-28）";
            // 
            // highLowBitTextBox
            // 
            this.highLowBitTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.highLowBitTextBox.Location = new System.Drawing.Point(207, 29);
            this.highLowBitTextBox.Name = "highLowBitTextBox";
            this.highLowBitTextBox.Size = new System.Drawing.Size(205, 26);
            this.highLowBitTextBox.TabIndex = 6;
            // 
            // TypeSelectPanel
            // 
            this.TypeSelectPanel.Controls.Add(this.enableTypeRadioButton);
            this.TypeSelectPanel.Controls.Add(this.setValueRadioButton);
            this.TypeSelectPanel.Controls.Add(this.setModeRadioButton);
            this.TypeSelectPanel.Location = new System.Drawing.Point(16, 89);
            this.TypeSelectPanel.Name = "TypeSelectPanel";
            this.TypeSelectPanel.Size = new System.Drawing.Size(130, 82);
            this.TypeSelectPanel.TabIndex = 7;
            // 
            // stackSaveCheckBox
            // 
            this.stackSaveCheckBox.AutoSize = true;
            this.stackSaveCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stackSaveCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stackSaveCheckBox.Location = new System.Drawing.Point(553, 35);
            this.stackSaveCheckBox.Name = "stackSaveCheckBox";
            this.stackSaveCheckBox.Size = new System.Drawing.Size(203, 20);
            this.stackSaveCheckBox.TabIndex = 10;
            this.stackSaveCheckBox.Text = "要有堆栈保护临时寄存器";
            this.stackSaveCheckBox.UseVisualStyleBackColor = true;
            this.stackSaveCheckBox.CheckedChanged += new System.EventHandler(this.stackSaveCheckBox_CheckedChanged);
            // 
            // defineSomeValueCheckBox
            // 
            this.defineSomeValueCheckBox.AutoSize = true;
            this.defineSomeValueCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.defineSomeValueCheckBox.Location = new System.Drawing.Point(753, 34);
            this.defineSomeValueCheckBox.Name = "defineSomeValueCheckBox";
            this.defineSomeValueCheckBox.Size = new System.Drawing.Size(187, 20);
            this.defineSomeValueCheckBox.TabIndex = 11;
            this.defineSomeValueCheckBox.Text = "产生参数对应的宏定义";
            this.defineSomeValueCheckBox.UseVisualStyleBackColor = true;
            this.defineSomeValueCheckBox.CheckedChanged += new System.EventHandler(this.defineSomeValueCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.writeAndReadRadioButton);
            this.panel1.Controls.Add(this.writeRadioButton);
            this.panel1.Controls.Add(this.readRadioButton);
            this.panel1.Location = new System.Drawing.Point(152, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 82);
            this.panel1.TabIndex = 12;
            // 
            // writeAndReadRadioButton
            // 
            this.writeAndReadRadioButton.AutoSize = true;
            this.writeAndReadRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.writeAndReadRadioButton.Location = new System.Drawing.Point(3, 55);
            this.writeAndReadRadioButton.Name = "writeAndReadRadioButton";
            this.writeAndReadRadioButton.Size = new System.Drawing.Size(122, 20);
            this.writeAndReadRadioButton.TabIndex = 16;
            this.writeAndReadRadioButton.TabStop = true;
            this.writeAndReadRadioButton.Text = "读取和写入值";
            this.writeAndReadRadioButton.UseVisualStyleBackColor = true;
            this.writeAndReadRadioButton.CheckedChanged += new System.EventHandler(this.writeAndReadRadioButton_CheckedChanged);
            // 
            // writeRadioButton
            // 
            this.writeRadioButton.AutoSize = true;
            this.writeRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.writeRadioButton.Location = new System.Drawing.Point(3, 29);
            this.writeRadioButton.Name = "writeRadioButton";
            this.writeRadioButton.Size = new System.Drawing.Size(74, 20);
            this.writeRadioButton.TabIndex = 15;
            this.writeRadioButton.TabStop = true;
            this.writeRadioButton.Text = "写入值";
            this.writeRadioButton.UseVisualStyleBackColor = true;
            this.writeRadioButton.CheckedChanged += new System.EventHandler(this.writeRadioButton_CheckedChanged);
            // 
            // readRadioButton
            // 
            this.readRadioButton.AutoSize = true;
            this.readRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readRadioButton.Location = new System.Drawing.Point(3, 7);
            this.readRadioButton.Name = "readRadioButton";
            this.readRadioButton.Size = new System.Drawing.Size(74, 20);
            this.readRadioButton.TabIndex = 14;
            this.readRadioButton.TabStop = true;
            this.readRadioButton.Text = "读取值";
            this.readRadioButton.UseVisualStyleBackColor = true;
            this.readRadioButton.CheckedChanged += new System.EventHandler(this.readRadioButton_CheckedChanged);
            // 
            // tipLabel
            // 
            this.tipLabel.AutoSize = true;
            this.tipLabel.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipLabel.Location = new System.Drawing.Point(285, 70);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(464, 16);
            this.tipLabel.TabIndex = 14;
            this.tipLabel.Text = "有效值和有效值的名称（可不填名称）（例：1 always 或者 1）";
            // 
            // bitFiledDelectedcheckBox
            // 
            this.bitFiledDelectedcheckBox.AutoSize = true;
            this.bitFiledDelectedcheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bitFiledDelectedcheckBox.Location = new System.Drawing.Point(18, 62);
            this.bitFiledDelectedcheckBox.Name = "bitFiledDelectedcheckBox";
            this.bitFiledDelectedcheckBox.Size = new System.Drawing.Size(59, 20);
            this.bitFiledDelectedcheckBox.TabIndex = 15;
            this.bitFiledDelectedcheckBox.Text = "删除";
            this.bitFiledDelectedcheckBox.UseVisualStyleBackColor = true;
            // 
            // seizeCheckBox
            // 
            this.seizeCheckBox.AutoSize = true;
            this.seizeCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.seizeCheckBox.Location = new System.Drawing.Point(418, 35);
            this.seizeCheckBox.Name = "seizeCheckBox";
            this.seizeCheckBox.Size = new System.Drawing.Size(139, 20);
            this.seizeCheckBox.TabIndex = 9;
            this.seizeCheckBox.Text = "独占整个寄存器";
            this.seizeCheckBox.UseVisualStyleBackColor = true;
            this.seizeCheckBox.CheckedChanged += new System.EventHandler(this.seizeCheckBox_CheckedChanged);
            // 
            // localScopeTextBox
            // 
            this.localScopeTextBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localScopeTextBox.Location = new System.Drawing.Point(288, 89);
            this.localScopeTextBox.Name = "localScopeTextBox";
            this.localScopeTextBox.Size = new System.Drawing.Size(100, 26);
            this.localScopeTextBox.TabIndex = 18;
            // 
            // valueAndValueNameInfPanel
            // 
            this.valueAndValueNameInfPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valueAndValueNameInfPanel.Location = new System.Drawing.Point(288, 89);
            this.valueAndValueNameInfPanel.Name = "valueAndValueNameInfPanel";
            this.valueAndValueNameInfPanel.Size = new System.Drawing.Size(571, 82);
            this.valueAndValueNameInfPanel.TabIndex = 19;
            // 
            // modeSingleCheckBox
            // 
            this.modeSingleCheckBox.AutoSize = true;
            this.modeSingleCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modeSingleCheckBox.Location = new System.Drawing.Point(845, 69);
            this.modeSingleCheckBox.Name = "modeSingleCheckBox";
            this.modeSingleCheckBox.Size = new System.Drawing.Size(91, 20);
            this.modeSingleCheckBox.TabIndex = 23;
            this.modeSingleCheckBox.Text = "单独函数";
            this.modeSingleCheckBox.UseVisualStyleBackColor = true;
            this.modeSingleCheckBox.CheckedChanged += new System.EventHandler(this.modeSingleCheckBox_CheckedChanged);
            // 
            // addValueAndValueNameButton
            // 
            this.addValueAndValueNameButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addValueAndValueNameButton.Location = new System.Drawing.Point(861, 89);
            this.addValueAndValueNameButton.Name = "addValueAndValueNameButton";
            this.addValueAndValueNameButton.Size = new System.Drawing.Size(75, 27);
            this.addValueAndValueNameButton.TabIndex = 20;
            this.addValueAndValueNameButton.Text = "添加";
            this.addValueAndValueNameButton.UseVisualStyleBackColor = true;
            this.addValueAndValueNameButton.Click += new System.EventHandler(this.addValueAndValueNameButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteButton.Location = new System.Drawing.Point(861, 122);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 27);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // localScopeCheckBox
            // 
            this.localScopeCheckBox.AutoSize = true;
            this.localScopeCheckBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localScopeCheckBox.Location = new System.Drawing.Point(845, 69);
            this.localScopeCheckBox.Name = "localScopeCheckBox";
            this.localScopeCheckBox.Size = new System.Drawing.Size(91, 20);
            this.localScopeCheckBox.TabIndex = 22;
            this.localScopeCheckBox.Text = "局部范围";
            this.localScopeCheckBox.UseVisualStyleBackColor = true;
            this.localScopeCheckBox.CheckedChanged += new System.EventHandler(this.localScopeCheckBox_CheckedChanged);
            // 
            // BitFieldInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.modeSingleCheckBox);
            this.Controls.Add(this.localScopeCheckBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addValueAndValueNameButton);
            this.Controls.Add(this.valueAndValueNameInfPanel);
            this.Controls.Add(this.localScopeTextBox);
            this.Controls.Add(this.bitFiledDelectedcheckBox);
            this.Controls.Add(this.tipLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.defineSomeValueCheckBox);
            this.Controls.Add(this.stackSaveCheckBox);
            this.Controls.Add(this.seizeCheckBox);
            this.Controls.Add(this.TypeSelectPanel);
            this.Controls.Add(this.highLowBitTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bitNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "BitFieldInf";
            this.Size = new System.Drawing.Size(953, 183);
            this.TypeSelectPanel.ResumeLayout(false);
            this.TypeSelectPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton enableTypeRadioButton;
        private System.Windows.Forms.RadioButton setValueRadioButton;
        private System.Windows.Forms.RadioButton setModeRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bitNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox highLowBitTextBox;
        private System.Windows.Forms.Panel TypeSelectPanel;
        private System.Windows.Forms.CheckBox stackSaveCheckBox;
        private System.Windows.Forms.CheckBox defineSomeValueCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton writeAndReadRadioButton;
        private System.Windows.Forms.RadioButton writeRadioButton;
        private System.Windows.Forms.RadioButton readRadioButton;
        private System.Windows.Forms.Label tipLabel;
        private System.Windows.Forms.CheckBox bitFiledDelectedcheckBox;
        private System.Windows.Forms.CheckBox seizeCheckBox;
        private System.Windows.Forms.TextBox localScopeTextBox;
        private System.Windows.Forms.Panel valueAndValueNameInfPanel;
        private System.Windows.Forms.Button addValueAndValueNameButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox modeSingleCheckBox;
        private System.Windows.Forms.CheckBox localScopeCheckBox;
    }
}
