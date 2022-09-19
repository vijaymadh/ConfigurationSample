using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationValidation.Interview
{
    class QuestionAndAnswers
    {
        public string id { get; set; }
        public string Question { get; internal set; }
        public string Answer { get; set; }
        public int ExperienceFrom { get; set; }
        public int ExperienceTo { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    
    }
}
