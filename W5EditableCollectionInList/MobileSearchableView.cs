using System.Collections.Generic;

namespace W5EditableCollectionInList
{
    public class MobileSearchableView : EditableCollectionViewModel
    {
        public MobileSearchableView(List<object> items) : base(items)
        {
        }
        protected override string DisplayItem(object item)
        {
            Mobile mobile = (Mobile)item;
            return mobile.Name;
        }
        protected override bool Validate(object item)
        {
            Mobile mobile = (Mobile)item;
            return mobile?.Name.ToLower().Contains(SearchValue?.ToLower() ?? "") ?? false;
        }
    }
}