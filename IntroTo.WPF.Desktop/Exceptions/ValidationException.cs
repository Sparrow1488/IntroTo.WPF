using System;

namespace IntroTo.WPF.Desktop.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
    {
    }

    public ValidationException(string? message) : base(message)
    {
    }
}