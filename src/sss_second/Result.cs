using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{
    public class Result<TSuccess, TFailure>
    {
        private readonly TSuccess _success;
        private readonly TFailure _failure;
        private readonly bool _isSuccess;

        public Result(TSuccess success)
        {
            _success = success;
            _isSuccess = true;
        }

        public Result(TFailure failure)
        {
            _failure = failure;
        }

        public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
        {
            return _isSuccess ? success(_success) : failure(_failure);
        }
    }
}
