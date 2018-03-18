using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPEEDYAPPWIN
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void dCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AccountCreate_Click(object sender, EventArgs e)
        {
            Forms.Accounting.AccountGroup.AccountGroupForm accountGroupForm = new Forms.Accounting.AccountGroup.AccountGroupForm();
            //accountGroupForm.Parent = this;
            this.IsMdiContainer = true;
            accountGroupForm.MdiParent = this;
            accountGroupForm.MainMenuStrip = this.mainMenu;
            accountGroupForm.Dock = DockStyle.Fill;
            accountGroupForm.FormBorderStyle = FormBorderStyle.None;
            accountGroupForm.ShowIcon = false;
            accountGroupForm.Show();
            accountGroupForm.WindowState = FormWindowState.Maximized;
        }
    }
}
