namespace Personal
{
    class PendingInformation
    {
        public string FlatNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public string MessageBody(string period, string dueDate)
        {   
            return $"Dear {this.FlatNo},<br><br>Total pending amount (including maintenance and interest) in your society account as on <b>{period}</b> is: <b>₹ {(this.Principal+this.Interest).ToString("0.00")}</b>." +
                $"<br/><br/>Please pay your pending amount on or before <b>{dueDate}</b> to avoid any late charges. <br/><br/>Please ignore if already paid." +
                $"<br/><br/>Regards, <br>Treasurer Palladium Homes. <br/><br/><p style='color:red'>" +
                "--------------------------------------------------------------------------------------------------------------<br>"+
                $"<strong>This is an auto generated email, please do not reply this email." +
                $"<br/>For any queries please write to treasurer.phchs@gmail.com.</strong></p>";
        }
    }
}