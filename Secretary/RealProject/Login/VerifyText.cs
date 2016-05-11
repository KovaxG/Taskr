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
        public bool HasOnlyLettersOrNull (String input)
        {
            return Regex.IsMatch(input, @"(^$)|(^[a-zA-Z ]+$)"); 
        }

        public bool HasOnlyLetters(String input)
        {
            return Regex.IsMatch(input, @"(^[a-zA-Z ]+$)");
        }

        public bool HasOnlyLettersNumbersUnderscore (String input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9_]+$");
        }

        public bool HasOnlyNumbers (String input)
        {
            return Regex.IsMatch(input, @"^[0-9]+$"); 
        }

        public bool IsNull(String input)
        {
            return Regex.IsMatch(input, @"(^$)");
        }

        public bool IsInjection(String input)
        {

            return !(input.IndexOfAny(new[] { '\'', '\\' }) == -1);
        }

        public bool IsStrongPassword(String input)
        {
            return Regex.IsMatch(input, "(?!^[0-9]*$)(?!^[a-z]*$)(?!^[A-Z]*$)^(.{8,15})$");
        }

        public bool IsValidEmail(string input)
        {
            return Regex.IsMatch(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public bool IsValidPhoneNumber (String input)
        {
            return Regex.IsMatch(input, @"^[0-9]{10}$"); 
        }

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
