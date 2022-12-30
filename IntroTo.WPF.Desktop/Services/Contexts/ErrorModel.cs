using System;

namespace IntroTo.WPF.Desktop.Services.Contexts;

public class ErrorModel
{
    public ErrorModel() { Id = Guid.NewGuid(); }
    public Guid Id { get; }
    public string Message { get; set; }
    public Exception? Exception { get; set; }
    public bool IsHandled { get; set; }
}