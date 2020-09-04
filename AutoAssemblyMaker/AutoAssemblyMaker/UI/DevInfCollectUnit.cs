using System.Windows.Forms;

namespace AutoAssemblyMaker.UI
{
    public partial class DevInfCollectUnit : UserControl
    {
        public DevInfCollectUnit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 返回baseAddrName
        /// </summary>
        /// <returns></returns>
        public string GetBaseAddrName() { return baseAddrNameTextBox.Text; }
        /// <summary>
        /// 返回baseAddrNum
        /// </summary>
        /// <returns></returns>
        public string GetBaseAddrNum() { return baseAddrNumTextBox.Text; }
        /// <summary>
        /// 设置baseAddrName
        /// </summary>
        /// <param name="str"></param>
        public void SetBaseAddrName(string str) { baseAddrNameTextBox.Text = str; }
        /// <summary>
        /// 设置baseAddrNum
        /// </summary>
        /// <param name="str"></param>
        public void SetBaseAddrNum(string str) { baseAddrNumTextBox.Text = str; }
    }
}
