using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace IntroTo.WPF.Desktop.Services.Contexts;

public abstract class ApplicationContext
{
    public event ErrorAdded? ErrorAdded;
    private readonly ObservableCollection<ErrorModel> _errors;
    
    public ApplicationContext()
    {
        _errors = new ObservableCollection<ErrorModel>();
    }
    
    public void AddError(string error, Exception ex = null!)
    {
        var model = new ErrorModel
        {
            Message = error,
            Exception = ex
        };
        _errors.Add(model);
        ErrorAdded?.Invoke(model);
    }

    public void HandleError(Guid id)
    {
        var error = _errors.SingleOrDefault(x => x.Id == id);
        if (error is not null) error.IsHandled = true;
    }
}

public delegate void ErrorAdded(ErrorModel error);