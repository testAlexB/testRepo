using System.Windows.Forms;

namespace Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < 13; ++i)
            {
                var control = new DemoUIComponents.ClientControl();
                MainLayout.Controls.Add(control);
            }
        }
    }
}
