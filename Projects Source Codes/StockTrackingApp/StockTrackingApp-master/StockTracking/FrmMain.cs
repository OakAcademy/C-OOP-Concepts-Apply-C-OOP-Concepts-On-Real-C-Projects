using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmSalesList frm = new FrmSalesList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmProductList frm = new FrmProductList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomerList frm = new FrmCustomerList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            FrmAddStock frm = new FrmAddStock();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategoryList frm = new FrmCategoryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            FrmDeleted frm = new FrmDeleted();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
