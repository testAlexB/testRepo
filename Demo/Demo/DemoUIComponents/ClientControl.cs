using System.Drawing;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ClientControl: UserControl
    {
        private Color initColor_;
        public ClientControl()
        {
            InitializeComponent();
            initColor_ = this.BackColor;
        }

        private void ClientControl_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void ClientControl_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = initColor_;
        }
    }
}
