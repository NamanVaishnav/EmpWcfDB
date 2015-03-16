using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace EmpDbDemo
{
    public partial class EditEmployee : PhoneApplicationPage
    {
        public EditEmployee()
        {
            InitializeComponent();
        }
        int eid = 0;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            eid = int.Parse(NavigationContext.QueryString["eid"]);
            EmpWcfDB.EmpReference1.EmpServiceClient ec = new EmpWcfDB.EmpReference1.EmpServiceClient();
            ec.FindEmployeeAsync(eid);
            ec.FindEmployeeCompleted += ec_FindEmployeeCompleted;
        }

        private void ec_FindEmployeeCompleted(object sender, EmpWcfDB.EmpReference1.FindEmployeeCompletedEventArgs e)
        {
            EmpWcfDB.EmpReference1.Employee emp = e.Result;
            if (emp != null)
            {
                txtID.Text = emp.Emp_ID.ToString();
                txtName.Text = emp.Emp_Name;
                txtSalary.Text = emp.Emp_Salary.ToString();
            }
        }

       
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            EmpWcfDB.EmpReference1.EmpServiceClient ec = new EmpWcfDB.EmpReference1.EmpServiceClient();
            EmpWcfDB.EmpReference1.Employee emp = new EmpWcfDB.EmpReference1.Employee
            {
                Emp_ID = int.Parse(txtID.Text),
                Emp_Name = txtName.Text,
                Emp_Salary = txtSalary.Text
            };

            ec.UpdateEmployeeAsync(int.Parse(txtID.Text), emp);

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}