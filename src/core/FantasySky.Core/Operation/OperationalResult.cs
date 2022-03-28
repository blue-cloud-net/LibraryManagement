using System.Xml.Linq;

namespace FantasySky.Core.Operation;

public class OperationalResult
{
    public OperationalResult(
        OperationalState? state = null,
        string? message = null,
        Exception? exception = null)
    {
        this.State = state ?? OperationalState.Success;
        this.Message = message ?? String.Empty;
        this.Exception = exception ?? null;
    }

    public OperationalState State { get; private init; }

    public string Message { get; private init; }

    public Exception? Exception { get; private init; }

    public static OperationalResult Ok() => new();
    public static OperationalResult Failed(string messgae) => new(OperationalState.Failed, messgae);
    public static OperationalResult Error(Exception exception) => new(OperationalState.Error, exception.Message, exception);

    public bool IsSuccess => this.State is OperationalState.Success;
}

public class OperationalResult<TData> : OperationalResult
{
    public OperationalResult(
        OperationalState? state = null,
        TData? data = default,
        string? message = null,
        Exception? exception = null) : base(state, message, exception)
    {
        this.Data = data ?? default!;
    }

    public TData Data { get; private set; }

    public static OperationalResult<TData> Ok(TData data) => new(null, data);
    public static new OperationalResult<TData> Failed(string messgae) => new(OperationalState.Failed, default, messgae);
    public static new OperationalResult<TData> Error(Exception exception) => new(OperationalState.Error, default, exception.Message, exception);
    public static OperationalResult<TData> NotSuccessLoad(OperationalResult result) => new(result.State, default, result.Message, result.Exception);
}