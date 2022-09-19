using System;
using System.Threading.Tasks;

namespace ConfigurationValidation.RetryMechanism
{
    class FunctionWithRetry<T> where T:class
    {
        readonly Func<T> _function;
        string _errorMessage;
        readonly RetryStrategy _retryStrategy;


        public FunctionWithRetry(Func<T> function, RetryStrategy retryStrategy)
        {
            this._function = function;            
            this._retryStrategy = retryStrategy;
        }

        internal string PerformAction()
        {
            var retries = 1;
            Exception exception = null;
            do
            {
                try
                {
                    _errorMessage += $"Retry Count:{retries}\n";
                    var retVal = this._function();                    
                    return _errorMessage;
                }
                catch (Exception ex)
                {
                    exception = ex;                   
                    Task.Delay(this._retryStrategy.Interval);
                }
                finally
                {
                    
                    retries++;
                }
                
            } while (retries <= this._retryStrategy.MaxRetries);

            return $"Failed With Retries\n{_errorMessage}";
        }
    }
}