namespace svietnamAPI.Dtos.ApiResponse
{
    public class ErrorApi
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionMessage { get; set; }
    }
}