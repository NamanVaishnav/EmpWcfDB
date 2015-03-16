using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using EmpWcfDB.EmpReference1;
//using EmpWcfDB.EmpReference;.



namespace EmpDbDemo
{
    public partial class NewEmployee : PhoneApplicationPage
    {
        public NewEmployee()
        {
            InitializeComponent();
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
            ec.AddEmployeeAsync(emp);
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}