using DemoLib;
using DemoLib.Views;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard: UserControl, IProductsView
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        public void Show(Product product)
        {
            CategoryLabel.Text = product.Category;
            CountLabel.Text = product.Count.ToString();
            PartsLabel.Text = product.Parts;

        }
    }
}
