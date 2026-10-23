namespace Mini_Shop.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string message): base(message)
        { }
    }
}
