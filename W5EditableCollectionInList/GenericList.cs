using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5EditableCollectionInList
{
    public class GenericClass<T>
    {
        public List<T> genericList { get; set; }
        public GenericClass(List<T> genericList)
        {
            this.genericList = genericList;            
        }
    }
}
