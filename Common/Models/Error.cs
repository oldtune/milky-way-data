using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common.Models;

public class Error
{
    private List<string> _customError = new List<string>();
    //only show exception to developer, do not show to customer
    private Exception _exception;
    public bool HasException => _exception != null;

    public ReadOnlyCollection<string> Errors()
    {
        return new ReadOnlyCollection<string>(_customError);
    }

    public Exception Exception()
    {
        return _exception;
    }

    public Error(string error)
    {
        _customError.Add(error);
    }

    public Error(Exception ex)
    {
        _exception = ex;
        _customError.Add("Unexpected error");
    }
}