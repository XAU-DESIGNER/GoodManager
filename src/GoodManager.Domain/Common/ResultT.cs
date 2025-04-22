namespace GoodManager.Domain.Common;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, string? message = null)
        : base(isSuccess, message) =>
        _value = value;

    public TValue Value => IsSuccess
        ? _value!
        : default(TValue)!;

    public static implicit operator Result<TValue>(TValue? value) => Create(value);

}