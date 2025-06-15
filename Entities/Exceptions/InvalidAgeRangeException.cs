namespace Entities.Exceptions
{
    public class InvalidAgeRangeException : Exception
    {
        public InvalidAgeRangeException() : base("Age range is not valid")
        {
        }

        public InvalidAgeRangeException(string? message) : base(message)
        {
        }

    }
}