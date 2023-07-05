using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5EditableCollectionInList
{
    public class EditableCollectionViewModel : BaseViewModel
    {
        public EditableCollectionViewModel ActiveView { get; set; }
        protected string _searchValue { get; set; }
        public string SearchValue
        {
            get
            {
                return _searchValue;
            }
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(DisplayList));
                FilterDisplayList();
            }
        }
        protected string _selectedItem { get; set; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (SearchValue != value)
                {
                    SearchValue = value;
                }
                if (value != null)
                {
                    DisplayEditableSection(value);
                }
                OnPropertyChanged(nameof(SelectedItem));
                OnPropertyChanged(nameof(SearchValue));
            }
        }

        private void DisplayEditableSection(string value)
        {            
            EditableList = new ObservableCollection<Editable>();
            foreach (var item in MainList)
            {
                if (Validate(item))
                {
                    InitialiseEditableList(item);
                }
            }
            OnPropertyChanged(nameof(EditableList));
        }

        protected virtual void InitialiseEditableList(object item)
        {
        }
        protected virtual void ValueEdit(string currentValue,string newValue)
        {

        }
        public EditableCollectionViewModel(List<object> items)
        {
            MainList = new ObservableCollection<object>();
            foreach (var item in items)
            {
                MainList.Add(item);
            }
            InitialiseDisplayList();
        }
        protected virtual void InitialiseDisplayList()
        {
            DisplayList = new ObservableCollection<string>();
            foreach (var item in MainList)
            {
                DisplayList.Add(DisplayItem(item));
            }
            OnPropertyChanged(nameof(DisplayList));
        }

        protected virtual string DisplayItem(object item)
        {
            return item.ToString();
        }

        protected virtual void FilterDisplayList()
        {
            DisplayList = new ObservableCollection<string>();
            if (string.IsNullOrEmpty(SearchValue) || string.IsNullOrWhiteSpace(SearchValue))
            {
                InitialiseDisplayList();
            }
            else
            {
                foreach (var item in MainList)
                {
                    if (Validate(item))
                    {
                        DisplayList.Add(DisplayItem(item));
                    }
                }
            }
            OnPropertyChanged(nameof(DisplayList));
        }
        protected virtual bool Validate(object item)
        {
            return item.ToString().ToLower().Contains(SearchValue?.ToLower() ?? "");
        }
        public ObservableCollection<Editable> EditableList { get; set; }
        public ObservableCollection<object> MainList { get; set; }
        public ObservableCollection<string> DisplayList { get; set; }
    }
}
