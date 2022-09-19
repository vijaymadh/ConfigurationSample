namespace ConfigurationValidation.Adobe.CSV
{
    /// <summary>
    /// 
    /// </summary>
    class AgreementInfo
    {
        public string SysId { get; set; }

        public string Status { get; set; }

        public bool IsActive { get; set; }

        public string SignatureType { get; set; }

        public string RejectedEnv1 { get; set; }

        public string RejectedEnv1CreationDate { get; set; }

        public string RejectedEnv2 { get; set; }

        public string RejectedEnv2CreationDate { get; set; }

        public string SignedEnv1 { get; set; }

        public string SignedEnv1CreationDate { get; set; }

        public string SignedEnv2 { get; set; }

        public string SignedEnv2CreationDate { get; set; }

        public string CurrentEnv { get; set; }


        public string CurrentEnvStatus { get; set; }

        

    }
}
