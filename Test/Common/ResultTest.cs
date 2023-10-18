using Common.Models;
using Xunit;

namespace Test.Common;

public class ResultTest
{
    [Fact]
    public void CreateSuccessResultTest()
    {
        var result = Result<int>.CreateSuccess(3);
        Assert.Equal(true, result.Ok);
        Assert.Equal(3, result.Unwrap());
        Assert.Null(result.GetError());
    }

    [Fact]
    public void CreateFailedResultTest()
    {
        var failedResult = Result.CreateError<int>(new Exception("Test exception"));
        Assert.Equal(false, failedResult.Ok);
        Assert.NotNull(failedResult.GetError());
    }

    [Fact]
    public void FromNullTestReturnError()
    {
        var result = Result.FromNotNull<string>(null);
        Assert.Equal(false, result.Ok);
        Assert.NotNull(result.GetError());
        Assert.IsType<NullReferenceException>(result.GetError().Exception());
    }

    [Fact]
    public void FromNullTestWork()
    {
        var result = Result.FromNotNull<string>("hello");
        Assert.Equal("hello", result.Unwrap());
        Assert.Equal(true, result.Ok);
        Assert.Null(result.GetError());
    }

    [Fact]
    public async Task CreateResultFromSuccessTaskReturnOk()
    {
        Func<Task> task = async () =>
        {
            await Task.Delay(1);
        };

        var result = await Result.FromTask(task);

        Assert.Equal(true, result.Ok);
    }

    [Fact]
    public async Task CreateResultFromFailedTaskReturnsError()
    {
        Func<Task> task = async () =>
        {
            await Task.Delay(1);
            throw new Exception();
        };

        var result = await Result.FromTask(task);

        Assert.Equal(false, result.Ok);
        Assert.NotNull(result.GetError());
    }

    [Fact]
    public async Task CreateResultFromTaskTWork()
    {

        Func<Task<int>> task = async () =>
        {
            await Task.Delay(1);
            return 3;
        };

        var result = await Result.FromTask(task);

        Assert.Equal(true, result.Ok);
        Assert.Equal(3, result.Unwrap());
        Assert.Null(result.GetError());
    }

    [Fact]
    public async Task CreateResultFromFailedTaskT()
    {
        Func<Task<int>> task = async () =>
        {
            await Task.Delay(1);
            throw new Exception();
        };

        var result = await Result.FromTask(task);

        Assert.Equal(false, result.Ok);
        Assert.NotNull(result.GetError());
    }

    [Fact]
    public async Task CreateFromTaskNoneIgnoreValue()
    {
        Func<Task<int>> task = async () =>
        {
            await Task.Delay(1);
            return 3;
        };

        var result = await Result.FromTaskNone(task);
        Assert.Equal(true, result.Ok);
        Assert.Equal(None.Default, result.Unwrap());
        Assert.Null(result.GetError());
    }

    [Fact]
    public async Task CreateFromTaskNoneFail()
    {
        Func<Task<int>> task = async () =>
        {
            await Task.Delay(1);
            throw new Exception();
        };

        var result = await Result.FromTaskNone(task);
        Assert.Equal(false, result.Ok);
        Assert.NotNull(result.GetError());
    }

    [Fact]
    public async Task CreateFromValueTaskWork()
    {
        Func<ValueTask<int>> task = async () =>
        {
            await Task.Delay(1);
            return 3;
        };

        var result = await Result.FromValueTask(task);
        Assert.Equal(true, result.Ok);
        Assert.Equal(3, result.Unwrap());
        Assert.Null(result.GetError());
    }

    [Fact]
    public async Task CreateFromValueTaskFail()
    {
        Func<ValueTask<int>> task = async () =>
        {
            await Task.Delay(1);
            throw new Exception();
        };

        var result = await Result.FromValueTask(task);
        Assert.Equal(false, result.Ok);
        Assert.NotNull(result.GetError());
    }

    [Fact]
    public async Task CreateFromValueTaskNone()
    {
        Func<ValueTask<int>> task = async () =>
        {
            await Task.Delay(1);
            return 3;
        };

        var result = await Result.FromValueTaskNone(task);
        Assert.Equal(true, result.Ok);
        Assert.Null(result.GetError());
    }
}