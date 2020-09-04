using System.Windows.Forms;

namespace AutoAssemblyMaker.UI
{
    public partial class ValueAndValueName : UserControl
    {
        public ValueAndValueName()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 得到模式的对应二进制文本
        /// </summary>
        /// <returns></returns>
        public string GetValue() { return value.Text; }
        /// <summary>
        /// 得到模式对应的名字
        /// </summary>
        /// <returns></returns>
        public string GetValueName() { return valueName.Text; }
        /// <summary>
        /// 设置模式的对应二进制文本
        /// </summary>
        /// <param name="valuee"></param>
        public void SetValue(string valuee) { value.Text = valuee; }
        /// <summary>
        /// 设置模式对应的名字
        /// </summary>
        /// <param name="valueNamee"></param>
        public void SetValueName(string valueNamee) { valueName.Text = valueNamee; }
    }
}
