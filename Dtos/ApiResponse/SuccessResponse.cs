namespace svietnamAPI.Dtos.ApiResponse
{
    public class SuccessResponse<T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}