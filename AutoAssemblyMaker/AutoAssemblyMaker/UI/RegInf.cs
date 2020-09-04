using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoAssemblyMaker.抽象层;

namespace AutoAssemblyMaker.UI
{
    public partial class RegInf : UserControl
    {
        /// <summary>
        /// bitFiledInfSet.count
        /// </summary>
        private int bitFiledCount = 0;
        /// <summary>
        /// bitFiledInf的集合
        /// </summary>
        private List<BitFieldInf> bitFiledInfSet = new List<BitFieldInf>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public RegInf()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 得到寄存器名字
        /// </summary>
        /// <returns></returns>
        public string GetRegName() { return regNameTextBox.Text; }
        /// <summary>
        /// 得到寄存器偏移地址
        /// </summary>
        /// <returns></returns>
        public string GetRegNameNum() { return regAddrTextBox.Text; }
        /// <summary>
        /// 得到是否点击了删除复选框
        /// </summary>
        /// <returns></returns>
        public bool GetDeleteTarget() { return regDelectedCheckBox.Checked; }

        /// <summary>
        /// 生成汇编代码，直接调用bitFieldInf的生成函数
        /// </summary>
        /// <param name="toolString"></param>
        /// <param name="baseAddr"></param>
        /// <returns></returns>
        public string GenerateCode_RegInf(ToolString toolString,String baseAddr)
        {
            string resultCode = "";
            for (int i = 0; i < bitFiledInfSet.Count; i++)
            {
                resultCode += bitFiledInfSet[i].GenerateAssemblyCode(toolString,baseAddr,regNameTextBox.Text);
            }
            return resultCode;
        }

        /// <summary>
        /// 添加位域信息的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBitFiledInfButton_Click(object sender, EventArgs e)
        {
            BitFieldInf newBitFiledInf = new BitFieldInf();
            MakeNewRegInfForm(newBitFiledInf, "newReg" + bitFiledCount.ToString());
            bitFiledInfSet.Add(newBitFiledInf);
            newBitFiledInf.Show();
        }

        /// <summary>
        /// 删除选中位域信息的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedBitFiledInfButton_Click(object sender, EventArgs e)
        {
            for (int i = bitFiledInfSet.Count - 1; i >= 0; i--)
            {
                if (bitFiledInfSet[i].GetDeleteTarget())
                {
                    bitFiledInfSet[i].Hide();
                    bitFiledInfSet[i].Dispose();
                    bitFiledInfSet.RemoveAt(i);
                }
            }
            UpdateregInfShowPanel();
        }

        /// <summary>
        /// 重新排版位域信息显示
        /// </summary>
        private void UpdateregInfShowPanel()
        {
            if (bitFiledInfSet.Count != 0)
            {
                bitFiledInfSet[0].Location = new Point(0, 0);
                for (int i = 1; i < bitFiledInfSet.Count; i++)
                {
                    bitFiledInfSet[i].Location = new Point(0, bitFiledInfSet[i - 1].Location.Y + bitFiledInfSet[i - 1].Size.Height);
                }
            }
        }

        /// <summary>
        /// 创建一个新的位域信息控件，并且显示
        /// </summary>
        /// <param name="newBitFiledInf"></param>
        /// <param name="bitFiledInfName"></param>
        private void MakeNewRegInfForm(BitFieldInf newBitFiledInf, string bitFiledInfName)
        {
            this.bitFiledShowPanel.Controls.Add(newBitFiledInf);
            if (bitFiledCount == 0)
            {
                newBitFiledInf.Location = new System.Drawing.Point(0, 0);
            }
            else
            {
                newBitFiledInf.Location = new System.Drawing.Point(0, bitFiledInfSet[bitFiledCount - 1].Location.Y + 190);
            }
            newBitFiledInf.Name = bitFiledInfName;
            bitFiledCount++;
            //bitFiledInfNewLocationY += 190;
        }

        /// <summary>
        /// 保存配置寄存器的标签化信息，这里不解释了，看看运行结果就知道了
        /// </summary>
        /// <returns></returns>
        public string SaveFile_RegInf()
        {
            string saveStr = "";
            saveStr += "\t[regInf]\n";

            if (regNameTextBox.Text == "") saveStr += "\t\tregName=%\n";
            else saveStr += "\t\tregName=" + regNameTextBox.Text + '\n';
            if (regAddrTextBox.Text == "") saveStr += "\t\tregNameAddr=%\n";
            else saveStr += "\t\tregNameAddr=" + regAddrTextBox.Text + '\n';
            for (int i = 0; i < bitFiledInfSet.Count; i++)
            {
                saveStr += bitFiledInfSet[i].SaveFile_BitFiledInf();
            }
            saveStr += "\t[#regInf]\n";
            return saveStr;
        }

        /// <summary>
        /// 读取标签化配置信息，逻辑很简单
        /// </summary>
        /// <param name="fileContent"></param>
        public void ReadFile_RegInf(string fileContent)
        {
            string regInfStr;
            string bitFiledSetStr;

            int bitFiledIndex = 0;
            bitFiledIndex = fileContent.IndexOf("[bitFiled]");

            string[] regInfStrSet;

            if (bitFiledIndex == -1)  //没有位域信息，可以直接走人了
            {
                regInfStrSet = fileContent.Split('\n');

                regInfStr = GetValueInFileString(regInfStrSet[0]);
                if(regInfStr == "%") regNameTextBox.Text = "";
                else regNameTextBox.Text = regInfStr;

                regInfStr = GetValueInFileString(regInfStrSet[1]);
                if (regInfStr == "%") regAddrTextBox.Text = "";
                else regAddrTextBox.Text = regInfStr;

                return;
            }

            regInfStr = fileContent.Substring(0,bitFiledIndex - 3);
            regInfStrSet = regInfStr.Split('\n');

            regInfStr = GetValueInFileString(regInfStrSet[0]);
            if (regInfStr == "%") regNameTextBox.Text = "";
            else regNameTextBox.Text = regInfStr;

            regInfStr = GetValueInFileString(regInfStrSet[1]);
            if (regInfStr == "%") regAddrTextBox.Text = "";
            else regAddrTextBox.Text = regInfStr;

            bitFiledSetStr = fileContent.Substring(bitFiledIndex);

            for (int i = 0; i < bitFiledInfSet.Count; i++)
            {
                bitFiledInfSet[i].Hide();
                bitFiledInfSet[i].Dispose();
            }
            bitFiledInfSet.Clear();
            int bitFiledLabelStartIndex = 0;
            int bitFiledLabelEndIndex = bitFiledSetStr.IndexOf("[#bitFiled]");
            while (true)
            {
                BitFieldInf newBitFiledInf = new BitFieldInf();
                MakeNewRegInfForm(newBitFiledInf, "newBitFiled" + bitFiledInfSet.Count);
                newBitFiledInf.ReadFile_BitFiledInf(bitFiledSetStr.Substring(bitFiledLabelStartIndex + 11, bitFiledLabelEndIndex - bitFiledLabelStartIndex - 3 - 11));

                bitFiledLabelStartIndex = bitFiledSetStr.IndexOf("[bitFiled]", bitFiledLabelEndIndex + 1);
                bitFiledInfSet.Add(newBitFiledInf);

                if (bitFiledLabelStartIndex == -1)
                {
                    break;
                }
                bitFiledLabelEndIndex = bitFiledSetStr.IndexOf("[#bitFiled]", bitFiledLabelStartIndex);
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
