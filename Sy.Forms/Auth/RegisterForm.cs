using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sy.Bussiness.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities; // Client için ekledik
using Sy.Core.Enums;
using Sy.Core.ViewModels;

namespace Sy.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        private readonly IRepository<Client, int> _ClientRepository;
        public RegisterForm()
        {
            InitializeComponent();
            _ClientRepository = new Repository<Client, int>();
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            var model = new RegisterViewModel()
            {
                Email = txtEmail.Text,
                Name = txtAd.Text,
                SurName = txtSoyad.Text,
                Password = txtSifre.Text
            };
            var kontrol = _ClientRepository.Query(x => x.Email == model.Email).Any();
            if (kontrol)
            {
                MessageBox.Show("Bu mail adresi kullanılmaktadır");
                return;
            }
            var musteriMi = _ClientRepository.Query().Any();
            _ClientRepository.Insert(new Client()
            {
                Email = model.Email,
                SurName = model.SurName,
                Password = model.Password,
                Name = model.Name,
                ApplicationRole = musteriMi ? ApplicationRole.Customer : ApplicationRole.Admin
            });
            MessageBox.Show("Kayıt Başarılıdır.");
            this.Close();
        }
    }
}
