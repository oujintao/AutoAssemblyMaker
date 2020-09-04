using System;
using System.Windows.Forms;

namespace AutoAssemblyMaker.UI
{
    public partial class DevInfInitDialog : Form
    {
        public string baseAddrNameResult = "有内鬼";
        public string baseAddrResult = "有内鬼";

        public DevInfInitDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击了确定按钮的事件，检查外围设备的名字是不是符合C的命名规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            int index = 0;
            string baseAddrName = devBaseAddrNameTextBox.Text;
            string baseAddr = devBaseAddrTextBox.Text;
            this.devBaseAddrNameTextBox.Enabled = false;
            this.devBaseAddrTextBox.Enabled = false;
            if(baseAddr == "" || baseAddrName == "")
            {
                MessageBox.Show(this, "不能有任意一项为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.devBaseAddrNameTextBox.Enabled = true;
                this.devBaseAddrTextBox.Enabled = true;
                return;
            }
            if (baseAddrName[index] >= '0' && baseAddrName[index] <= '9')
            {
                MessageBox.Show(this, "外围设备相关名字首字符不能是数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.devBaseAddrNameTextBox.Enabled = true;
                this.devBaseAddrTextBox.Enabled = true;
                return;
            }
            for (; index < baseAddrName.Length; index++)
            {
                if (!CheckIdentifierRule(baseAddrName[index]))
                {
                    MessageBox.Show(this, "外围设备相关名字存在非法字符（采用的是C命名方式）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.devBaseAddrNameTextBox.Enabled = true;
                    this.devBaseAddrTextBox.Enabled = true;
                    return;
                }
            }
            this.devBaseAddrNameTextBox.Enabled = true;
            this.devBaseAddrTextBox.Enabled = true;
            baseAddrNameResult = devBaseAddrNameTextBox.Text;
            baseAddrResult = devBaseAddrTextBox.Text;
            this.Hide();
        }

        /// <summary>
        /// C的单个字符的要求，不考虑第一个字符
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private bool CheckIdentifierRule(char ch)
        {
            if (ch >= '0' && ch <= '9') return true;
            if (ch >= 'a' && ch <= 'z') return true;
            if (ch >= 'A' && ch <= 'Z') return true;
            if (ch == '_') return true;
            return false;
        }

        /// <summary>
        /// 新建不成功，返回有内鬼，然后就取消新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            baseAddrNameResult = "有内鬼";
            baseAddrResult = "有内鬼";
            this.Hide();
        }
    }
}
