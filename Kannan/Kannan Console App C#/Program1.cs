using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Program
    {
  

        static void Main(string[] args)
        {
            var allRows = new List<ccVal>();
            var data = GetSampleData();
            var xmlList = new Dictionary<string, string>();
            var sbXml = new StringBuilder();
            var currentApp = string.Empty;
            var uidOrg = string.Empty;
            var appUrlValue = string.Empty;

            foreach (var ccval in data)
            {
                if (currentApp != ccval.CCC_Category && sbXml.Length > 0)
                {
                    if (!string.IsNullOrWhiteSpace(appUrlValue))
                    {
                        sbXml.AppendLine("<Entry>");
                        sbXml.AppendLine("<Key>appurl</Key>");
                        sbXml.AppendLine($"<Value>" + appUrlValue.TrimEnd((char)7) + "</Value>");
                        sbXml.AppendLine("</Entry>");
                        appUrlValue = string.Empty;
                    }

                    sbXml.Append("</AppData>");

                    xmlList.Add(uidOrg, sbXml.ToString());

                    sbXml = new StringBuilder();
                    sbXml.Append("<AppData>");
                }

                if (sbXml.Length <= 0)
                {
                    sbXml.Append("<AppData>");
                }

                if (ccval.CCC_SubCategory == "uidOrg")
                {
                    uidOrg = ccval.CCC_Value;
                }
                else if (ccval.CCC_SubCategory == "appurl")
                {
                    appUrlValue = appUrlValue + ccval.CCC_Value + ((char)7).ToString();
                }
                else
                {
                    sbXml.AppendLine("<Entry>");
                    sbXml.AppendLine("<Key>" + ccval.CCC_SubCategory + "</Key>");
                    sbXml.AppendLine($"<Value>" + ccval.CCC_Value + "</Value>");
                    sbXml.AppendLine("</Entry>");
                }

                currentApp = ccval.CCC_Category;
            }

            if (!string.IsNullOrWhiteSpace(appUrlValue))
            {
                sbXml.AppendLine("<Entry>");
                sbXml.AppendLine("<Key>appurl</Key>");
                sbXml.AppendLine("<Value>" + appUrlValue.TrimEnd((char)7) + "</Value>");
                sbXml.AppendLine("</Entry>");
            }

            sbXml.Append("</AppData>");
            xmlList.Add(uidOrg, sbXml.ToString());


            foreach (var key in xmlList.Keys)
            {
                Console.WriteLine("XML for " + key);
                Console.WriteLine(xmlList[key]);
            }

            Console.ReadLine();
        }

        private static List<ccVal> GetSampleData()
        {
            return new List<ccVal>()
                {
                new ccVal
                    {
                        CCC_Category="App1",
                        CCC_SubCategory="uidOrg",
                        CCC_Value="app1_uidOrg"
                    },
                    new ccVal
                    {
                        CCC_Category="App1",
                        CCC_SubCategory="LoginId",
                        CCC_Value="app1_Id"
                    },
new ccVal
                    {
                        CCC_Category="App1",
                        CCC_SubCategory="entity",
                        CCC_Value="app1_accounts"
                    },
new ccVal
                    {
                        CCC_Category="App1",
                        CCC_SubCategory="Job",
                        CCC_Value="app1_Support"
                    },
new ccVal
                    {
                        CCC_Category="App1",
                        CCC_SubCategory="appurl",
                        CCC_Value="app1Url1"
                    },
new ccVal
                    {
                        CCC_Category="App1",
                        CCC_SubCategory="appurl",
                        CCC_Value="app1Url2"
                    },     new ccVal
                    {
                        CCC_Category="App2",
                        CCC_SubCategory="uidOrg",
                        CCC_Value="app2_uidOrg"
                    },
                    new ccVal
                    {
                        CCC_Category="App2",
                        CCC_SubCategory="LoginId",
                        CCC_Value="app2_Id"
                    },
new ccVal
                    {
                        CCC_Category="App2",
                        CCC_SubCategory="entity",
                        CCC_Value="app2_accounts"
                    },
new ccVal
                    {
                        CCC_Category="App2",
                        CCC_SubCategory="Job",
                        CCC_Value="app2_Support"
                    },
new ccVal
                    {
                        CCC_Category="App2",
                        CCC_SubCategory="appurl",
                        CCC_Value="app2Url1"
                    }
                };
        }



    }
}