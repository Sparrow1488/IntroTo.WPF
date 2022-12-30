using IntroTo.WPF.Desktop.Services.Contexts;

namespace IntroTo.WPF.Desktop.Services.Handlers;

public interface IErrorsService
{
    void ShowError(ErrorModel error);
}