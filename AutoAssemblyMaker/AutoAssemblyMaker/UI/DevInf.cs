using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoAssemblyMaker.抽象层;

namespace AutoAssemblyMaker.UI
{
    public partial class DevInf : UserControl
    {
        /// <summary>
        /// regInfSet.count 的影子变量
        /// </summary>
        private int regInfCount = 0;
        /// <summary>
        /// regInf的集合
        /// </summary>
        private List<RegInf> regInfSet = new List<RegInf>();
        /// <summary>
        /// 相同类型的设备的填写表
        /// </summary>
        private SameDevBaseAddrTable sameDevBaseAddrTable = new SameDevBaseAddrTable();

        /// <summary>
        /// 构建函数
        /// </summary>
        public DevInf()
        {
            InitializeComponent();
            multipleDevCheckBox.Checked = false;  //默认没有相同类型的设备，只有一个
            configSameDevBaseAddrButton.Enabled = false; //多个相同类型填写表弹出按钮不可使用
        }
        
        /// <summary>
        /// 构造函数，用于AAMControl的一开始弹出的对话框填写的信息写到DevInf的前两个文本框
        /// </summary>
        /// <param name="baseAddrName"></param>
        /// <param name="baseAddrNum"></param>
        public DevInf(string  baseAddrName,string baseAddrNum)
        {
            InitializeComponent();
            baseAddrNameTextBox.Text = baseAddrName;
            baseAddrNumTextBox.Text = baseAddrNum;
            multipleDevCheckBox.Checked = false;
            configSameDevBaseAddrButton.Enabled = false;
        }

