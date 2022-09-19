using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ArrayManipulation
{
    public class ABCString
    {

       public int GetABCCount(string data, out string toShow)
        {
            var a = string.Empty;
            var b = string.Empty;
            var c = string.Empty;

            var count = 0;
            var array = data.ToCharArray();
            toShow = "";
            for (int i = 1; i <= array.Length - 1; i++)
            {
                a = data.Substring(0, i);
                for (int j = 1; j <= array.Length - i; j++)
                { 
                    b = data.Substring(i, j);
                    c = data.Substring(i + j, array.Length - 1);

                    toShow+=$"a={a} b={b} c={c}\n" ;
                    if(! ((a+b==b+c) && (b + c ==  c+a) && ( c + a==a+b)))
                    {
                        count++;
                    }
                }
            }
            return count;

        }
    }
}
