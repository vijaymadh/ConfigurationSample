using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationValidation.RetryMechanism
{
    class RetryStrategy
    {        
        public int MaxRetries { get; private set; }
        public TimeSpan Interval { get; private set; }

        public RetryStrategy(int maxRetries, TimeSpan interval)
        {         
            MaxRetries = maxRetries;
            interval = Interval;
        }
    }
}
