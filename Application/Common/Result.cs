namespace Microsoft.Extensions.DependencyInjection.Common;

public class Result<T>
{
    public Result(bool success, string? message, T? content)
    {
        Success = success;
        Message = message;
        Content = content;
    }
    
    public bool Success { get; set; } = false;
    public string? Message { get; set; } = null;
    public T? Content { get; set; } = default;
}