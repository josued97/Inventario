namespace Domain.Exceptions;

public static partial class DomainError
{
    public static class Cliente
    {
        public sealed class ClienteExisteException : DomainException
        {
            private ClienteExisteException(string mensaje) : base(mensaje) { }
            public static void Throw(string email)
            {
                throw new ClienteExisteException($"El cliente con email {email} ya existe");
            }
        }
    }
}
