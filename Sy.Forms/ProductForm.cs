using Sy.Bussiness.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities;
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
    public partial class ProductForm : Form
    {
        private readonly IRepository<Product, Guid> _productRepo;
        public ProductForm()
        {
            InitializeComponent();
            _productRepo = new Repository<Product, Guid>();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _productRepo.Insert(new Product()
            {
                ProductName = txtUrunAdi.Text,
                UnitPrice = nudFiyat.Value,
                CriticStock = Convert.ToInt32(nudKritikStok.Value)
            });
            MessageBox.Show("Ürün ekleme işlemi başarılı");
        }
    }
}
