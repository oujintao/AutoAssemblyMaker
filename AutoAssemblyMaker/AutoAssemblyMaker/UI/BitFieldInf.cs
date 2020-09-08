using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoAssemblyMaker.抽象层;

namespace AutoAssemblyMaker.UI
{
    public partial class BitFieldInf : UserControl
    {
        /// <summary>
        /// 这是和抽象层的边界了，这个控件的信息就是对应funcMould的变量
        /// </summary>
        private FuncMould funcMould = new FuncMould();
        /// <summary>
        /// 设置模式下，模式和模式的名字的集合，一个自定义UI
        /// </summary>
        private List<ValueAndValueName> valueAndValueNameSet = new List<ValueAndValueName>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public BitFieldInf()
        {
            InitializeComponent();
            enableTypeRadioButton.Checked = true;
            funcMould.SetType(0);
            writeRadioButton.Checked = true;
            funcMould.SetWriteOrRead(0);
            funcMould.SetSetValueLocalScope(false);
            funcMould.SetModeSingleType(false);

            localScopeCheckBox.Checked = false;
            modeSingleCheckBox.Checked = false;

            DisableSetValueUI();
            DisableSetModeUI();
        }

        /// <summary>
        /// 得到是够被选中删除
        /// </summary>
        /// <returns></returns>
        public bool GetDeleteTarget() { return bitFiledDelectedcheckBox.Checked; }

        /// <summary>
        /// 生成汇编代码
        /// </summary>
        /// <param name="toolString"></param>
        /// <param name="baseName"></param>
        /// <param name="regName"></param>
        /// <returns></returns>
        public string GenerateAssemblyCode(ToolString toolString, string baseName, string regName,bool multipDevInfTarget)
        {
            string resultCode = "";
            if (bitNameTextBox.Text == "") { resultCode = "有内鬼，没有位域名字"; }
            if (highLowBitTextBox.Text == "") { resultCode = "有内鬼，没有设置高低位"; }
            if (setModeRadioButton.Checked && valueAndValueNameSet.Count == 0 && AnalysisSetModeValueNULL()) { resultCode = "有内鬼，有的模式值没文本"; }
            if (!AnalysisBitFiledName()) { resultCode = "有内鬼，" + bitNameTextBox.Text; }
            else if (!AnalysisHighLowBit()) { resultCode = "有内鬼，" + highLowBitTextBox.Text; }
            else if (setValueRadioButton.Checked && !AnalysisLocalScope()) { resultCode = "有内鬼，" + localScopeTextBox.Text; }
            else if (setModeRadioButton.Checked && !AnalysisValueAndValueNameTable()) { resultCode = "有内鬼，有效值设置"; }
            else
            {
                if (multipDevInfTarget)
                {

                    funcMould.SetBaseAddrName(baseName);
                    funcMould.SetRegName(regName);
                    resultCode += funcMould.GenerateAssemblyCode(toolString, defineSomeValueCheckBox.Checked, multipDevInfTarget);
                }
                else
                {
                    funcMould.SetBaseAddrName(baseName);
                    funcMould.SetRegName(regName);
                    //resultCode += funcMould.GenerateAssemblyCode(toolString, defineSomeValueCheckBox.Checked, multipDevInfTarget);
                    funcMould.GenerateAssemblyCode_Define(toolString, defineSomeValueCheckBox.Checked);
                }
            }
            return resultCode;
        }

