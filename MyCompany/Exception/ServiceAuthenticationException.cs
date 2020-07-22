using System;


namespace MyCompany.Exception
{
    public class ServiceAuthenticationException : SystemException
    {
        public string Content { get; }

        public ServiceAuthenticationException()
        {
        }

        public ServiceAuthenticationException(string content)
        {
            Content = content;
        }
    }
}
