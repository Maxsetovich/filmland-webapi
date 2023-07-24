namespace FilmLand.Service.Validators;

public class PasswordValidator
{
    public static string Symbols { get; } = "~`!@#$%^&*()_-+={[}]\\:;\"'<,>.?/ ";
    
    public static (bool IsValid, string Message) IsStrongPassword(string password)
    {
        if (password.Length < 8) return (IsValid: false, Message: "Password cannot be less than 8 characters!");

        bool isUpperCaseExists = false;
        bool isNumberExists = false;
        bool isLowerCaseExists = false;
        bool isCharacterExists = false;

        foreach(var item in password)
        {
            if (char.IsUpper(item)) isUpperCaseExists = true;
            if (char.IsLower(item)) isLowerCaseExists = true;
            if (char.IsDigit(item)) isNumberExists = true;
            if (Symbols.Contains(item)) isCharacterExists = true;
        }

        if (isUpperCaseExists == false) return (IsValid: false, Message: "Password should contain at least one Upper case!");
        if (isLowerCaseExists == false) return (IsValid: false, Message: "Password should contain at least one Lower case!");
        if (isNumberExists == false) return (IsValid: false, Message: "Password should contain at least one Digit!");
        if (isCharacterExists == false) return (IsValid: false, Message: "Password should contain at least one Symbol!");

        return (IsValid: true, "");

    }
}
