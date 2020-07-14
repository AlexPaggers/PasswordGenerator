namespace PasswordExcercise
{
    public class CheckResult
    {
        public bool Result { get; private set; }

        public ErrorMessage Message { get; private set; }

        public static CheckResult Success()
        {
            return new CheckResult { Result = true };
        }

        public static CheckResult Fail(ErrorMessage message)
        {
            return new CheckResult { Result = false, Message = message };
        }
    }
}