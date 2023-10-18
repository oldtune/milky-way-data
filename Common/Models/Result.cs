namespace Common.Models;
public class Result<T>
{
    public bool Ok => _error == null;
    private T? _data;
    private Error? _error;
    public T Unwrap()
    {
        if (Ok)
        {
            return _data;
        }

        throw new InvalidOperationException("Cannot unwrap failed result");
    }

    public static Result<T> CreateError(Error error)
    {
        if (error == null)
        {
            return new Result<T>
            {
                _error = new Error("Unkown exception")
            };
        }

        return new Result<T>
        {
            _error = error
        };
    }

    public static Result<T> CreateError(Exception ex)
    {
        return CreateError(new Error(ex));
    }

    public Error GetError()
    {
        return _error;
    }

    public static Result<T> CreateSuccess(T value)
    {
        return new Result<T>
        {
            _data = value
        };
    }
}

public static class Result
{
    public async static Task<Result<T>> FromValueTask<T>(Func<ValueTask<T>> valueTask)
    {
        try
        {
            var result = await valueTask();
            return Result<T>.CreateSuccess(result);
        }
        catch (Exception ex)
        {
            return Result<T>.CreateError(ex);
        }

    }

    public async static Task<Result<None>> FromValueTask(Func<ValueTask> valueTask)
    {
        try
        {
            await valueTask();
            return Result<None>.CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }

    public async static Task<Result<None>> FromValueTaskNone<T>(Func<ValueTask<T>> valueTask)
    {
        try
        {
            await valueTask();
            return Result<None>.CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }

    public async static Task<Result<None>> FromTaskNone<T>(Func<Task<T>> task)
    {
        try
        {
            await task();
            return Result<None>.CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }

    public async static Task<Result<T>> FromTask<T>(Func<Task<T>> task)
    {
        try
        {
            var result = await task();
            return CreateSuccess(result);
        }
        catch (Exception ex)
        {
            return CreateError<T>(ex);
        }
    }

    public async static Task<Result<None>> FromTask(Func<Task> task)
    {
        try
        {
            await task();
            return CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return CreateError<None>(ex);
        }
    }

    public static Result<T> FromNotNull<T>(T value) where T : notnull
    {
        if (value == null)
        {
            return CreateError<T>(new NullReferenceException());
        }

        return CreateSuccess(value);
    }

    public static Result<T> CreateSuccess<T>(T value)
    {
        return Result<T>.CreateSuccess(value);
    }

    public static Result<T> CreateError<T>(Exception ex)
    {
        return Result<T>.CreateError(ex);
    }
}

public static class ResultExtension
{
    public static Result<R> Map<T, R>(this Result<T> result, Func<T, R> map)
    {
        if (result.Ok)
        {
            return Result<R>.CreateSuccess(map(result.Unwrap()));
        }

        return Result<R>.CreateError(result.GetError());
    }
}