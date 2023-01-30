using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace tech_test_payment_api.Filters
{
    public class HttpExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var errorMessage = exception.Message;
            var errorDetail = exception.Message;

            var errorCode = 500;

            if (exception is MyCustomHttpException)
            {
                errorCode = (exception as MyCustomHttpException).StatusCode;
                errorMessage = (exception as MyCustomHttpException).ErrorMessage;
                errorDetail = (exception as MyCustomHttpException).ErrorDetail;
            }

            context.Result = new ObjectResult(new
            {
                errorCode,
                errorMessage,
                errorDetail
            });

            context.ExceptionHandled = true;
        }

    }
}