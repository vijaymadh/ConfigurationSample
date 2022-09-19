using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationValidation.Other
{

    class baseclass
    {
        public virtual void MyMethod()
        {

        }

    }

    class baseclass2:baseclass
    {
        public sealed override void MyMethod()
        {

        }

    }


    class Other
    {

        

    }
}
