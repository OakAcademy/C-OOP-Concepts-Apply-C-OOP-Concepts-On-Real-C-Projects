using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DTO;

namespace PersonalTracking
{
    public partial class FrmPosition : Form
    {
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<DEPARTMENT> departmentlist = new List<DEPARTMENT>();
        public PositionDTO detail = new PositionDTO();
        public bool isUpdate = false;
       
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            departmentlist = DepartmentBLL.GetDepartments();
            cmbDepartment.DataSource = departmentlist;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            if(isUpdate)
            {
                txtPosition.Text = detail.PositionName;
                cmbDepartment.SelectedValue = detail.DepartmentID;

            }
         

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
                MessageBox.Show("Please fill the position name");
            else if (cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("please select a department");
            else
            {
               if(!isUpdate)
                {
                    POSITION position = new POSITION();
                    position.PositionName = txtPosition.Text;
                    position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    BLL.PositionBLL.AddPosition(position);
                    MessageBox.Show("Position was added");
                    txtPosition.Clear();
                    cmbDepartment.SelectedIndex = -1;
                }
               else
                {
                    POSITION position = new POSITION();
                    position.ID = detail.ID;
                    position.PositionName = txtPosition.Text;
                    position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    bool control = false;
                    if (Convert.ToInt32(cmbDepartment.SelectedValue) != detail.OldDepartmentID)
                        control = true;
                    PositionBLL.UpdatePosition(position, control);
                    MessageBox.Show("Position was Updated");
                    this.Close();

                }

            }
        }
    }
}
