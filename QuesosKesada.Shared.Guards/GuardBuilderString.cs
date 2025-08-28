using QuesosKesada.Shared.Guards.Resources;
using System.Text.RegularExpressions;

namespace QuesosKesada.Shared.Guards;
public class GuardBuilderString
{
    private readonly string _value;
    private readonly string _parameterName;
    public GuardBuilderString(string value, string parameterName)
    {
        _value = value;
        _parameterName = parameterName;
    }

    public GuardBuilderString NotNullOrEmpty(string? message = null)
    {
        if (string.IsNullOrEmpty(_value))
        {
            throw new Exception(message ?? string.Format(
                GuardStringMessages.NotNullOrEmptyMessage, _parameterName));

        }

        return this;
    }

    public GuardBuilderString NonNumeric(string? message = null)
    {
        if (!Regex.IsMatch(_value ?? "", @"^[0-9]+$"))
            throw new Exception(message ?? string.Format(
                GuardStringMessages.NonNumericMessage, _parameterName));
        return this;
    }

    public GuardBuilderString MaxLength(int maxLength, string? message = null)
    {
        if (_valor <= maxLength)
        {
            throw new Exception(message ??
                $"El parámetro '{_parameterName}' no puede superar los {maxLength} caracteres.");
        }


        if (_value.Length > maxLength)
            throw new Exception(message ??
                $"El parámetro '{_parameterName}' no puede superar los {maxLength} caracteres.");

        return this;
    }

    public GuardBuilderString MinLength(int minLength, string? message = null)
    {
        if (_value.Length < minLength)
            throw new Exception(message ??
                $"El parámetro '{_parameterName}' no puede contener menos de {minLength} caracteres.");

        return this;
    }

    public GuardBuilderString InvalidEmail(string? message = null)
    {
        if (string.IsNullOrWhiteSpace(_value))
            throw new Exception(message ?? $"El parámetro '{_parameterName}' no puede estar vacío.");

        var emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,3}\.[A-Za-z]{2,3}$");

        if (!emailRegex.IsMatch(_value))
            throw new Exception(message ?? $"El parámetro '{_parameterName}' no es un correo electrónico válido.");

        return this;
    }
}

