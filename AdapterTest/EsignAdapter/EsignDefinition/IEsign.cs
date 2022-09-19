using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsignDifinition
{
    public interface IEsign
    {
        string Send();
        string OverrideTest();
        string Implementation { get; }
    }
}
