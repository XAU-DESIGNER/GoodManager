using System.Security.Cryptography;
using System.Text;

namespace GoodManager.Application.Security;

public static class PasswordHelper
{
    public static string EncodePasswordSHA256(this string pass)
    {
        Byte[] originalBytes;
        Byte[] encodedBytes;

        var provider = new SHA256CryptoServiceProvider();

        originalBytes = ASCIIEncoding.Default.GetBytes(pass);
        encodedBytes = provider.ComputeHash(originalBytes);

        //Convert encoded bytes back to a 'readable' string   
        return Convert.ToBase64String(encodedBytes);
    }

    //Encrypt using MD5 (Hasher)
    public static string EncodePasswordMd5(this string pass)
    {
        Byte[] originalBytes;
        Byte[] encodedBytes;
        MD5 md5;
        //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
        md5 = new MD5CryptoServiceProvider();
        originalBytes = ASCIIEncoding.Default.GetBytes(pass);
        encodedBytes = md5.ComputeHash(originalBytes);
        //Convert encoded bytes back to a 'readable' string   
        return BitConverter.ToString(encodedBytes);
    }

    //public static Result PasswordIsValid(this string Password, int minLength = 8, bool requiredUpperCase = true, bool requiredLowerCase = true)
    //{
    //    if (string.IsNullOrWhiteSpace(Password))
    //    {
    //        return Result.Failure(string.Format(ErrorMessages.RequiredError,"رمز عبور"));
    //    }

    //    if (Password.Length < minLength)
    //    {
    //        return Result.Failure(string.Format(ErrorMessages.MinLengthError, "رمز عبور",minLength));
    //    }

    //    if (requiredUpperCase && !Regex.Match(Password, "^(?=.*[A-Z]).+$").Success)
    //    {
    //        return Result.Failure(ErrorMessages.PasswordRequiredUpperCaseError);
    //    }

    //    if (requiredLowerCase && !Regex.Match(Password, "^(?=.*[a-z]).+$").Success)
    //    {
    //        return Result.Failure(ErrorMessages.PasswordRequiredLowerCaseError);
    //    }

    //    return Result.Success();
    //}

}