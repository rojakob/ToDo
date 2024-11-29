namespace WPFLabs
{
    public class Validator
    {
        private readonly string _input;
        private readonly ValidationType _type;

        public enum ValidationType { Email, Password, Name }

        public Validator(string input, ValidationType type)
        {
            _input = input;
            _type = type;
        }

        public bool IsValid()
        {
            return _type switch
            {
                ValidationType.Email => ValidateEmail(),
                ValidationType.Password => ValidatePassword(),
                ValidationType.Name => ValidateName(),
                _ => false
            };
        }

        private bool ValidateEmail()
        {
            var parts = _input.Split('@');
            return parts.Length == 2 && parts[1].Split('.').Length == 2;
        }

        private bool ValidatePassword() => _input.Length >= 6;

        private bool ValidateName() => _input.Length >= 3;
    }
}
