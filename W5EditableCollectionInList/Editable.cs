using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5EditableCollectionInList
{
    public class Editable : BaseViewModel
    {
        public string PropName { get; set; }
        private string _propValue;
        private Action<string, string> valueEdit;

        public string PropValue
        {
            get { return _propValue; }
            set
            {
                if (PropValue is null)
                {
                    _propValue = value;
                }
                if (PropValue != value)
                {
                    valueEdit?.Invoke(PropValue, value);
                }
                _propValue = value;
                OnPropertyChanged(nameof(PropValue));
            }
        }

        public Editable(Action<string, string> valueEdit)
        {
            this.valueEdit = valueEdit;
        }
    }
}
