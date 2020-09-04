namespace AutoAssemblyMaker.UI
{
    partial class AAMControl
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
            this.selectedDevCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.addNewDevButton = new System.Windows.Forms.Button();
            this.readFileButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.DeleteSelectedDevButton = new System.Windows.Forms.Button();
            this.showRadioButtonPanel = new System.Windows.Forms.Panel();
            this.GenerateCodeButton = new System.Windows.Forms.Button();
            this.generateCodeDirSelectbutton = new System.Windows.Forms.Button();
            this.readFileDirSetButton = new System.Windows.Forms.Button();
            this.saveFileDirSetbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectedDevCheckedListBox
            // 
            this.selectedDevCheckedListBox.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectedDevCheckedListBox.FormattingEnabled = true;
            this.selectedDevCheckedListBox.Location = new System.Drawing.Point(558, 12);
            this.selectedDevCheckedListBox.Name = "selectedDevCheckedListBox";
            this.selectedDevCheckedListBox.Size = new System.Drawing.Size(200, 88);
            this.selectedDevCheckedListBox.TabIndex = 0;
            // 
            // addNewDevButton
            // 
            this.addNewDevButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addNewDevButton.Location = new System.Drawing.Point(12, 12);
            this.addNewDevButton.Name = "addNewDevButton";
            this.addNewDevButton.Size = new System.Drawing.Size(124, 30);
            this.addNewDevButton.TabIndex = 1;
            this.addNewDevButton.Text = "新增外围设备";
            this.addNewDevButton.UseVisualStyleBackColor = true;
            this.addNewDevButton.Click += new System.EventHandler(this.addNewDevButton_Click);
            // 
            // readFileButton
            // 
            this.readFileButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readFileButton.Location = new System.Drawing.Point(142, 13);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(124, 30);
            this.readFileButton.TabIndex = 2;
            this.readFileButton.Text = "读取文件";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.readFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveFileButton.Location = new System.Drawing.Point(272, 12);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(124, 30);
            this.saveFileButton.TabIndex = 3;
            this.saveFileButton.Text = "保存文件";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // DeleteSelectedDevButton
            // 
            this.DeleteSelectedDevButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteSelectedDevButton.Location = new System.Drawing.Point(402, 12);
            this.DeleteSelectedDevButton.Name = "DeleteSelectedDevButton";
            this.DeleteSelectedDevButton.Size = new System.Drawing.Size(150, 30);
            this.DeleteSelectedDevButton.TabIndex = 4;
            this.DeleteSelectedDevButton.Text = "删除选中外围设备";
            this.DeleteSelectedDevButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedDevButton.Click += new System.EventHandler(this.DeleteSelectedDevButton_Click);
            // 
            // showRadioButtonPanel
            // 
            this.showRadioButtonPanel.AutoScroll = true;
            this.showRadioButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showRadioButtonPanel.Location = new System.Drawing.Point(765, 13);
            this.showRadioButtonPanel.Name = "showRadioButtonPanel";
            this.showRadioButtonPanel.Size = new System.Drawing.Size(193, 87);
            this.showRadioButtonPanel.TabIndex = 5;
            // 
            // GenerateCodeButton
            // 
            this.GenerateCodeButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenerateCodeButton.Location = new System.Drawing.Point(964, 13);
            this.GenerateCodeButton.Name = "GenerateCodeButton";
            this.GenerateCodeButton.Size = new System.Drawing.Size(107, 30);
            this.GenerateCodeButton.TabIndex = 6;
            this.GenerateCodeButton.Text = "生成代码";
            this.GenerateCodeButton.UseVisualStyleBackColor = true;
            this.GenerateCodeButton.Click += new System.EventHandler(this.GenerateCodeButton_Click);
            // 
            // generateCodeDirSelectbutton
            // 
            this.generateCodeDirSelectbutton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.generateCodeDirSelectbutton.Location = new System.Drawing.Point(402, 48);
            this.generateCodeDirSelectbutton.Name = "generateCodeDirSelectbutton";
            this.generateCodeDirSelectbutton.Size = new System.Drawing.Size(150, 29);
            this.generateCodeDirSelectbutton.TabIndex = 7;
            this.generateCodeDirSelectbutton.Text = "代码生成目录设置";
            this.generateCodeDirSelectbutton.UseVisualStyleBackColor = true;
            this.generateCodeDirSelectbutton.Click += new System.EventHandler(this.generateCodeDirSelectbutton_Click);
            // 
            // readFileDirSetButton
            // 
            this.readFileDirSetButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readFileDirSetButton.Location = new System.Drawing.Point(142, 47);
            this.readFileDirSetButton.Name = "readFileDirSetButton";
            this.readFileDirSetButton.Size = new System.Drawing.Size(124, 30);
            this.readFileDirSetButton.TabIndex = 8;
            this.readFileDirSetButton.Text = "读取路径设置";
            this.readFileDirSetButton.UseVisualStyleBackColor = true;
            this.readFileDirSetButton.Click += new System.EventHandler(this.readFileDirSetButton_Click);
            // 
            // saveFileDirSetbutton
            // 
            this.saveFileDirSetbutton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveFileDirSetbutton.Location = new System.Drawing.Point(272, 47);
            this.saveFileDirSetbutton.Name = "saveFileDirSetbutton";
            this.saveFileDirSetbutton.Size = new System.Drawing.Size(124, 30);
            this.saveFileDirSetbutton.TabIndex = 9;
            this.saveFileDirSetbutton.Text = "另存为";
            this.saveFileDirSetbutton.UseVisualStyleBackColor = true;
            this.saveFileDirSetbutton.Click += new System.EventHandler(this.saveFileDirSetbutton_Click);
            // 
            // AAMControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1104, 961);
            this.Controls.Add(this.saveFileDirSetbutton);
            this.Controls.Add(this.readFileDirSetButton);
            this.Controls.Add(this.generateCodeDirSelectbutton);
            this.Controls.Add(this.GenerateCodeButton);
            this.Controls.Add(this.showRadioButtonPanel);
            this.Controls.Add(this.DeleteSelectedDevButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.readFileButton);
            this.Controls.Add(this.addNewDevButton);
            this.Controls.Add(this.selectedDevCheckedListBox);
            this.Name = "AAMControl";
            this.Text = "AAMControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox selectedDevCheckedListBox;
        private System.Windows.Forms.Button addNewDevButton;
        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button DeleteSelectedDevButton;
        private System.Windows.Forms.Panel showRadioButtonPanel;
        private System.Windows.Forms.Button GenerateCodeButton;
        private System.Windows.Forms.Button generateCodeDirSelectbutton;
        private System.Windows.Forms.Button readFileDirSetButton;
        private System.Windows.Forms.Button saveFileDirSetbutton;
    }
}