using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W5EditableCollectionInList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public EditableCollectionViewModel ProductList { get; set; }
        public EditableCollectionViewModel MobileList { get; set; }
        public EditableCollectionViewModel OrderList { get; set; }
        public EditableCollectionViewModel StringList { get; set; }
        public MainWindowViewModel()
        {
            MobileList = new MobileSearchableView( new List<object>()
            {
                new Mobile(){ Id = 101, Name = "Apple"},
                new Mobile(){ Id = 102, Name = "Huawei"},
                new Mobile(){ Id = 103, Name = "Motorola"},
                new Mobile(){ Id = 104, Name = "OnePlus"},
                new Mobile(){ Id = 100, Name = "Samsung"},
            });
            ProductList = new ProductSearchableViewModel( new List<object>() {
                new Product() { ProductID = 1, ProductName = "Milkshake"},
                new Product() { ProductID = 2, ProductName = "Apple Juice"},
                new Product() { ProductID = 3, ProductName = "Mocktail"},
                new Product() { ProductID = 4, ProductName = "Cocktail"},
                new Product() { ProductID = 5, ProductName = "On the Rocks"},
            });
            OrderList = new OrderSearchableViewModel( new List<object>()
            {
                new Order() { Id = 1001, Location = "Mumbai"},
                new Order() { Id = 1002, Location = "Alibaug"},
                new Order() { Id = 1003, Location = "Pune"},
                new Order() { Id = 1004, Location = "Konkan"},
                new Order() { Id = 1005, Location = "Lonavla"},
            });
        }        
    }
}
