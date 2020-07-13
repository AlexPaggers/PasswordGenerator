namespace PasswordExcercise
{
    public interface IPasswordGenerator
	{
		string GeneratePassword(PasswordRequirements requirements);
	}
}
