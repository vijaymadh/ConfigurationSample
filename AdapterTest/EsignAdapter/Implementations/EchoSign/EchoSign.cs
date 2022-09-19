using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsignDifinition;

namespace EchoSign
{
    public class EchoSign : IEsign
    {
        public virtual string Implementation => "EchoSign";

        public virtual string OverrideTest()
        {
            return "I will implement EchoSign.OverrideTest";
        }

        public virtual string Send()
        {
            return "I will implement EchoSign.Send";
        }
    }
}
