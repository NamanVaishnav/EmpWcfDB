using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpService" in both code and config file together.
    [ServiceContract]
    public interface IEmpService
    {
        [OperationContract]
        void AddEmployee(Employee emp);

        [OperationContract]
        Employee FindEmployee(int empid);

        [OperationContract]
        bool UpdateEmployee(int empid, Employee emp);

        [OperationContract]
        bool DeleteEmployee(int empid);

        [OperationContract]
        List<Employee> GetEmployees();
    }
}
