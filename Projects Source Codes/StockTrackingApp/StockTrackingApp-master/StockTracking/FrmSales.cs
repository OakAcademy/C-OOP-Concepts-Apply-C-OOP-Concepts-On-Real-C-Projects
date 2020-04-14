using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;


namespace StockTracking
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        private void txtProductSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public SalesDTO dto = new SalesDTO();
        public SalesDetailDTO detail = new SalesDetailDTO();
        public bool isUpdate = false;
        private void FrmSales_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
           if(!isUpdate)
            {
                gridProduct.DataSource = dto.Products;
                gridProduct.Columns[0].HeaderText = "Product Name";
                gridProduct.Columns[1].HeaderText = "Category Name";
                gridProduct.Columns[2].HeaderText = "Stock Amount";
                gridProduct.Columns[3].HeaderText = "Price";
                gridProduct.Columns[4].Visible = false;
                gridProduct.Columns[5].Visible = false;
                gridCustomer.DataSource = dto.Customers;
                gridCustomer.Columns[0].Visible = false;
                gridCustomer.Columns[1].HeaderText = "Customer Name";
                if (dto.Categories.Count > 0)
                    combofull = true;
            }
           else
            {
                panel1.Hide();
                txtCustomerName.Text = detail.CustomerName;
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                txtProductSalesAmount.Text = detail.SalesAmount.ToString();
                ProductDetailDTO product = dto.Products.First(x => x.ProductID == detail.ProductID);
                detail.StockAmount = product.StockAmount;
                txtStock.Text = detail.StockAmount.ToString();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductSalesAmount.Text.Trim() == "")
                MessageBox.Show("Please fill the sales amount area");
            
            else
            {
                if(!isUpdate)//Add
                {
                     if (detail.ProductID == 0)
                        MessageBox.Show("Please select a product from product table");
                    else if (detail.CustomerID == 0)
                        MessageBox.Show("Please select a customer from customer table");
                    else if (detail.StockAmount < Convert.ToInt32(txtProductSalesAmount.Text))
                        MessageBox.Show("You have bot enough product for sale");
                     else
                    {
                        detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                        detail.SalesDate = DateTime.Today;
                        if (bll.Insert(detail))
                        {
                            MessageBox.Show("Sales was added");
                            bll = new SalesBLL();
                            dto = bll.Select();
                            gridProduct.DataSource = dto.Products;
                            dto.Customers = dto.Customers;
                            combofull = false;
                            cmbCategory.DataSource = dto.Categories;
                            if (dto.Products.Count > 0)
                                combofull = true;
                            txtProductSalesAmount.Clear();

                        }
                    }
                  

                }
                else//Update
                {
                    if (detail.SalesAmount == Convert.ToInt32(txtProductSalesAmount.Text))
                        MessageBox.Show("There is no chnage");
                    else
                    {
                        int temp = detail.StockAmount + detail.SalesAmount;
                        if (temp < Convert.ToInt32(txtProductSalesAmount.Text))
                            MessageBox.Show("You have not enough product for sale");
                        else
                        {
                            detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                            detail.StockAmount = temp - detail.SalesAmount;
                            if(bll.Update(detail))
                            {
                                MessageBox.Show("Sales was Updated");
                                this.Close();
                            }
                           

                        }

                    }
                }
            }

        }
        bool combofull = false;
        SalesBLL bll = new SalesBLL();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();
                }

            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerSearch.Text)).ToList();
            gridCustomer.DataSource = list;
            if (list.Count == 0)
                txtCustomerName.Clear();
        }
       
        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[5].Value);
            txtProductName.Text = detail.ProductName;
            txtPrice.Text = detail.Price.ToString();
            txtStock.Text = detail.StockAmount.ToString();
        }

        private void gridCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerName = gridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.CustomerID = Convert.ToInt32(gridCustomer.Rows[e.RowIndex].Cells[0].Value);
            txtCustomerName.Text = detail.CustomerName;
        }
    }
}
