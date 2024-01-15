namespace Domain.DTO
{
    public class ResultDTO
    {
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
    }
}
