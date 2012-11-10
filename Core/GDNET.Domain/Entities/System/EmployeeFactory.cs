using System;

namespace GDNET.Domain.Entities.System
{
    public partial class Employee
    {
        public static EmployeeFactory Factory
        {
            get { return new EmployeeFactory() { }; }
        }

        public class EmployeeFactory
        {
            public Employee Create()
            {
                return new Employee()
                {
                    StartDate = DateTime.Now
                };
            }
        }
    }
}
