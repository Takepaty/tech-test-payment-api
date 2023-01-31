namespace tech_test_payment_api.Filters
{
    public class MyCustomHttpException : System.Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }

        public MyCustomHttpException(int statusCode, string errorMessage, string erroDetail)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            ErrorDetail = erroDetail;
        }
    }
}
