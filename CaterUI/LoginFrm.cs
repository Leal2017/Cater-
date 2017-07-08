using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
            miBll=new ManagerInfoBll();
        }

        private ManagerInfoBll miBll;
        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            int type;
            LoginState state = miBll.State(name, pwd, out type);
            switch (state)
            {
                case LoginState.OK:
                    FrmMain frm=new FrmMain();
                    frm.Tag = type;
                    frm.Show();
                    this.Hide();
                    break;
                case LoginState.NameError:
                    MessageBox.Show("没有该用户名，请君重新输入");
                    break;
                case LoginState.PwdError:
                    MessageBox.Show("用户密码输错，请重新输入");
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
