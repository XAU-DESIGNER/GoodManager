namespace GoodManager.Domain.Common;

public class Result
{
    protected internal Result(bool isSuccess, string? msessage = null)
    {
        IsSuccess = isSuccess;
        Message = msessage;
    }

    public bool IsSuccess { get; }

    public string? Message { get; set; }

    public bool IsFailure => !IsSuccess;

    public static Result Success() => new(true, SuccessMessages.SuccessfullyDone);

    public static Result Success(string message) => new(true, message);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, SuccessMessages.SuccessfullyDone);

    public static Result<TValue> Success<TValue>(TValue value, string message) => new(value, true, message);

    public static Result Failure(string message) => new(false, message);

    public static Result<TValue> Failure<TValue>(string message) => new(default, false, message);

    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(ErrorMessages.OperationFailedError);

}