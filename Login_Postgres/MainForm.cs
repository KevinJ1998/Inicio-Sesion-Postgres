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
    public partial class MainForm : Form
    {
        public MainForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }
        private string username;
    }
}
