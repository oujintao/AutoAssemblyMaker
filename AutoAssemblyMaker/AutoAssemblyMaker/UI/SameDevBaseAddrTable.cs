using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoAssemblyMaker.UI
{
    public partial class SameDevBaseAddrTable : Form
    {
        /// <summary>
        /// 设备名字的影子集合
        /// </summary>
        public List<string> devBaseAddrNameSet = new List<string>();
        /// <summary>
        /// 设备基地址的影子集合
        /// </summary>
        public List<string> devBaseAddrNumSet = new List<string>();

        /// <summary>
        /// DevInfCollectUnit的集合，是devBaseAddrNameSet和devBaseAddrNumSet的影子映射
        /// </summary>
        private List<DevInfCollectUnit> sameDevBaseAddrTableSet = new List<DevInfCollectUnit>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public SameDevBaseAddrTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            DevInfCollectUnit newTable = new DevInfCollectUnit();
            if (sameDevBaseAddrTableSet.Count == 0)
            {
                newTable.Location = new Point(3, 3);
            }
            else
            {
                newTable.Location = new Point(3, sameDevBaseAddrTableSet[sameDevBaseAddrTableSet.Count - 1].Location.Y + sameDevBaseAddrTableSet[sameDevBaseAddrTableSet.Count - 1].Size.Height + 1);
            }
            sameDevBaseAddrTableSet.Add(newTable);
            sameDevInfPanel.Controls.Add(newTable);
        }

        /// <summary>
        /// 确实按钮点击事件 主要是影子寄存器的更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            devBaseAddrNameSet.Clear();
            devBaseAddrNumSet.Clear();
            for (int i = 0; i < sameDevBaseAddrTableSet.Count; i++)
            {
                devBaseAddrNameSet.Add(sameDevBaseAddrTableSet[i].GetBaseAddrName());
                devBaseAddrNumSet.Add(sameDevBaseAddrTableSet[i].GetBaseAddrNum());
            }
            this.Hide();
        }

        /// <summary>
        /// 关闭的事件变成只是隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SameDevBaseAddrTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            devBaseAddrNameSet.Clear();
            devBaseAddrNumSet.Clear();
            for (int i = 0; i < sameDevBaseAddrTableSet.Count; i++)
            {
                devBaseAddrNameSet.Add(sameDevBaseAddrTableSet[i].GetBaseAddrName());
                devBaseAddrNumSet.Add(sameDevBaseAddrTableSet[i].GetBaseAddrNum());
            }
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 删除按钮点击事件，这样是删除最后一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DevInfCollectUnit lastDev = sameDevBaseAddrTableSet[sameDevBaseAddrTableSet.Count - 1];
            sameDevBaseAddrTableSet.RemoveAt(sameDevBaseAddrTableSet.Count - 1);
            lastDev.Hide();
            lastDev.Dispose();
        }

        /// <summary>
        /// 分析读取文件之后的string集合
        /// </summary>
        /// <param name="strSet"></param>
        public void ReadFile_SameDevBaseAddrTable(string[] strSet)
        {
            devBaseAddrNameSet.Clear();
            devBaseAddrNumSet.Clear();
            for (int i = 0; i < sameDevBaseAddrTableSet.Count; i++)
            {
                sameDevBaseAddrTableSet[i].Hide();
                sameDevBaseAddrTableSet[i].Dispose();
            }
            sameDevBaseAddrTableSet.Clear();
            for (int i = 3; i < strSet.Length; i++)
            {
                DevInfCollectUnit newTable = new DevInfCollectUnit();
                if (sameDevBaseAddrTableSet.Count == 0)
                {
                    newTable.Location = new Point(3, 3);
                }
                else
                {
                    newTable.Location = new Point(3, sameDevBaseAddrTableSet[sameDevBaseAddrTableSet.Count - 1].Location.Y + sameDevBaseAddrTableSet[sameDevBaseAddrTableSet.Count - 1].Size.Height + 1);
                }
                sameDevBaseAddrTableSet.Add(newTable);
                sameDevInfPanel.Controls.Add(newTable);
                newTable.SetBaseAddrName((GetValueInFileString(strSet[i]) == "%" ? "" : GetValueInFileString(strSet[i])));
                i++;
                newTable.SetBaseAddrNum((GetValueInFileString(strSet[i]) == "%" ? "" : GetValueInFileString(strSet[i])));
            }
            for (int i = 0; i < sameDevBaseAddrTableSet.Count; i++)  //影子寄存器的映射更新
            {
                devBaseAddrNameSet.Add(sameDevBaseAddrTableSet[i].GetBaseAddrName());
                devBaseAddrNumSet.Add(sameDevBaseAddrTableSet[i].GetBaseAddrNum());
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