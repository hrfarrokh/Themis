namespace Themis.Domain
{
    public class PhoneNumberValidationException : Exception
    {
        public PhoneNumberValidationException(string value)
            : base($"{value} is invalid.")
        {
        }

    }
}
