﻿namespace BeautyClinic.API.Features.Common;
public class ApiResponse<T>
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }
}
