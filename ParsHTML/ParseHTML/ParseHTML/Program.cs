using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = "<div id='Main'>Hi Mr <span class='teamuser' contenteditable='false' style='color: blue; user - select:none; ' unselectable='on' userid='1'>@CLM Admin</span>&nbsp;<div><br /></div><div>This is a change requested by <span class='teamuser' contenteditable='false' style='color: blue; user - select:none; ' unselectable='on' userid='4'>@Laxman Jadhav</span>&nbsp; &nbsp;and will be done by <span class='teamuser' contenteditable='false' style='color: blue; user - select:none; ' unselectable='on' userid='3'>@Vijay Soni</span>&nbsp;</div></div>";
            (new htmlParser()).TParseMain(html);
        }
    }
}