        /// <summary>
        /// 分析有没有模式的对应数字（十进制）是空的
        /// </summary>
        /// <returns></returns>
        private bool AnalysisSetModeValueNULL()
        {
            for (int i = 0; i < valueAndValueNameSet.Count; i++)
            {
                if (valueAndValueNameSet[i].GetValue() == "")
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 分析值域的名字符不符合C的命名规则，funcMould的值域的名字
        /// </summary>
        /// <returns></returns>
        private bool AnalysisBitFiledName()
        {
            string bitName = bitNameTextBox.Text;
            if (AnalysisStringCName(bitName))
            {
                funcMould.SetBitName(bitName);
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 分析高低位的文本是不是符合，并且设置funcMould高低位
        /// </summary>
        /// <returns></returns>
        private bool AnalysisHighLowBit()
        {
            string highgLowBit = highLowBitTextBox.Text;
            int index = 0;
            int highBitNum = 0;
            int lowBitNum = 0;
            bool subCharTarget = false;
            for (; index < highgLowBit.Length; index++)
            {
                if (highgLowBit[index] == '-')
                {
                    if (index == 0) return false;
                    subCharTarget = true;
                    continue;
                }
                if (subCharTarget)
                {
                    if (highgLowBit[index] >= '0' && highgLowBit[index] <= '9')
                    {
                        lowBitNum *= 10;
                        lowBitNum += highgLowBit[index] - '0';
                    }
                    else return false;
                }
                else
                {
                    if (highgLowBit[index] >= '0' && highgLowBit[index] <= '9')
                    {
                        highBitNum *= 10;
                        highBitNum += highgLowBit[index] - '0';
                    }
                    else return false;
                }
            }
            if (highBitNum >= lowBitNum)
            {
                funcMould.SetHighLowIndexBit(highBitNum, lowBitNum);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 分析局部范围的文本是不是正确的，然后设置funcMould的局部范围，但是不保证会不会超出值域最大值
        /// </summary>
        /// <returns></returns>
        private bool AnalysisLocalScope()
        {
            if (setValueRadioButton.Checked && localScopeCheckBox.Checked)
            {
                int index = 0;
                string localScopeStr = localScopeTextBox.Text;
                string minValue = "";
                string maxValue = "";
                bool subTarget = false;
                if (localScopeStr.IndexOf('-') == -1)
                {
                    for (; index < localScopeStr.Length; index++)
                    {
                        maxValue += localScopeStr[index];
                    }
                    if (index != localScopeStr.Length)
                    {
                        return false;
                    }
                    funcMould.SetSetValueMaxValue(maxValue);
                }
                else
                {
                    for (; index < localScopeStr.Length; index++)
                    {
                        if (localScopeStr[index] == '-')
                        {
                            subTarget = true;
                            continue;
                        }
                        if (subTarget)
                        {
                            maxValue += localScopeStr[index];
                        }
                        else
                        {
                            minValue += localScopeStr[index];
                        }
                    }
                    if (index != localScopeStr.Length)
                    {
                        return false;
                    }
                    funcMould.SetSetValueMaxValue(minValue, maxValue);
                }
            }
            return true;
        }

        /// <summary>
        /// 分析模式和模式名字符不符合C的命名
        /// </summary>
        /// <returns></returns>
        private bool AnalysisValueAndValueNameTable()
        {
            funcMould.ClearModeNum();
            funcMould.ClearModeString();

            string valueStr = "";
            string valueNameStr = "";

            for (int i = 0; i < valueAndValueNameSet.Count; i++)
            {
                valueStr = valueAndValueNameSet[i].GetValue();
                valueNameStr = valueAndValueNameSet[i].GetValueName();
                if (!AnlysisStringNumber(valueStr)) return false;
                funcMould.AddModeNum(valueStr);
                if (valueNameStr != "")
                {
                    if (!AnalysisStringCName(valueNameStr)) return false;
                    funcMould.AddModeString(valueNameStr);
                }
                else
                {
                    funcMould.AddModeString(valueStr);
                }
            }
            return true;
        }

        /// <summary>
        /// 分析字符串是不是一个十进制数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool AnlysisStringNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 分析字符串是不是符合C的标识符命名规则
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool AnalysisStringCName(string str)
        {
            int index = 0;
            if (str == "") { return false; }
            if (AnalysisChar(str[index]))
            {
                if (str[index] >= '0' && str[index] <= '9') return false;
            }
            else
            {
                return false;
            }
            index++;
            for (; index < str.Length; index++)
            {
                if (!AnalysisChar(str[index]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 分析这个字符是不是_ 数字 字母
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private bool AnalysisChar(char ch)
        {
            if (ch == '_') return true;
            else if (ch >= '0' && ch <= '9') return true;
            else if (ch >= 'a' && ch <= 'z') return true;
            else if (ch >= 'A' && ch <= 'Z') return true;
            return false;
        }

        //下面都是按钮的值变化的事件，不再添加注释
        private void enableTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (enableTypeRadioButton.Checked)
            {
                funcMould.SetType(0);
                DisableSetValueUI();
                DisableSetModeUI();
            }
        }

        private void setValueRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (setValueRadioButton.Checked)
            {
                funcMould.SetType(1);
                DisableSetModeUI();
                EnableSetValueUI();
            }
        }

        private void setModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (setModeRadioButton.Checked)
            {
                funcMould.SetType(2);
                DisableSetValueUI();
                EnableSetModeUI();
            }
        }

        private void readRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetWriteOrRead(1);
        }

        private void writeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetWriteOrRead(0);
        }

        private void writeAndReadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetWriteOrRead(2);
        }

        private void seizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetSeizeReg(seizeCheckBox.Checked);
        }

        private void stackSaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetStackSaveRegTX(stackSaveCheckBox.Checked);
        }

        private void defineSomeValueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetDefineSomeValue(defineSomeValueCheckBox.Checked);
        }

        private void modeSingleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetModeSingleType(modeSingleCheckBox.Checked);
        }

