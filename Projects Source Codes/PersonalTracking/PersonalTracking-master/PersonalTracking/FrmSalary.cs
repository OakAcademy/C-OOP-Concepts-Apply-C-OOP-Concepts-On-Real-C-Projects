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
using DAL.DTO;
using BLL;

namespace PersonalTracking
{
    public partial class FrmSalary : Form
    {
        public FrmSalary()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SalaryDTO dto = new SalaryDTO();
        private bool combofull;
        public SalaryDetailDTO detail = new SalaryDetailDTO();
        public bool isUpdate = false;
        
        private void FrmSalary_Load(object sender, EventArgs e)
        {
            dto = SalaryBLL.GetAll();
            if(!isUpdate)
            {
                dataGridView1.DataSource = dto.Employees;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "User No";
                dataGridView1.Columns[2].HeaderText = "Name";
                dataGridView1.Columns[3].HeaderText = "Surname";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                combofull = false;
                cmbDepartment.DataSource = dto.Departments;
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "ID";

                cmbPosition.DataSource = dto.Positions;
                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.ValueMember = "ID";
                cmbDepartment.SelectedIndex = -1;
                cmbPosition.SelectedIndex = -1;
                if (dto.Departments.Count > 0)
                    combofull = true;

            }
            cmbMonth.DataSource = dto.Months;
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "ID";
            cmbMonth.SelectedIndex = -1;
            if(isUpdate)
            {
                panel1.Hide();
                txtName.Text = detail.Name;
                txtSalary.Text = detail.SalaryAmount.ToString();
                txtSurname.Text = detail.Surname;
                txtYear.Text = detail.SalaryYear.ToString();
                cmbMonth.SelectedValue = detail.MonthID;
            }

            
        }
        SALARY salary = new SALARY();
        int oldsalary = 0;
        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtYear.Text = DateTime.Today.Year.ToString();
            salary.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            oldsalary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);

           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          if (txtYear.Text.Trim() == "")
                MessageBox.Show("year is empty");
            else if (txtSalary.Text.Trim() == "")
                MessageBox.Show("Salary is empty");
            else if (cmbMonth.SelectedIndex == -1)
                MessageBox.Show("Select a month");
            else
            {
                bool control = false;
                if (!isUpdate)
                {
                    if (salary.EmployeeID == 0)
                        MessageBox.Show("please select an employee from table");
                    else
                    {
                        salary.Year = Convert.ToInt32(txtYear.Text);
                        salary.MonthID = Convert.ToInt32(cmbMonth.SelectedValue);
                        salary.Amount = Convert.ToInt32(txtSalary.Text);
                        if (salary.Amount > oldsalary)
                            control = true;
                        SalaryBLL.AddSalary(salary,control);
                        MessageBox.Show("Salary was added");
                        cmbMonth.SelectedIndex = -1;
                        salary = new SALARY();
                    }

                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "title", MessageBoxButtons.YesNo);
                    if(DialogResult.Yes==result)
                    {
                        SALARY salary = new SALARY();
                        salary.ID = detail.SalaryID;
                        salary.EmployeeID = detail.EmployeeID;
                        salary.Year = Convert.ToInt32(txtYear.Text);
                        salary.MonthID = Convert.ToInt32(cmbMonth.SelectedValue);
                        salary.Amount = Convert.ToInt32(txtSalary.Text);
                        
                        if (salary.Amount > detail.oldSalary)
                            control = true;
                        SalaryBLL.UpdateSalary(salary, control);
                        MessageBox.Show("Salary was Uptaded");
                        this.Close();


                    }

                }
                
            }


        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
                List<EmployeeDetailDTO> list = dto.Employees;
                dataGridView1.DataSource = list.Where(x => x.DepartmentID ==
                  Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }

        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {

                List<EmployeeDetailDTO> list = dto.Employees;
                dataGridView1.DataSource = list.Where(x => x.PositionID ==
                  Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            }
        }
    }
}
