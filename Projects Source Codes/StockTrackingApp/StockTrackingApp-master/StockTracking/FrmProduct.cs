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
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
        public ProductDTO dto = new ProductDTO();
        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isUpdate = false;
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (isUpdate)
            {
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                cmbCategory.SelectedValue = detail.CategoryID;
            }

        }
        ProductBLL bll = new ProductBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Product Name is Empty");
            else if (cmbCategory.SelectedIndex == -1)
                MessageBox.Show("Please select a category");
            else if (txtPrice.Text.Trim() == "")
                MessageBox.Show("Price is empty");
            else
            {
                if (!isUpdate)//Add
                {
                    ProductDetailDTO product = new ProductDetailDTO();
                    product.ProductName = txtProductName.Text;
                    product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    product.Price = Convert.ToInt32(txtPrice.Text);
                    if (bll.Insert(product))
                    {
                        MessageBox.Show("Product was added");
                        txtPrice.Clear();
                        txtProductName.Clear();
                        cmbCategory.SelectedIndex = -1;
                    }

                }
                else
                {
                    if (detail.ProductName == txtProductName.Text &&
                        detail.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.Price == Convert.ToInt32(txtPrice.Text))
                        MessageBox.Show("There is no change");
                    else
                    {
                        detail.ProductName = txtProductName.Text;
                        detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.Price = Convert.ToInt32(txtPrice.Text);
                        if(bll.Update(detail))
                        {
                            MessageBox.Show("Product wa Updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
