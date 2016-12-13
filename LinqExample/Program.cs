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
        public Program()
        {
            var products = new List<Product> {
                                new Product {ProductID = 1, ProductName = "first candy", UnitPrice = (decimal)10.0m },
                                new Product {ProductID = 2, ProductName = "second vegetable", UnitPrice = (decimal)15.0m },
                                new Product {ProductID = 3, ProductName = "third candy", UnitPrice = (decimal)21.0m},
                                new Product {ProductID = 4, ProductName = "fourth vegetable", UnitPrice = (decimal)26.0m },
                                new Product {ProductID = 5, ProductName = "fifth candy", UnitPrice = (decimal)32.0m },
                                };
            var productCandy = products.Where(p => p.ProductName.Contains("candy"));
            productCandy = productCandy.ToList<Product>();
            _Items = productCandy.ToList();
            Items = _Items;
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
