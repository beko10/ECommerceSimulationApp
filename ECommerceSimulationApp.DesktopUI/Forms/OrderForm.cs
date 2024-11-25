using ECommerceSimulationApp.BusinessLayer.Abstract;
using System.Data;

namespace ECommerceSimulationApp.DesktopUI.Forms;

public partial class OrderForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public OrderForm()
    {
        InitializeComponent();


    }

    private void OrderForm_Load(object sender, EventArgs e)
    {
        GetAllProductsBySearchText(string.Empty);
    }

    private async void GetAllProductsBySearchText(string searhText)
    {
        var searchProductResult = await _productService.SearchProduct(searhText, false);
        if (!searchProductResult.IsSuccess)
        {
            MessageBox.Show(searchProductResult.Message);
        }
        else
        {
            MessageBox.Show(searchProductResult.Message);
            lstBasket.DataSource = searchProductResult.Data;
            lstBasket.DisplayMember = "ProductName";
            lstBasket.ValueMember = "Id";
        }
    }

    private void btnAddBasket_Click(object sender, EventArgs e)
    {

    }

    private void btnNewOrder_Click(object sender, EventArgs e)
    {

    }

    private void btnSaveOrder_Click(object sender, EventArgs e)
    {

    }

    private void btnDelete_Click(object sender, EventArgs e)
    {

    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {

    }
}
