using MyCompany.Exception;

namespace MyCompany.Services
{
    public class ServiceResult<TResult>
    {
        public ServiceResult()
        {

        }
          
        public ServiceResult(TResult result)
        {
            Contune = true;
            Data = result;
        }

        public ServiceResult(HttpExceptionRequest exception)
        {
            Contune = false;
            Exception = exception;
        }

        public HttpExceptionRequest Exception { get; set; }

        public bool Contune { get; set; }

        public TResult Data { get; set; }
    }
}
