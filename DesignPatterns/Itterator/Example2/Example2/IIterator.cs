using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    public interface IIterator
    {
        string FirstItem { get; set; }
        string NextItem { get; set; }
        string CurrentItem { get; set; }
        bool IssDone { get; set; }
    }
}