        private void localScopeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            funcMould.SetSetValueLocalScope(localScopeCheckBox.Checked);
            localScopeTextBox.Enabled = localScopeCheckBox.Checked;
        }

        private void addValueAndValueNameButton_Click(object sender, EventArgs e)
        {
            AddValueAndValueNameTable();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ValueAndValueName lastOne = valueAndValueNameSet[valueAndValueNameSet.Count - 1];
            valueAndValueNameSet.RemoveAt(valueAndValueNameSet.Count - 1);
            lastOne.Hide();
            lastOne.Dispose();
        }

        /// <summary>
        /// 这是添加新的模式和模式名字的控件的函数，不做解释，看看效果就知道了
        /// </summary>
        private void AddValueAndValueNameTable()
        {
            ValueAndValueName newValueAndValueName = new ValueAndValueName();
            if (valueAndValueNameSet.Count == 0)
            {
                newValueAndValueName.Location = new Point(1, 0);
            }
            else
            {
                if (valueAndValueNameSet.Count % 3 == 0)
                {
                    newValueAndValueName.Location = new Point(1, valueAndValueNameSet[valueAndValueNameSet.Count - 3].Location.Y + valueAndValueNameSet[valueAndValueNameSet.Count - 3].Size.Height + 1);
                }
                else if (valueAndValueNameSet.Count % 3 == 1)
                {
                    if (valueAndValueNameSet.Count == 1)
                    {
                        newValueAndValueName.Location = new Point(valueAndValueNameSet[0].Location.X + valueAndValueNameSet[0].Size.Width + 1, valueAndValueNameSet[0].Location.Y);
                    }
                    else
                    {
                        newValueAndValueName.Location = new Point(valueAndValueNameSet[valueAndValueNameSet.Count - 3].Location.X,
                            valueAndValueNameSet[valueAndValueNameSet.Count - 3].Location.Y + valueAndValueNameSet[valueAndValueNameSet.Count - 3].Size.Height + 1);
                    }
                }
                else if (valueAndValueNameSet.Count % 3 == 2)
                {
                    if (valueAndValueNameSet.Count == 2)
                    {
                        newValueAndValueName.Location = new Point(valueAndValueNameSet[1].Location.X + valueAndValueNameSet[1].Size.Width + 1, valueAndValueNameSet[1].Location.Y);
                    }
                    else
                    {
                        newValueAndValueName.Location = new Point(valueAndValueNameSet[valueAndValueNameSet.Count - 3].Location.X,
                            valueAndValueNameSet[valueAndValueNameSet.Count - 3].Location.Y + valueAndValueNameSet[valueAndValueNameSet.Count - 3].Size.Height + 1);
                    }
                }
            }
            valueAndValueNameSet.Add(newValueAndValueName);
            valueAndValueNameInfPanel.Controls.Add(newValueAndValueName);
        }

