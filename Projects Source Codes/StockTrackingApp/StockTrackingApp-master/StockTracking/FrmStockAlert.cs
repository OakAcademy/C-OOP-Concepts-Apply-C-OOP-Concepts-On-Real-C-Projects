using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FrmStockAlert : Form
    {
        public FrmStockAlert()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain();
            this.Hide();
            frm.ShowDialog();


        }
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FrmStockAlert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;
            if (dto.Products.Count == 0)
            {
                FrmMain frm = new FrmMain();
                this.Hide();
                frm.ShowDialog();
            }
            else
            {
                dataGridView1.Columns[0].HeaderText = "Product Name";
                dataGridView1.Columns[1].HeaderText = "Category Name";
                dataGridView1.Columns[2].HeaderText = "Stock Amount";
                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
           
        }
        ProductDetailDTO detaaaa = new ProductDetailDTO();

    }
}
