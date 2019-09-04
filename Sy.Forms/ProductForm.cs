﻿using Sy.Bussiness.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities;
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
    public partial class ProductForm : Form
    {
        private readonly IRepository<Product, Guid> _productRepo;
        public ProductForm()
        {
            InitializeComponent();           
            _productRepo = new Repository<Product, Guid>();
            ListeyiDoldur();
        }
        private void ListeyiDoldur(string search = "")
        {
            var data = _productRepo.Query(x => x.ProductName.Contains(search)).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                CriticStock = x.CriticStock,
                ProductName = x.ProductName
            }).ToList();
            lstUrunler.DataSource = data;
            lstUrunler.DisplayMember = "Display";
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                _productRepo.Insert(new Product()
                {
                    ProductName = txtUrunAdi.Text,
                    UnitPrice = nudFiyat.Value,
                    CriticStock = Convert.ToInt32(nudKritikStok.Value)
                });
                MessageBox.Show("Ürün ekleme işlemi başarılı");
                ListeyiDoldur();
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Test", Ex.Message);
            }

        }

        private void lstUrunler_KeyUp(object sender, KeyEventArgs e)
        {
            ListeyiDoldur(txtUrunAra.Text);
        }
    }
}
