using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Personal
{
    public partial class SendMail : Form
    {
        List<PendingInformation> pendingList = new List<PendingInformation>();
        string senderEmail = "donotreplyphchs@gmail.com";
        string smtpAddress = "smtp.gmail.com";
        static string password = "PALLADIUM123";
        static int portNumber = 587;
        static bool enableSSL = true;
        SqlConnection connection;

        public SendMail()
        {
            this.InitializeComponent();

            this.GetSqlConnection();
            
            var cmd = new SqlCommand
            {
                Connection = connection,
                CommandText = "select Flats.FlatNo FlatNo,isnull(Name,'') Name, isnull(Email,'') Email, isnull(Principal,0) Principal, isnull(Interest,0) Interest from Flats Inner Join MonthlyReminder on Flats.FlatNo=MonthlyReminder.FlatNo where SentStatus=0 and Email<>'none'"
            };

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.pendingList.Add(new PendingInformation
                    {
                        FlatNo = reader["FlatNo"].ToString(),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Principal = Convert.ToDecimal(reader["Principal"].ToString()),
                        Interest = Convert.ToDecimal(reader["Interest"].ToString())

                    });

                }

            }
        }



        void button1_Click(object sender, EventArgs e)
        {
            var logFileName = DateTime.Today.ToString("ddMMMyyyy") + ".txt";
            foreach (var pendingInfo in this.pendingList)
            {
                try
                {
                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress(this.senderEmail);
                        mail.To.Add(pendingInfo.Email);
                        mail.Subject = $"{pendingInfo.FlatNo}-Pending Maintenance as on {this.txtPeriodText.Text}";
                        mail.Body = pendingInfo.MessageBody(this.txtPeriodText.Text, this.txtDueDate.Text);
                        mail.IsBodyHtml = true;
                        //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                        using (SmtpClient smtp = new SmtpClient(this.smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(this.senderEmail, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }

                        this.UpdateStatus(true, pendingInfo.FlatNo);

                        File.AppendAllText($@"C:\TestDevelopment\Personal\Personal\Log\{logFileName}", $"{pendingInfo.Email}|Success\n");
                    }

                }
                catch (Exception)
                {
                    File.AppendAllText($@"C:\TestDevelopment\Personal\Personal\Log\{logFileName}", $"{pendingInfo.Email}|Failed\n");
                }

            }
            MessageBox.Show("Message(s) Sent");
        }

        void GetSqlConnection()
        {
            if(connection==null || connection.State==System.Data.ConnectionState.Closed)
            {
                connection = new SqlConnection("Data Source=ILPT547;Initial Catalog=Palladium;Integrated Security=SSPI;User ID=vijay;Password=vijay;");
                connection.Open();
            }            
        }

        void UpdateStatus(bool status, string flatNo)
        {
            if (status == false)
            {
                return;
            }
            this.GetSqlConnection();
            var cmd = new SqlCommand
            {
                Connection = connection,
                CommandText = $"Update MonthlyReminder set sentstatus=1 where FlatNo= '{flatNo}'"
            };
            cmd.ExecuteNonQuery();
        }

    }
}
