namespace JobBank.Api.Jobs.Common;

public class ValidationErrorResponse : ErrorResponse
{
    public IDictionary<string, string[]>? Errors { get; set; }
}