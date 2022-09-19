using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    public interface IAggrigate
    {
        IIterator GetIterator();
        string this[int indexItem] { set; get; }
        int Count { get; }
    }
}
