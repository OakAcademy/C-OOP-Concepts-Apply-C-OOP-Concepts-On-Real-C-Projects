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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCategoryName.Text = detail.CategoryName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == "")
                MessageBox.Show("Category Name is empty");
            else
            {
                if(!isUpdate)//Add
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategoryName.Text;
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("Category was added");
                        txtCategoryName.Clear();
                    }
                }
                else if(isUpdate)
                {
                    if (detail.CategoryName == txtCategoryName.Text.Trim())
                        MessageBox.Show("There is No change");
                    else
                    {

                        detail.CategoryName = txtCategoryName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Category was Updated");
                            this.Close();

                        }
                    }
                }

            }
        }
    }
}
