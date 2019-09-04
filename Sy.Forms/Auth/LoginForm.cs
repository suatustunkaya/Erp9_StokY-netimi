using Sy.Bussiness.Repository;
using Sy.Core.Abstracts;
using Sy.Core.ComplexTypes;
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

namespace Sy.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private readonly IRepository<Client, int> _ClientRepository;
        public LoginForm()
        {
            InitializeComponent();
            _ClientRepository = new Repository<Client, int>();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            var model = new LoginViewModel()
            {
                Email = txtEmail.Text,
                Password = txtSifre.Text
            };
            var user = _ClientRepository.Query(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Email veya şifre hatalıdır.");
                return;
            }
            MessageBox.Show($"{user.Name} {user.SurName}");
            StockSettings.UserInfo = new UserInfoViewModel()
            {
                ID = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.SurName,
                ApplicationRole = user.ApplicationRole
            };
            this.Close();
        }
    }
}
