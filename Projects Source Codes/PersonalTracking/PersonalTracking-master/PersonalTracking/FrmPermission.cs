using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using DAL.DTO;

namespace PersonalTracking
{
    public partial class FrmPermission : Form
    {
        public FrmPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TimeSpan PermissionDay;
        public bool isUpdate = false;
        public PermissionDetailDTO detail = new PermissionDetailDTO();
        private void FrmPermission_Load(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNo.ToString();
            if(isUpdate)
            {
                dpStart.Value = detail.StartDate;
                dpEnd.Value = detail.EndDate;
                txtDayAmount.Text = detail.PermissionDayAmount.ToString();
                txtExplanation.Text = detail.Explanation;
                txtUserNo.Text = detail.UserNo.ToString();
            }
           
        }

        private void dpStart_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpEnd.Value.Date - dpStart.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void dpEnd_ValueChanged(object sender, EventArgs e)
        {

            PermissionDay = dpEnd.Value.Date - dpStart.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
                MessageBox.Show("please change end or start date");
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
                MessageBox.Show("Permission day must be bigger than 0");
            else if (txtExplanation.Text.Trim() == "")
                MessageBox.Show("Explanation is empty");
            else
            {
                PERMISSION permission = new PERMISSION();
                if (!isUpdate)
                {
                    permission.EmployeeID = UserStatic.EmployeeID;
                    permission.PermissionState = 1;
                    permission.PermissionStartDate = dpStart.Value.Date;
                    permission.PermissionEndDate = dpEnd.Value.Date;
                    permission.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                    permission.PermissionExplanation = txtExplanation.Text;
                    PermissionBLL.AddPermission(permission);
                    MessageBox.Show("Permission was Added");
                    permission = new PERMISSION();
                    dpStart.Value = DateTime.Today;
                    dpEnd.Value = DateTime.Today;
                    txtDayAmount.Clear();
                    txtExplanation.Clear();
                }
                else if(isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButtons.YesNo);
                    if(result==DialogResult.Yes)
                    {
                        permission.ID = detail.PermissionID;
                        permission.PermissionExplanation = txtExplanation.Text;
                        permission.PermissionStartDate = dpStart.Value;
                        permission.PermissionEndDate = dpEnd.Value;
                        permission.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                        PermissionBLL.UpdatePermission(permission);
                        MessageBox.Show("Permission was Updated");
                        this.Close();
                    
                    }

                }


            }
        }
    }
}
