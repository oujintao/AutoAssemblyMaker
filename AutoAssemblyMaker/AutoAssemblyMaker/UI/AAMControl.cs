using AutoAssemblyMaker.抽象层;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AutoAssemblyMaker.UI
{
    public partial class AAMControl : Form
    {
        /// <summary>
        /// 这是设备信息的控件的集合
        /// </summary>
        public List<DevInf> devInfSet = new List<DevInf>();
        /// <summary>
        /// 目前多少个设备信息 devInfSet.count
        /// </summary>
        public int devInfNum = 0;
        /// <summary>
        /// 生产的工具字符串，对应ALLMould大部分的文件
        /// </summary>
        public ToolString toolString = new ToolString();
        /// <summary>
        /// 设备信息对应的按钮，选中就可以显示对应的设备信息
        /// </summary>
        private List<RadioButton> showRadioButtonSet = new List<RadioButton>();
        /// <summary>
        /// 显示设备信息的集合的当前选中下标
        /// </summary>
        private int showDevInfIndex = -1;
        /// <summary>
        /// 配置文件读取路径
        /// </summary>
        private string readFileDir = "";
        /// <summary>
        /// 配置文件保存路径
        /// </summary>
        private string saveFileDir = "";
        /// <summary>
        /// 生成代码文件存放的文件夹
        /// </summary>
        private string generateCodeDir = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public AAMControl()
        {
            InitializeComponent();
            this.selectedDevCheckedListBox.Items.Clear();
            toolString.UpdateAllString();  //读取AllMould里面的文件
        }

        /// <summary>
        /// 添加外围设备按钮添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewDevButton_Click(object sender, EventArgs e)
        {
            DevInfInitDialog devInfInitDialog = new DevInfInitDialog();
            devInfInitDialog.ShowDialog();  //获得这个新增设备的名字和基地址（后期可以添加多个同类设备）
            if (devInfInitDialog.baseAddrNameResult == "有内鬼") { return; } //有内鬼就是前面的设置有错误，所以不能添加
            DevInf newDevInf = new DevInf(devInfInitDialog.baseAddrNameResult, devInfInitDialog.baseAddrResult);
            MakeNewDevInfForm(newDevInf, "new" + devInfNum.ToString());  //尤其发现这个new其实没什么用了
            ALLDevInfFormHide();//所有设备信息隐藏
            devInfSet.Add(newDevInf);  //添加这个新的设备信息

            if (showDevInfIndex != -1)
            {
                devInfSet[showDevInfIndex].Hide();  //这个if没必要存在，貌似
            }
            newDevInf.Show();  //显示这个新的

            //关于设备信息集合的消息的更新
            selectedDevCheckedListBox.Items.Add(devInfInitDialog.baseAddrNameResult);
            MakeNewRadioButton(devInfInitDialog.baseAddrNameResult);
            devInfNum++;
            showDevInfIndex = showRadioButtonSet.Count - 1;
        }

        /// <summary>
        /// 创造新的单选按钮，并且添加在显示的panel里面
        /// </summary>
        /// <param name="showStr"></param>
        private void MakeNewRadioButton(string showStr)
        {
            RadioButton showRadioButton = new RadioButton();
            showRadioButton.Text = showStr;  //新增的按钮的隔壁的文字
            showRadioButton.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            showRadioButton.CheckedChanged += new System.EventHandler(showDevRadioButton_Check);  //按钮选中改变事件
            showRadioButtonSet.Add(showRadioButton);  //集合的更新
            if (showRadioButtonSet.Count == 1)
            {
                showRadioButton.Location = new Point(2, 0);
            }
            else
            {
                //上一个的按钮的高度+上一个按钮的高度就是这个按钮的Y
                showRadioButton.Location = new Point(2, showRadioButtonSet[showRadioButtonSet.Count - 2].Location.Y + showRadioButtonSet[showRadioButtonSet.Count - 2].Size.Height);
            }
            showRadioButtonPanel.Controls.Add(showRadioButton);//加入panel
            showRadioButton.Checked = true;  //选中，因为要显示这个新的
        }

        /// <summary>
        /// 设备信息展示按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showDevRadioButton_Check(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            for (; selectedIndex < showRadioButtonSet.Count; selectedIndex++)
            {
                if (showRadioButtonSet[selectedIndex].Checked)  //找出选中的radioButton
                {
                    break;
                }
            }
            if (selectedIndex == showRadioButtonSet.Count)  //没有找到选中的 这是一个保险罢了，应该不会条件为真
            {
                ALLDevInfFormHide();
                showDevInfIndex = -1;
            }
            else
            {
                //三个if是一个保险，防止下标出错
                if (showDevInfIndex < 0) return;
                if (showDevInfIndex >= devInfSet.Count) return;
                if (selectedIndex >= devInfSet.Count) return;
                devInfSet[showDevInfIndex].Hide();  //目前显示隐藏
                devInfSet[selectedIndex].Show();  //选中的显示
                showDevInfIndex = selectedIndex;  //显示的下标更新
            }
        }


        /// <summary>
        /// 新的设备信息显示控件创建，并且固定他的位置是12,106
        /// </summary>
        /// <param name="newDevInf"></param>
        /// <param name="devInfName"></param>
        private void MakeNewDevInfForm(DevInf newDevInf, string devInfName)
        {
            newDevInf.Location = new System.Drawing.Point(12, 106);
            newDevInf.Name = devInfName;
            this.Controls.Add(newDevInf);
        }

        /// <summary>
        /// 所有的设备信息隐藏
        /// </summary>
        private void ALLDevInfFormHide()
        {
            for (int i = 0; i < devInfSet.Count; i++)
            {
                devInfSet[i].Hide();
            }
        }

        /// <summary>
        /// 生成代码的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateCodeButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(generateCodeDir) || generateCodeDir == "")  //如果不存在指定的目录 或者没有指定
            {
                if (!GenerateCodeDirSelect())  //去获得一个目录失败的话就退出生成事件
                {
                    MessageBox.Show("生成地址错误，生成失败！");
                    return;
                }
            }

            toolString.getCFuncCode = "";  //清空这个C语言文件的生成代码，因为忘了单独做一个函数了，所以直接用一个变量来展示
            string resultCode = "";  //一个设备信息产生的汇编代码存在这里
            string resultCodeTemp = "";  //全部的设备信息产生的汇编代码存在这里
            string devName = "";  //设备信息的名字 比如GPIO
            string devDirFullName = "";  //设备信息对用的一个文件夹，里面存放着.H和.s文件
            string devSFullName = "";  //汇编的文件的文件名字
            string devCFullName = "";  //C的文件的文件名字
            toolString.UpdateAllString();
            toolString.getCDefineCode = "";
            toolString.getCFuncCode = "";
            for (int i = 0; i < devInfSet.Count; i++)
            {
                //生成这个设备信息对应的代码  存在一个文件夹里面
                resultCode = devInfSet[i].GenerateCode_DevInf(toolString);
                resultCodeTemp += resultCode;

                //文件夹和文件名的更新 例：GPIO
                devName = showRadioButtonSet[i].Text;
                devDirFullName = generateCodeDir + '\\' + devName;
                devSFullName = devDirFullName + '\\' + devName + ".s";
                devCFullName = devDirFullName + '\\' + devName + ".H";

                //例：保证一个GPIO文件夹存在
                Directory.CreateDirectory(devDirFullName);

                //汇编和C的文件编写
                FileStream SFile;
                SFile = new FileStream(devSFullName, FileMode.OpenOrCreate, FileAccess.Write);
                SFile.Close();
                SFile = new FileStream(devSFullName, FileMode.Truncate, FileAccess.Write);
                StreamWriter SFileWriter = new StreamWriter(SFile);
                SFileWriter.Write(resultCode);
                SFileWriter.Close();
                SFile.Close();

                FileStream CFile;
                CFile = new FileStream(devCFullName, FileMode.OpenOrCreate, FileAccess.Write);
                CFile.Close();
                CFile = new FileStream(devCFullName, FileMode.Truncate, FileAccess.Write);
                StreamWriter CFileWriter = new StreamWriter(CFile);
                CFileWriter.Write(toolString.getCDefineCode + '\n' + toolString.getCFuncCode);
                CFileWriter.Close();
                CFileWriter.Close();

                //这些是和汇编代码同时生成，所以这里需要手动清空
                toolString.getCDefineCode = "";
                toolString.getCFuncCode = "";
            }
            //这里是供检查代码有没有错的   看看有没有产生有内鬼的情况，但是不完全
            CodeCheckForm codeCheckForm = new CodeCheckForm(resultCodeTemp);
            codeCheckForm.Show();
            codeCheckForm.CheckCode();
        }

        /// <summary>
        /// 保存文件按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            if (saveFileDir == "" || !Directory.Exists(System.IO.Path.GetDirectoryName(saveFileDir)))  //保存路径不存在 或者 指定的目录不在
            {
                if (!SaveFileDirSelect())
                {
                    return;
                }
            }
            saveFileFunc();  //保存配置文件的函数
        }

        /// <summary>
        /// 保存配置文件的函数，需要保证saveFileDir被指定
        /// </summary>
        private void saveFileFunc()
        {
            string saveStr = "";
            for (int i = 0; i < devInfSet.Count; i++)  //获得设备信息返回的标签化信息，用于保存
            {
                saveStr += devInfSet[i].SaveFile_DevInf();
            }
            //文件流操作
            FileStream mouldCode;
            mouldCode = new FileStream(saveFileDir, FileMode.OpenOrCreate, FileAccess.Write);
            mouldCode.Close();
            mouldCode = new FileStream(saveFileDir, FileMode.Truncate, FileAccess.Write);
            StreamWriter writeFile = new StreamWriter(mouldCode);
            writeFile.Write("readFilePath=" + (readFileDir == "" ? "%" : readFileDir) + '\n');  //空的字符串用%代替，这样就可以读取文件方便
            writeFile.Write("saveFilePath=" + (saveFileDir == "" ? "%" : saveFileDir) + '\n');
            writeFile.Write("generateCodeDir=" + (generateCodeDir == "" ? "%" : generateCodeDir) + '\n');
            writeFile.Write(saveStr);
            writeFile.Close();
            mouldCode.Close();
        }

        /// <summary>
        /// 读取文件按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readFileButton_Click(object sender, EventArgs e)
        {
            if (readFileDir == "" || !File.Exists(readFileDir))  //文件路径 和 文件不存在的话
            {
                if (!ReadFileDirSelect())
                {
                    return;
                }
            }

            string fileContent = "";
            //文件流操作
            FileStream mouldCode;
            mouldCode = new FileStream(readFileDir, FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);

            //读取文件路径和保存文件路径和生成代码目录的存储
            fileContent = readFile.ReadLine();
            fileContent = GetValueInFileString(fileContent);
            readFileDir = fileContent == "%" ? "" : fileContent;

            fileContent = readFile.ReadLine();
            fileContent = GetValueInFileString(fileContent);
            saveFileDir = fileContent == "%" ? "" : fileContent;

            fileContent = readFile.ReadLine();
            fileContent = GetValueInFileString(fileContent);
            generateCodeDir = fileContent == "%" ? "" : fileContent;

            fileContent = readFile.ReadToEnd();

            readFile.Close();
            mouldCode.Close();
            if (fileContent == "")
            {
                MessageBox.Show("错误，空文件！");
                return;
            }

            //清空原来的panel和checkListBox和devInfSet的信息
            selectedDevCheckedListBox.Items.Clear();
            for (int i = 0; i < showRadioButtonSet.Count; i++)
            {
                showRadioButtonSet[i].Hide();
                showRadioButtonSet[i].Dispose();
            }
            showRadioButtonSet.Clear();
            for (int i = 0; i < devInfSet.Count; i++)
            {
                devInfSet[i].Hide();
                devInfSet[i].Dispose();
            }
            devInfSet.Clear();
            //开始分析标签化内容
            string showTextGet = "";
            int devInfLabelStartIndex = 0;
            int devInfLabelEndIndex = fileContent.IndexOf("[#devInf]");
            while (true)
            {
                DevInf newDevInf = new DevInf();
                MakeNewDevInfForm(newDevInf, "newDevInf" + devInfSet.Count);  //创建新的设备信息控件

                //拿到[devInf]和[#devInf]之间第一个baseAddr和baseAddrName，用来做显示
                //9是baseAddr=这九个字符
                //2是指代\n\t
                showTextGet = fileContent.Substring(fileContent.IndexOf("baseAddr", devInfLabelStartIndex) + 9, fileContent.IndexOf("baseAddrName", devInfLabelStartIndex) - 2 - fileContent.IndexOf("baseAddr", devInfLabelStartIndex) - 9);
                MakeNewRadioButton(showTextGet);
                selectedDevCheckedListBox.Items.Add(showTextGet);

                //获取设备信息设置要的也就是[devInf]和[#devInf]之间的内容 注意是之间
                //10是跳过这10个字符[devInf]\n\t
                //1是\t[#devInf]这里的\t
                newDevInf.ReadFile_DevInf(fileContent.Substring(devInfLabelStartIndex + 10, devInfLabelEndIndex - devInfLabelStartIndex - 1 - 10));

                //找下一个[devInf][#defInf]
                devInfLabelStartIndex = fileContent.IndexOf("[devInf]", devInfLabelEndIndex + 2);
                devInfSet.Add(newDevInf);

                if (devInfLabelStartIndex == -1)
                {
                    break;
                }
                devInfLabelEndIndex = fileContent.IndexOf("[#devInf]", devInfLabelStartIndex);
            }
            if (devInfSet.Count != 0)
            {
                //显示第一个设备信息
                ALLDevInfFormHide();
                devInfSet[0].Show();
                showRadioButtonSet[0].Checked = true;
                devInfNum = devInfSet.Count;
                showDevInfIndex = 0;
            }
        }

        /// <summary>
        /// 获得=之后的内容这里就是为什么要%的原因
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        private string GetValueInFileString(string fileContent)
        {
            return fileContent.Substring(fileContent.IndexOf('=') + 1);
        }

        /// <summary>
        /// 删除选中外围设备按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSelectedDevButton_Click(object sender, EventArgs e)
        {
            bool nowShowInf = false;
            for (int i = selectedDevCheckedListBox.Items.Count - 1; i >= 0; i--)  //从底部删除，这样不会下标错乱
            {
                if (selectedDevCheckedListBox.GetItemChecked(i))
                {
                    if (showRadioButtonSet[i].Checked)
                    {
                        nowShowInf = true;
                    }
                    if (i < showDevInfIndex)
                    {
                        showDevInfIndex--;
                    }
                    devInfSet[i].Hide();
                    devInfSet[i].Dispose();
                    devInfSet.RemoveAt(i);
                    showRadioButtonSet[i].Hide();
                    showRadioButtonSet[i].Dispose();
                    showRadioButtonSet.RemoveAt(i);
                    selectedDevCheckedListBox.Items.RemoveAt(i);
                }
            }
            if (nowShowInf)
            {
                if (devInfSet.Count != 0)  //有设备信息的情况 这是一个保险
                {
                    devInfSet[0].Show();
                    showRadioButtonSet[0].Checked = true;
                    showDevInfIndex = 0;
                }
                else
                {
                    showDevInfIndex = 0;
                }
            }
            devInfNum = devInfSet.Count;  //
            UpdateShowRadioButton();  //radioButton布局更新
        }

        /// <summary>
        /// 更新showRadioButtonPanel的布局更新
        /// </summary>
        private void UpdateShowRadioButton()
        {
            if (showRadioButtonSet.Count != 0)
            {
                showRadioButtonSet[0].Location = new Point(2, 0);
                for (int i = 1; i < showRadioButtonSet.Count; i++)
                {
                    showRadioButtonSet[i].Location = new Point(2, showRadioButtonSet[i - 1].Location.Y + showRadioButtonSet[i - 1].Size.Height);
                }
            }
        }

        /// <summary>
        /// 设置读取路径设置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readFileDirSetButton_Click(object sender, EventArgs e)
        {
            ReadFileDirSelect();
        }

        /// <summary>
        /// 这是打开一个打开文件对话框，最终获得一个路径，如果点击了取消返回false，否则true
        /// </summary>
        /// <returns></returns>
        private bool ReadFileDirSelect()
        {
            //学习自：https://blog.csdn.net/qq_43393323/article/details/90641905
            OpenFileDialog readFileDialog = new OpenFileDialog();
            readFileDialog.Title = "打开配置文件";
            readFileDialog.Filter = "aam格式文件|*.aam|任意格式文件（*.*）|*.*";
            readFileDialog.CheckFileExists = true;
            if (readFileDialog.ShowDialog() == DialogResult.OK)
            {
                readFileDir = System.IO.Path.GetFullPath(readFileDialog.FileName);
                saveFileDir = System.IO.Path.GetFullPath(readFileDialog.FileName);
                generateCodeDir = System.IO.Path.GetDirectoryName(readFileDialog.FileName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 另存为按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDirSetbutton_Click(object sender, EventArgs e)
        {
            if (SaveFileDirSelect())
            {
                saveFileFunc();  //立即保存配置文件
            }
        }

        /// <summary>
        /// 打开一个保存文件对话框，并且选择一个文件，如果取消就是false，否则就是true
        /// </summary>
        /// <returns></returns>
        private bool SaveFileDirSelect()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存配置文件";
            saveFileDialog.Filter = "aam格式文件|*.aam";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                readFileDir = System.IO.Path.GetFullPath(saveFileDialog.FileName);
                saveFileDir = System.IO.Path.GetFullPath(saveFileDialog.FileName);
                generateCodeDir = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 代码生成目录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateCodeDirSelectbutton_Click(object sender, EventArgs e)
        {
            GenerateCodeDirSelect();
        }

        /// <summary>
        /// 打开一个文件夹选择框，取消就是false，否则是true
        /// </summary>
        /// <returns></returns>
        private bool GenerateCodeDirSelect()
        {
            FolderBrowserDialog generateCodeDirDialog = new FolderBrowserDialog();
            generateCodeDirDialog.Description = "选择生成代码的文件夹";
            if (generateCodeDirDialog.ShowDialog() == DialogResult.OK)
            {
                generateCodeDir = generateCodeDirDialog.SelectedPath;
                return true;
            }
            return false;
        }
    }
}
//MessageBox.Show(System.IO.Path.GetFullPath(openFileDialog.FileName));                             //绝对路径
//MessageBox.Show(System.IO.Path.GetExtension(openFileDialog.FileName));                           //文件扩展名
//MessageBox.Show(System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName));  //文件名没有扩展名
//MessageBox.Show(System.IO.Path.GetFileName(openFileDialog.FileName));                          //得到文件
//MessageBox.Show(System.IO.Path.GetDirectoryName(openFileDialog.FileName));                  //得到路径