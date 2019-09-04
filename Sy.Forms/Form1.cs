using Sy.Bussiness.Repository;
using Sy.Core.ComplexTypes;
using Sy.Core.Entities;
using Sy.Forms.Auth; // LoginForm için eklettik
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
    public partial class Form1 : Form
    {
        private Repository<Product, Guid> _productRepo;
        public Form1()
        {
            InitializeComponent();
            _productRepo = new Repository<Product, Guid>();
            gbGiris.Visible = true;
            lblGirisBilgi.Visible = false;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
            if (StockSettings.UserInfo == null)
            {
                gbGiris.Visible = true;
                lblGirisBilgi.Visible = false;
            }
            else
            {
                gbGiris.Visible = false;
                lblGirisBilgi.Visible = true;
                lblGirisBilgi.Text = StockSettings.UserInfo.Display;
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.ShowDialog();
        }


    }
}
