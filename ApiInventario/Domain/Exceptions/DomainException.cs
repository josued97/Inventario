namespace Domain.Exceptions;

public abstract class DomainException : Exception
{
    public DomainException(string mensaje) : base(mensaje)
    {
        _mensaje = string.Empty;
    }

    public string _mensaje { get; set; }
}
