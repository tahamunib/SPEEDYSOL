using SPEEDYBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPEEDYAPPWIN.Forms.Accounting.AccountGroup
{
    public partial class AccountGroupForm : Form
    {
        BindingSource bindingSource = new BindingSource();
        private const int totalRecords = 43;
        private int skip = 10;
        public AccountGroupForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            AccountGroupsTab.Width = this.Width;
            AccountGroupsTab.Height = this.Height;
            dataGridAccGrp.ScrollBars = ScrollBars.Both;
            dataGridAccGrp.ReadOnly = true;
            


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAccGrpName.Text))
            {
                SPEEDYDAL.AccountGroup accountGroup = new SPEEDYDAL.AccountGroup
                {
                    Name = tbAccGrpName.Text
                };
                SSAccountGroupsLINQ.SaveAccount(accountGroup);
            }
            else
            {
                MessageBox.Show("Please enter a name for Account Group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridAccGrp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AccountGroupForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridAccGrp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridAccGrp.Columns["AccountCategory"].Visible = false;
        }

        private void List_Enter(object sender, EventArgs e)
        {
            bindingSource.DataSource = SSAccountGroupsLINQ.GetAccountGroups();
            dataGridAccGrp.DataSource = bindingSource;
            
            datagridAccGrpNavigator.BindingSource = bindingSource;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = SSAccountGroupsLINQ.GetAccountGroups(skip);
            skip = skip + 10;
        }

        private void dataGridAccGrp_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = SSAccountGroupsLINQ.GetAccountGroups(skip);
        }
    }
}
