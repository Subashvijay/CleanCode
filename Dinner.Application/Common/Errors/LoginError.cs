namespace Dinner.Application.Common.Errors
{
    using System.Collections.Generic;

    using FluentResults;

    public class LoginError : IError
    {
        public LoginError(string msg)
        {
            this.Message = msg;
        }
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message { get; }

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}