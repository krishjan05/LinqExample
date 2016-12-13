using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    class Program: INotifyPropertyChanged
    {
        public List<Product> Items
        {
            get { return _Items; }
            set { _Items = value; OnPropertyChanged(); }
        }
        private List<Product> _Items;
        public List<Employee> EmployeeList
        {
            get { return _EmployeeList; }
            set { _EmployeeList = value; OnPropertyChanged(); }
        }
        private List<Employee> _EmployeeList;
        public Program()
        {
            var products = new List<Product> {
                                new Product {ProductID = 1, ProductName = "first candy", UnitPrice = (decimal)10.0m },
                                new Product {ProductID = 2, ProductName = "second vegetable", UnitPrice = (decimal)15.0m },
                                new Product {ProductID = 3, ProductName = "third candy", UnitPrice = (decimal)21.0m},
                                new Product {ProductID = 4, ProductName = "fourth vegetable", UnitPrice = (decimal)26.0m },
                                new Product {ProductID = 5, ProductName = "fifth candy", UnitPrice = (decimal)32.0m },
                                };

            var employee = new List<Employee> {
                                new Employee { EmployeeID = 101, EmployeeName = "Krishna Kanhaiya", Position = "Developer" },
                                new Employee { EmployeeID = 102, EmployeeName = "Harsh Mahale", Position = "iOS Developer" },
                                new Employee { EmployeeID = 103, EmployeeName = "Gurpreet Singh", Position = "Manager" },
                                new Employee { EmployeeID = 104, EmployeeName = "Harsimar Ahluwalia", Position = "Developer" },
                                new Employee { EmployeeID = 105, EmployeeName = "Tanmay Teckchandani", Position = "Developer" },
                                };
            
            var AllProductList = products.Select(p => new {p});

            var productCandy = products.Where(p => p.ProductName.Contains("candy"));
            productCandy = productCandy.ToList<Product>();
             _Items = productCandy.ToList();
             Items = _Items;

            var AllEmployee = from e in employee
                              select e;
            AllEmployee = AllEmployee.ToList<Employee>();
            _EmployeeList = AllEmployee.ToList();
            AllEmployee = _EmployeeList;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
