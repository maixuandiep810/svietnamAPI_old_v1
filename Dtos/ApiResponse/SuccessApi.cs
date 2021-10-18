namespace svietnamAPI.Dtos.ApiResponse
{
    public class SuccessApi<T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}