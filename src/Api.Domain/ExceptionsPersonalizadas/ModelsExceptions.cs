namespace Domain.ExceptionsPersonalizadas
{
    public class ModelsExceptions : Exception
    {
        public ModelsExceptions() { }

        public ModelsExceptions(string message) : base(message) { }

        public ModelsExceptions(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
