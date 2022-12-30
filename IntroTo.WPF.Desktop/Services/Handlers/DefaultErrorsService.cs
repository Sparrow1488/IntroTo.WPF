using System.Windows;
using IntroTo.WPF.Desktop.Services.Contexts;

namespace IntroTo.WPF.Desktop.Services.Handlers;

public class DefaultErrorsService : IErrorsService
{
    private readonly ApplicationContext _context;

    public DefaultErrorsService(ApplicationContext context)
    {
        _context = context;
    }
    
    public void ShowError(ErrorModel error)
    {
        MessageBox.Show($"Error: {error.Message}\nException: {error.Exception?.GetType().Name}");
        _context.HandleError(error.Id);
    }
}