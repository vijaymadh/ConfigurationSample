using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;
using System.Threading;
 

namespace ParseHTML
{
    //public class htmlParser
    //{
    //    public htmlParser() { }
    //    private string res;
    //    StringBuilder userIds = new StringBuilder();

    //    public StringBuilder doParsing(string html)
    //    {
    //        Thread t = new Thread(TParseMain);
    //        t.ApartmentState = ApartmentState.STA;
    //        t.Start((object)html);
    //        t.Join();         

    //        return userIds;
    //    }

    //    private void TParseMain(object html)
    //    {
    //        WebBrowser wbc = new WebBrowser();
    //        wbc.DocumentText = "feces of a dummy";        //;magic words        
    //        HtmlDocument doc = wbc.Document.OpenNew(true);
    //        doc.Write((string)html);
    //        var elemetns = doc.GetElementsByTagName("span");

    //        for (var i = 0; i <  elemetns.Count; i++)
    //        {
    //            var attr = "";
    //            attr = elemetns[i].GetAttribute("userId");
    //            userIds.Append(attr + ";");
    //        }         
    //    }
    //}
    public class htmlParser
    {
        StringBuilder userids = new StringBuilder();

        public StringBuilder TParseMain(string html)
        {

            var doc = new HtmlDocument();
            doc.LoadHtml((string)@html);
          
            StringBuilder userIds = new StringBuilder();
            var spanNodes = doc.DocumentNode.SelectNodes("//*[@class=\"teamuser\"]");
            foreach (var node in spanNodes)
            {
                var attr = node.GetAttributeValue("userId","1");
                userids.Append("'" + attr);
            }
            return userids;
        }
    }
}
