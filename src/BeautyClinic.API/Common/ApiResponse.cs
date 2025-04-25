namespace BeautyClinic.API.Common;
public class ApiResponse<T>
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }
}
public class ApiResponse
{
    public bool Succeeded { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public string? Message { get; set; }

    public ApiResponse(bool succeeded, HttpStatusCode statusCode, string message = null)
    {
        Succeeded = succeeded;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToString();
    }

}


