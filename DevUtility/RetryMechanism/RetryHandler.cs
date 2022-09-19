using System;

namespace ConfigurationValidation.RetryMechanism
{
    class RetryHandler
    {
        RetryStrategy _retryStrategy;

        public RetryHandler()
        {
            _retryStrategy = new RetryStrategy(5, new TimeSpan(0,0,2));
        }

        public string ExecuteFunctionWithRetry<T>(Func<T> function) where T:class
        {            
            var retryFunction = new FunctionWithRetry<T>(function, _retryStrategy);
            var retryResult=retryFunction.PerformAction();
            return retryResult;
        }

    }
}
