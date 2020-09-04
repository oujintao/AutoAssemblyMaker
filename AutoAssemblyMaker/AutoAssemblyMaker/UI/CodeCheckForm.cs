using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssemblyMaker.UI
{
    public partial class CodeCheckForm : Form
    {
        public CodeCheckForm()
        {
            InitializeComponent();
        }

        public CodeCheckForm(string code)
        {
            InitializeComponent();
            codeRichTextBox.Text = code;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckCode();
        }

        public void CheckCode()
        {
            if (codeRichTextBox.Text.IndexOf("有内鬼") != -1)
            {
                MessageBox.Show("存在错误，请检查！");
            }
        }
    }
}
