namespace ETicaretAPI.Application.Exceptions
{
    public class AuthenticationExceptionError : Exception
    {
        public AuthenticationExceptionError() : base("Kimlik Doğrulama Hatası")
        {
        }

        public AuthenticationExceptionError(string? message) : base(message)
        {
        }

        public AuthenticationExceptionError(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