        /// <summary>
        /// 这是保存配置文件时，返回地标签化字符串，不做过多解释，看看效果就行
        /// </summary>
        /// <returns></returns>
        public string SaveFile_BitFiledInf()
        {
            string saveStr = "";
            saveStr += "\t\t[bitFiled]\n";

            if (bitNameTextBox.Text == "") saveStr += "\t\t\tbitName=%\n";
            else saveStr += "\t\t\tbitName=" + bitNameTextBox.Text + '\n';

            if (highLowBitTextBox.Text == "") saveStr += "\t\t\thighLowBit=%\n";
            else saveStr += "\t\t\thighLowBit=" + highLowBitTextBox.Text + '\n';

            saveStr += "\t\t\tseizeReg=" + seizeCheckBox.Checked.ToString() + '\n';
            saveStr += "\t\t\tstackSave=" + stackSaveCheckBox.Checked.ToString() + '\n';
            saveStr += "\t\t\tdefine=" + defineSomeValueCheckBox.Checked.ToString() + '\n';
            if (enableTypeRadioButton.Checked) saveStr += "\t\t\ttype=enable\n";
            else if (setValueRadioButton.Checked) saveStr += "\t\t\ttype=setValue\n";
            else if (setModeRadioButton.Checked) saveStr += "\t\t\ttype=setMode\n";

            if (readRadioButton.Checked) saveStr += "\t\t\twriteOrRead=r\n";
            else if (writeRadioButton.Checked) saveStr += "\t\t\twriteOrRead=w\n";
            else if (writeAndReadRadioButton.Checked) saveStr += "\t\t\twriteOrRead=rw\n";

            saveStr += "\t\t\tlocalScopeTarget=" + localScopeCheckBox.Checked.ToString() + '\n';

            if (localScopeTextBox.Text == "") saveStr += "\t\t\tlocalScope=%\n";
            else saveStr += "\t\t\tlocalScope=" + localScopeTextBox.Text + '\n';

            saveStr += "\t\t\tsingleFuncTarget=" + modeSingleCheckBox.Checked.ToString() + '\n';

            for (int i = 0; i < valueAndValueNameSet.Count; i++)
            {
                if (valueAndValueNameSet[i].GetValue() == "") saveStr += "\t\t\tmodeValue=%\n";
                else saveStr += "\t\t\tmodeValue=" + valueAndValueNameSet[i].GetValue() + '\n';

                if (valueAndValueNameSet[i].GetValueName() == "") saveStr += "\t\t\tmodeString=%\n";
                else saveStr += "\t\t\tmodeString=" + valueAndValueNameSet[i].GetValueName() + '\n';
            }
            saveStr += "\t\t[#bitFiled]\n";
            return saveStr;
        }

