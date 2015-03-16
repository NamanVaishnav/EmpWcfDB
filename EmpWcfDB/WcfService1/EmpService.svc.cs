using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmpService.svc or EmpService.svc.cs at the Solution Explorer and start debugging.
    public class EmpService : IEmpService
    {

        

        public void AddEmployee(Employee emp)
        {
            EmployeeDataContext ec = new EmployeeDataContext();
            ec.Employees.InsertOnSubmit(emp);
            ec.SubmitChanges();
        }

        public Employee FindEmployee(int empid)
        {
            EmployeeDataContext ec = new EmployeeDataContext();
            IEnumerable<Employee> lemp = from e in ec.Employees where e.Emp_ID == empid select e;
            Employee femp = lemp.FirstOrDefault();
            return femp;
        }

        public bool UpdateEmployee(int empid, Employee emp)
        {
            EmployeeDataContext ec = new EmployeeDataContext();
            IEnumerable<Employee> lemp = from e in ec.Employees where e.Emp_ID == empid select e;
            Employee femp = lemp.FirstOrDefault();
            if (femp != null)
            {
                femp.Emp_ID = emp.Emp_ID;
                femp.Emp_Name = emp.Emp_Name;
                femp.Emp_Salary = emp.Emp_Salary;
                ec.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(int empid)
        {
            EmployeeDataContext ec = new EmployeeDataContext();
            IEnumerable<Employee> lemp = from e in ec.Employees where e.Emp_ID == empid select e;
            Employee femp = lemp.FirstOrDefault();
            if (femp != null)
            {
                ec.Employees.DeleteOnSubmit(femp);
                ec.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> GetEmployees()
        {
            EmployeeDataContext ec = new EmployeeDataContext();
            return ec.Employees.ToList();
        }
    }
}
