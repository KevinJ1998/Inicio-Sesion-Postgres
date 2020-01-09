using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Postgres
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            "localhost","50001","psotgres",
            "ntsg_areg13","login");
        private NpgsqlCommand cmd;
        private string sql = null;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from u_login(:_username,:_password)";
                cmd = new NpgsqlCommand(sql,conn);

                cmd.Parameters.AddWithValue("_username",txtUser);
                cmd.Parameters.AddWithValue("_password", txtPassword);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    this.Hide();
                    new MainForm(txtUser.Text).Show();
                }else
                {
                    MessageBox.Show("Revisa tu correo o contaseña","Error",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }
                conn.Close();

            } catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message,"Something went wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
                conn.Close();
            }
 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
