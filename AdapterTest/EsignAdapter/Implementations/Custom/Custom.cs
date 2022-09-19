using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsignDifinition;

namespace Custom
{
    public class Custom : IEsign
    {
        public string Implementation => "Custom";

        public string OverrideTest()
        {
            return "I will implement CustomSign.OverrideTest";
        }

        public string Send()
        {
            return "I will implement CustomSign.Send";
        }
    }
}
