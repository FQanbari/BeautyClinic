using System.Net;
using System.Text.Json;

namespace BeautyClinic.API.Features.Common;

public class ApiResponseMiddleware
{
    private readonly RequestDelegate _next;

    public ApiResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // ذخیره پاسخ اصلی
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            // اجرای درخواست
            await _next(context);

            // خواندن پاسخ
            responseBody.Seek(0, SeekOrigin.Begin);
            var responseContent = await new StreamReader(responseBody).ReadToEndAsync();
            responseBody.Seek(0, SeekOrigin.Begin);

            // اگر پاسخ قبلاً ApiResponse است، نیازی به بسته‌بندی نیست
            if (context.Response.ContentType?.Contains("application/json") == true && !string.IsNullOrEmpty(responseContent))
            {
                try
                {
                    var responseObject = JsonSerializer.Deserialize<object>(responseContent);
                    if (responseObject is JsonElement jsonElement && jsonElement.TryGetProperty("succeeded", out _))
                    {
                        // پاسخ قبلاً ApiResponse است، مستقیماً کپی شود
                        await responseBody.CopyToAsync(originalBodyStream);
                        return;
                    }

                    // بسته‌بندی پاسخ در ApiResponse
                    var apiResponse = new ApiResponse<object>
                    {
                        Succeeded = true,
                        Data = responseObject
                    };

                    // بازنویسی پاسخ
                    context.Response.Body = originalBodyStream;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(apiResponse));
                }
                catch (JsonException)
                {
                    // اگر پاسخ JSON معتبر نیست، مستقیماً کپی شود
                    context.Response.Body = originalBodyStream;
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            else
            {
                // اگر پاسخ JSON نیست، مستقیماً کپی شود
                context.Response.Body = originalBodyStream;
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        catch (ValidationException ex)
        {
            // مدیریت خطاهای اعتبارسنجی
            await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Errors.Select(e => e.ErrorMessage).ToList());
        }
        catch (Exception ex)
        {
            // مدیریت سایر خطاها
            await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, new List<string> { "خطای سرور رخ داد." });
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, List<string> errors)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new ApiResponse<object>
        {
            Succeeded = false,
            Errors = errors
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}