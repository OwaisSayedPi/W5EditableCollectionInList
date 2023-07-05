using System.Collections.Generic;

namespace W5EditableCollectionInList
{
    public class OrderSearchableViewModel : EditableCollectionViewModel
    {
        public OrderSearchableViewModel(List<object> items) : base(items)
        {
        }
        protected override string DisplayItem(object item)
        {
            Order order = (Order)item;
            return order.Location;
        }
        protected override bool Validate(object item)
        {
            Order order = (Order)item;
            return order?.Location.ToLower().Contains(SearchValue?.ToLower() ?? "") ?? false;
        }
    }
}