using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ConfigurationValidation.ReadXmlDocumenation.Models;

namespace ConfigurationValidation.ReadXmlDocumenation
{
    public partial class ReadXmlDocument : Form
    {
        public ReadXmlDocument()
        {
            InitializeComponent();
        }

        private void btnSelectfile_Click(object sender, EventArgs e)
        {
            var members = new List<Member>();
            var file = openFile.ShowDialog();
            var doc = XDocument.Load(openFile.FileName);
            var topElement = doc.Descendants("members").ToList().FirstOrDefault();

            var xmlMembers = topElement.Descendants("member").ToList();

            foreach (var xmlMember in xmlMembers)
            {
                var name = xmlMember.Attribute("name").Value;
                var type = xmlMember.Attribute("name").Value.Split(':')[0];
                name = xmlMember.Attribute("name").Value.Split(':')[1];
                var summary = "";
                var paramList = new Dictionary<string, string>();
                var otherInfoList = xmlMember.Descendants().ToList();

                foreach (var info in otherInfoList)
                {
                    switch (info.Name.ToString())
                    {
                        case "summary":
                            summary = info.Value;
                            break;
                        case "param":
                            var paramName = info.Attribute("name").Value;
                            var paramSummary = info.Value;
                            paramList.Add(paramName, paramSummary);
                            break;
                    }
                }

                members.Add(new Member
                {
                    Name = name,
                    Summary = summary,
                    Type = type,
                    Parameters = paramList
                });
            }

            dataGridView1.DataSource = members;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = 300;
            }
        }
    }
}
