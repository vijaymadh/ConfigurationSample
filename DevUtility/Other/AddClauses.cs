using Icertis.CLM.APIClient;
using Icertis.CLM.Masters;

namespace ConfigurationValidation.Other
{
    class AddClauses
    {

        private int clauseCout = 5000;

        public bool Createclause()
        {
            var clause = new Clause()
            {
                Name = "TestClauseName",
                ClauseCode = "12112",
                Description = "sdfasfas"
            };

            var saveStatus = ClauseServiceContext.Save(clause);
            return true;
        }

    }
}