        /// <summary>
        /// DevInf生成汇编代码调用的函数，这是层层嵌套到，devInf提供的是外围设备的基地址和外围设备的名字，结合UI就可以知道了
        /// </summary>
        /// <param name="toolString"></param>
        /// <returns></returns>
        public string GenerateCode_DevInf(ToolString toolString)
        {
            string resultCode = "";

            //这是用来生成.equ PWM0,0x20001000的这里伪指令的
            List<string> baseAddrSet = new List<string>();
            List<string> baseAddrNumSet = new List<string>();
            List<string> regNameSet = new List<string>();
            List<string> regNameNumSet = new List<string>();

            if(multipleDevCheckBox.Checked)  //多个相同类型的设备
            {
                for (int i = 0; i < sameDevBaseAddrTable.devBaseAddrNameSet.Count; i++)
                {
                    baseAddrSet.Add(sameDevBaseAddrTable.devBaseAddrNameSet[i]);
                    baseAddrNumSet.Add(sameDevBaseAddrTable.devBaseAddrNumSet[i]);
                }
            }
            else
            {
                baseAddrSet.Add(baseAddrNameTextBox.Text);  //就是开头那两个文本框就是设备名字
                baseAddrNumSet.Add(baseAddrNumTextBox.Text);
            }
            for (int i = 0; i < regInfSet.Count; i++)  //寄存器和寄存器的偏移地址很好获取
            {
                regNameSet.Add(regInfSet[i].GetRegName());
                regNameNumSet.Add(regInfSet[i].GetRegNameNum());
            }
            //生成伪指令.equ
            resultCode += toolString.GeneratePseudoIR(baseAddrSet, baseAddrNumSet, regNameSet, regNameNumSet) + "\n\n";


            if (multipleDevCheckBox.Checked)
            {
                for (int i = 0; i < sameDevBaseAddrTable.devBaseAddrNameSet.Count; i++)  //多了这个循环，就是其他相同类型设备生成而已
                {
                    for (int j = 0; j < regInfSet.Count; j++)
                    {
                        resultCode += regInfSet[j].GenerateCode_RegInf(toolString, sameDevBaseAddrTable.devBaseAddrNameSet[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < regInfSet.Count; i++)
                {
                    resultCode += regInfSet[i].GenerateCode_RegInf(toolString, baseAddrNameTextBox.Text);
                }
            }
            return resultCode;
        }

        /// <summary>
        /// 添加寄存器的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRegButton_Click(object sender, EventArgs e)
        {
            RegInf newRegInf = new RegInf();
            MakeNewRegInfForm(newRegInf,"newReg"+ regInfCount.ToString());
            regInfSet.Add(newRegInf);
            newRegInf.Show();
        }

        /// <summary>
        /// 删除寄存器按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedRegButon_Click(object sender, EventArgs e)
        {
            for (int i = regInfSet.Count - 1; i >= 0; i--)
            {
                if (regInfSet[i].GetDeleteTarget())  //有没有勾选删除复选框，在CheckBox
                {
                    regInfSet[i].Hide();
                    regInfSet[i].Dispose();
                    regInfSet.RemoveAt(i);
                }
            }
            UpdateregInfShowPanel();
        }

        /// <summary>
        /// 删除之后regInf，重新排版regInf
        /// </summary>
        private void UpdateregInfShowPanel()
        {
            if (regInfSet.Count != 0)
            {
                regInfSet[0].Location = new Point(0, 0);
                for (int i = 1; i < regInfSet.Count; i++)
                {
                    regInfSet[i].Location = new Point(0, regInfSet[i - 1].Location.Y + regInfSet[i - 1].Size.Height);
                }
            }
        }

        /// <summary>
        /// 创建新的regInf显示控件，并且排版
        /// </summary>
        /// <param name="newRegInf"></param>
        /// <param name="regInfName"></param>
        private void MakeNewRegInfForm(RegInf newRegInf, string regInfName)
        {
            this.regInfShowPanel.Controls.Add(newRegInf);
            if (regInfCount == 0)
            {
                newRegInf.Location = new System.Drawing.Point(0, 0);
            }
            else
            {
                newRegInf.Location = new System.Drawing.Point(0, regInfSet[regInfCount - 1].Location.Y + 640);  //640是一个regInf的高度，其实也可以直接读取，但是没必要
            }
            newRegInf.Name = regInfName;
            regInfCount++;
        }

        /// <summary>
        /// 多个设备的复选框变化的时候，其他文本框和按钮也要对应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void multipleDevCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            configSameDevBaseAddrButton.Enabled = multipleDevCheckBox.Checked;
            baseAddrNameTextBox.Enabled = !multipleDevCheckBox.Checked;
            baseAddrNumTextBox.Enabled = !multipleDevCheckBox.Checked;
        }

        /// <summary>
        /// 配置多个设备窗口弹出按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configSameDevBaseAddrButton_Click(object sender, EventArgs e)
        {
            sameDevBaseAddrTable.Show();
        }

        /// <summary>
        /// 返回这个设备信息标签化文本，不做解释了，直接运行看看结果就知道了
        /// </summary>
        /// <returns></returns>
        public string SaveFile_DevInf()
        {
            string saveStr = "";
            saveStr += "[devInf]\n";
            saveStr += "\tcheckBox=" + multipleDevCheckBox.Checked.ToString() + "\n";

            saveStr += "\tbaseAddr=" + (baseAddrNameTextBox.Text == "" ? "%" : baseAddrNameTextBox.Text) + "\n";
            saveStr += "\tbaseAddrName=" + (baseAddrNumTextBox.Text == "" ? "%" : baseAddrNumTextBox.Text) + "\n";

            if (multipleDevCheckBox.Checked)
            {
                for (int i = 0; i < sameDevBaseAddrTable.devBaseAddrNameSet.Count; i++)
                {
                    saveStr += "\tbaseAddr=" + (sameDevBaseAddrTable.devBaseAddrNameSet[i] == "" ? "%" : sameDevBaseAddrTable.devBaseAddrNameSet[i]) + "\n";
                    saveStr += "\tbaseAddrName=" + (sameDevBaseAddrTable.devBaseAddrNumSet[i] == "" ? "%" : sameDevBaseAddrTable.devBaseAddrNumSet[i]) + "\n";
                }
            }

            for (int i = 0; i < regInfSet.Count; i++)
            {
                saveStr += regInfSet[i].SaveFile_RegInf();
            }
            saveStr += "[#devInf]\n";
            return saveStr;
        }

        /// <summary>
        /// 读取，分析这个设备信息标签化文本，不做解释了，直接运行看看结果就知道了
        /// </summary>
        /// <param name="fileContent"></param>
        public void ReadFile_DevInf(string fileContent)
        {
            string devInfStr;
            string regInfSetStr;

            int regInfIndex = 0;
            regInfIndex = fileContent.IndexOf("[regInf]");
            string[] regInfStrSet;

            if(regInfIndex == -1)
            {
                regInfStrSet = fileContent.Split('\n');

                devInfStr = GetValueInFileString(regInfStrSet[0]);
                multipleDevCheckBox.Checked = (devInfStr == "True");

                if(multipleDevCheckBox.Checked)
                {
                    baseAddrNameTextBox.Enabled = false;
                    baseAddrNumTextBox.Enabled = false;
                    configSameDevBaseAddrButton.Enabled = true;
                }
                else
                {
                    baseAddrNameTextBox.Enabled = true;
                    baseAddrNumTextBox.Enabled = true;
                    configSameDevBaseAddrButton.Enabled = false;
                }

                devInfStr = GetValueInFileString(regInfStrSet[1]);
                baseAddrNameTextBox.Text = (devInfStr == "%" ? "" : devInfStr);

                devInfStr = GetValueInFileString(regInfStrSet[2]);
                baseAddrNumTextBox.Text = (devInfStr == "%" ? "" : devInfStr);

                if (multipleDevCheckBox.Checked)
                {
                    sameDevBaseAddrTable.ReadFile_SameDevBaseAddrTable(regInfStrSet);
                }
                return;
            }

            devInfStr = fileContent.Substring(0,regInfIndex - 2);
            regInfStrSet = devInfStr.Split('\n');

            devInfStr = GetValueInFileString(regInfStrSet[0]);
            multipleDevCheckBox.Checked = (devInfStr == "True");

            if (multipleDevCheckBox.Checked)
            {
                baseAddrNameTextBox.Enabled = false;
                baseAddrNumTextBox.Enabled = false;
                configSameDevBaseAddrButton.Enabled = true;
            }
            else
            {
                baseAddrNameTextBox.Enabled = true;
                baseAddrNumTextBox.Enabled = true;
                configSameDevBaseAddrButton.Enabled = false;
            }

            devInfStr = GetValueInFileString(regInfStrSet[1]);
            baseAddrNameTextBox.Text = (devInfStr == "%" ? "" : devInfStr);

            devInfStr = GetValueInFileString(regInfStrSet[2]);
            baseAddrNumTextBox.Text = (devInfStr == "%" ? "" : devInfStr);

            if (multipleDevCheckBox.Checked)
            {
                sameDevBaseAddrTable.ReadFile_SameDevBaseAddrTable(regInfStrSet);
            }

            regInfSetStr = fileContent.Substring(regInfIndex);

            for (int i = 0; i < regInfSet.Count; i++)
            {
                regInfSet[i].Hide();
                regInfSet[i].Dispose();
            }
            regInfSet.Clear();
            int regNameLabelStartIndex = 0;
            int regNameLabelEndIndex = regInfSetStr.IndexOf("[#regInf]");
            while (true)
            {
                RegInf newRegInf = new RegInf();
                MakeNewRegInfForm(newRegInf, "newReg" + regInfSet.Count);
                newRegInf.ReadFile_RegInf(regInfSetStr.Substring(regNameLabelStartIndex + 10, regNameLabelEndIndex - regNameLabelStartIndex - 2 - 10));

                regNameLabelStartIndex = regInfSetStr.IndexOf("[regInf]", regNameLabelEndIndex + 2);
                regInfSet.Add(newRegInf);

                if (regNameLabelStartIndex == -1)
                {
                    break;
                }
                regNameLabelEndIndex = regInfSetStr.IndexOf("[#regInf]", regNameLabelStartIndex);
            }
        }

        /// <summary>
        /// 得到=之后的内容
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        private string GetValueInFileString(string fileContent)
        {
            return fileContent.Substring(fileContent.IndexOf('=') + 1);
        }
    }
}