        /// <summary>
        /// 这是分析传进来的标签化字符串，并且设置bitFiledInf，逻辑简单，不做解释了
        /// </summary>
        /// <param name="inf"></param>
        public void ReadFile_BitFiledInf(string inf)
        {
            string[] fileContent = inf.Split('\n');
            string tempStr = "";

            tempStr = GetValueInFileString(fileContent[0]);
            if (tempStr == "%") bitNameTextBox.Text = "";
            else bitNameTextBox.Text = tempStr;

            tempStr = GetValueInFileString(fileContent[1]);
            if (tempStr == "%") highLowBitTextBox.Text = "";
            else highLowBitTextBox.Text = tempStr;

            tempStr = GetValueInFileString(fileContent[2]);
            seizeCheckBox.Checked = (tempStr[0] == 'T');

            tempStr = GetValueInFileString(fileContent[3]);
            stackSaveCheckBox.Checked = (tempStr[0] == 'T');

            tempStr = GetValueInFileString(fileContent[4]);
            defineSomeValueCheckBox.Checked = (tempStr[0] == 'T');

            tempStr = GetValueInFileString(fileContent[5]);
            if (tempStr == "enable") enableTypeRadioButton.Checked = true;
            else if (tempStr == "setValue") setValueRadioButton.Checked = true;
            else if (tempStr == "setMode") setModeRadioButton.Checked = true;

            tempStr = GetValueInFileString(fileContent[6]);
            if (tempStr == "r") readRadioButton.Checked = true;
            else if (tempStr == "w") writeRadioButton.Checked = true;
            else if (tempStr == "rw") writeAndReadRadioButton.Checked = true;

            tempStr = GetValueInFileString(fileContent[7]);
            localScopeCheckBox.Checked = (tempStr[0] == 'T');

            tempStr = GetValueInFileString(fileContent[8]);
            if (tempStr == "%") localScopeTextBox.Text = "";
            else localScopeTextBox.Text = tempStr;

            tempStr = GetValueInFileString(fileContent[9]);
            modeSingleCheckBox.Checked = (tempStr[0] == 'T');

            int modeStringIndex = 10;
            for (int i = 0; i < valueAndValueNameSet.Count; i++)
            {
                valueAndValueNameSet[i].Hide();
                valueAndValueNameSet[i].Dispose();
            }
            valueAndValueNameSet.Clear();
            int valueAndValueNameIndex = 0;
            for (; modeStringIndex < fileContent.Length; modeStringIndex++)
            {
                AddValueAndValueNameTable();
                if (GetValueInFileString(fileContent[modeStringIndex]) == "%") valueAndValueNameSet[valueAndValueNameIndex].SetValue("");
                else valueAndValueNameSet[valueAndValueNameIndex].SetValue(GetValueInFileString(fileContent[modeStringIndex]));

                modeStringIndex++;
                if (modeStringIndex == fileContent.Length) break;

                if (GetValueInFileString(fileContent[modeStringIndex]) == "%") valueAndValueNameSet[valueAndValueNameIndex].SetValueName("");
                else valueAndValueNameSet[valueAndValueNameIndex].SetValueName(GetValueInFileString(fileContent[modeStringIndex]));

                valueAndValueNameIndex++;
            }

            UpdateUIAfterReadFile();
            UpdateFuncMouldAfterReadFile();
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

        /// <summary>
        /// 更新UI，在读取文件之后
        /// </summary>
        private void UpdateUIAfterReadFile()
        {
            if (enableTypeRadioButton.Checked)
            {
                DisableSetValueUI();
                DisableSetModeUI();
            }
            else if (setValueRadioButton.Checked)
            {
                DisableSetModeUI();
                EnableSetValueUI();
            }
            else if (setModeRadioButton.Checked)
            {
                DisableSetValueUI();
                EnableSetModeUI();
            }
        }

        /// <summary>
        /// 更新funcMould在读取文件之后
        /// </summary>
        private void UpdateFuncMouldAfterReadFile()
        {
            funcMould.SetSeizeReg(seizeCheckBox.Checked);
            funcMould.SetStackSaveRegTX(stackSaveCheckBox.Checked);
            funcMould.SetDefineSomeValue(defineSomeValueCheckBox.Checked);
            funcMould.SetSetValueLocalScope(localScopeCheckBox.Checked);
            funcMould.SetModeSingleType(modeSingleCheckBox.Checked);

            if (enableTypeRadioButton.Checked) { funcMould.SetType(0); }
            else if (setValueRadioButton.Checked) { funcMould.SetType(1); }
            else if (setModeRadioButton.Checked) { funcMould.SetType(2); }

            if (readRadioButton.Checked) { funcMould.SetWriteOrRead(1); }
            else if (writeRadioButton.Checked) { funcMould.SetWriteOrRead(0); }
            else if (writeAndReadRadioButton.Checked) { funcMould.SetWriteOrRead(2); }
        }

        /// <summary>
        /// 这是选择了设置数值的类型的时候，UI的变化
        /// </summary>
        private void EnableSetValueUI()
        {
            tipLabel.Text = "填入格式如：\"1-51\" 或者51（指0-51）作为局部范围";

            tipLabel.Enabled = true;
            localScopeCheckBox.Enabled = true;
            localScopeTextBox.Enabled = localScopeCheckBox.Checked;

            tipLabel.Show();
            localScopeCheckBox.Show();
            localScopeTextBox.Show();
        }

        /// <summary>
        /// 这是没有选择设置数值的类型的时候，UI的变化
        /// </summary>
        private void DisableSetValueUI()
        {
            tipLabel.Hide();
            localScopeCheckBox.Hide();
            localScopeTextBox.Hide();

            tipLabel.Enabled = false;
            localScopeCheckBox.Enabled = false;
            localScopeTextBox.Enabled = false;
        }

        /// <summary>
        /// 这是选择了设置模式的类型的时候，UI的变化
        /// </summary>
        private void EnableSetModeUI()
        {
            tipLabel.Text = "有效值和有效值的名称（可不填名称）（例：1 always 或者 1）";

            tipLabel.Enabled = true;
            modeSingleCheckBox.Enabled = true;
            valueAndValueNameInfPanel.Enabled = true;
            addValueAndValueNameButton.Enabled = true;
            deleteButton.Enabled = true;

            tipLabel.Show();
            modeSingleCheckBox.Show();
            valueAndValueNameInfPanel.Show();
            addValueAndValueNameButton.Show();
            deleteButton.Show();
        }

        /// <summary>
        /// 这是没有选择设置模式的类型的时候，UI的变化
        /// </summary>
        private void DisableSetModeUI()
        {
            tipLabel.Hide();
            modeSingleCheckBox.Hide();
            valueAndValueNameInfPanel.Hide();
            addValueAndValueNameButton.Hide();
            deleteButton.Hide();

            tipLabel.Enabled = false;
            modeSingleCheckBox.Enabled = false;
            valueAndValueNameInfPanel.Enabled = false;
            addValueAndValueNameButton.Enabled = false;
            deleteButton.Enabled = false;
        }
    }
}