using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace EmpDbDemo
{
    public partial class ViewEmployee : PhoneApplicationPage
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            EmpWcfDB.EmpReference1.EmpServiceClient ec = new EmpWcfDB.EmpReference1.EmpServiceClient();
            ec.GetEmployeesAsync();
            ec.GetEmployeesCompleted += ec_GetEmployeesCompleted;

            
        }

        private void ec_GetEmployeesCompleted(object sender, EmpWcfDB.EmpReference1.GetEmployeesCompletedEventArgs e)
        {
            ObservableCollection<EmpWcfDB.EmpReference1.Employee> lemp = e.Result;
            listEmployee.ItemsSource = lemp.ToList();
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmpWcfDB.EmpReference1.Employee emp = (EmpWcfDB.EmpReference1.Employee)listEmployee.SelectedItem;
            Uri u = new Uri("/EditEmployee.xaml?eid=" + emp.Emp_ID, UriKind.Relative);
            NavigationService.Navigate(u);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            EmpWcfDB.EmpReference1.Employee emp = (EmpWcfDB.EmpReference1.Employee)listEmployee.SelectedItem;
            EmpWcfDB.EmpReference1.EmpServiceClient ec = new EmpWcfDB.EmpReference1.EmpServiceClient();
            ec.DeleteEmployeeAsync(emp.Emp_ID);
            ec.GetEmployeesAsync();
            ec.GetEmployeesCompleted += ec_GetEmployeesCompleted;





        }
    }
}