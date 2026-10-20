namespace Mini_Shop.exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string message): base(message)
        { }
    }
}
