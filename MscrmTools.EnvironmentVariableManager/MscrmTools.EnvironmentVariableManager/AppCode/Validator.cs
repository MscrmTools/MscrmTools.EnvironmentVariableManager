namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    public class Validator
    {
        public static bool ValidateBoolean(string value)
        {
            return value.Equals("yes") ||
                   value.Equals("no");
        }
    }
}