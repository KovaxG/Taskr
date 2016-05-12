using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace Login
{
    public class VerifyText
    {
        // Checks if string has only letters or is null
        public bool HasOnlyLettersOrNull(String input)
        {
            return Regex.IsMatch(input, @"(^$)|(^[a-zA-Z ]+$)");
        }

        // CHecks if string has only letters
        public bool HasOnlyLetters(String input)
        {
            return Regex.IsMatch(input, @"(^[a-zA-Z ]+$)");
        }

        // Checks if string has only letters,numbers or underscore
        public bool HasOnlyLettersNumbersUnderscore(String input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9_]+$");
        }

        // Checks if string is null
        public bool IsNull(String input)
        {
            return Regex.IsMatch(input, @"(^$)");
        }

        // Checks if string is an SQL injection
        public bool IsInjection(String input)
        {
            return (input.Contains(@"'") || input.Contains(@"\"));
        }

        // Checks if string is a strong password 
        public bool IsStrongPassword(String input)
        {
            return Regex.IsMatch(input, "(?!^[0-9]*$)(?!^[a-z]*$)(?!^[A-Z]*$)^(.{8,15})$");
        }

        // Checks if string is a valid email
        public bool IsValidEmail(string input)
        {
            return Regex.IsMatch(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        // Checks if string is a valid phone number
        public bool IsValidPhoneNumber(String input)
        {
            return Regex.IsMatch(input, @"^[0-9]{10}$");
        }

        // Checks if string is a valid URL image
        public bool IsValidUrlImage(string url)
        {
            try
            {
                new System.Net.WebClient().DownloadData(url);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
