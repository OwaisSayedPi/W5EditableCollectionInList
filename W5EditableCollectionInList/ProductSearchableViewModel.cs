using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace W5EditableCollectionInList
{
    public class ProductSearchableViewModel : EditableCollectionViewModel
    {
        public ObservableCollection<object> ItemList { get; set; }
        public ProductSearchableViewModel(List<object> items) : base(items)
        {
            ItemList = new ObservableCollection<object>(items);
        }
        protected override string DisplayItem(object item)
        {
            Product product = (Product)item;
            if (SelectedItem == product.ProductName)
            {
                ActiveView = new ProductSearchableViewModel(new List<object>() {
                product });
                _searchValue = product.ProductName;
                OnPropertyChanged(nameof(DisplayList));
            }

            OnPropertyChanged(nameof(ActiveView));
            return product.ProductName;
        }
        protected override bool Validate(object item)
        {
            Product p = (Product)item;
            return p?.ProductName.ToLower().Contains(SearchValue?.ToLower() ?? "") ?? false;
        }
        protected override void InitialiseEditableList(object item)
        {
            Product product = (Product)item;
            foreach (var val in product.GetType().GetProperties())
            {
                Editable e = new Editable(ValueEdit);
                e.PropName = (val.Name);
                e.PropValue = (val.GetValue(product).ToString());
                EditableList.Add(e);
            }
            List<object> list = new List<object>(EditableList);
        }
        protected override void ValueEdit(string currentValue, string NewValue)
        {
            Product p = new Product();
            for (int i = 0; i < MainList.Count; i++)
            {
                if (Validate(MainList[i]))
                {
                    p = (Product)MainList[i];
                    foreach (var val in p.GetType().GetProperties())
                    {
                        if (p.ProductName == currentValue)
                        {
                            p.ProductName = NewValue;
                            _searchValue = NewValue;
                        }
                    }
                    MainList.RemoveAt(i);
                    MainList.Insert(i, p);
                }
            }
            FilterDisplayList();
        }
    }
}