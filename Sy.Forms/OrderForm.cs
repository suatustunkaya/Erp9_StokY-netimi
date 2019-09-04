using Sy.Bussiness.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities;
using Sy.Core.Enums;
using Sy.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sy.Forms
{
    public partial class OrderForm : Form
    {
        private readonly IRepository<Product, Guid> _productRepo;
        private readonly IRepository<ProductStockAction, long> _productStockAction;
        public OrderForm()
        {
            InitializeComponent();
            _productRepo = new Repository<Product, Guid>();
            _productStockAction = new Repository<ProductStockAction, long>();
            ListeyiDoldur();
        }

        private void ListeyiDoldur(string search = "")
        {
            var data = _productRepo.Query(x => x.ProductName.Contains(search)).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                CriticStock = x.CriticStock,
                ProductName = x.ProductName,
                UnitsInStock = x.ProductStockActions.Where(y => y.StockActionType == StockActionType.Incoming).Sum(y => y.Quantity) - x.ProductStockActions.Where(y => y.StockActionType == StockActionType.Outgoing).Sum(y => y.Quantity)
            }).ToList();
            lstUrunler.DataSource = data;
            lstUrunler.DisplayMember = "Display";
        }

        private void txtAra_KeyUp(object sender, KeyEventArgs e)
        {
            ListeyiDoldur(txtAra.Text);
        }

        private ProductViewModel seciliUrun;
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null) return;
            seciliUrun = lstUrunler.SelectedItem as ProductViewModel;
            lblUrunAdi.Text = seciliUrun.ProductName;
            lblStokMiktari.Text = seciliUrun.UnitsInStock.ToString();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                _productRepo.Insert(new ProductStockAction()
                {
                    ProductId = seciliUrun.Id,
                    Quantity = Convert.ToInt32(nudEklenecekMiktar.Value),
                    UnitPrice = nudAlisFiyati.Value,
                    StockActionType = StockActionType.Incoming
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
