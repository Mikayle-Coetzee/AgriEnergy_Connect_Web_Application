﻿#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ST10023767_PROG.Classes
{
    /// <summary>
    /// This class is used for user input validation.
    /// </summary>
    public class ValidationClass
    {
        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Default constructor for Validation.
        /// </summary>
        public ValidationClass() { }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method is used to validate user input that should be one of two things.
        /// </summary>
        /// <param name="userInput">The user input string to be validated.</param>
        /// <param name="firstString">The first option.</param>
        /// <param name="lastString">The second option.</param>
        /// <returns>True if the input is one of two specified options, false otherwise.</returns>
        public bool Validate_Option_Input(string userInput, string firstString, string lastString)
        {
            // Initialize variable
            bool valid;

            if (Validate_String(userInput) == true)
            {
                if ((userInput.Trim().ToUpper().Equals(firstString)) || (userInput.Trim().ToUpper().Equals(lastString)))
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
            else
            {
                valid = false;
            }
            return valid;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method is used to validate a string input.
        /// </summary>
        /// <param name="userInput">The user input string to be validated.</param>
        /// <returns>True if the input is a valid string, false otherwise.</returns>
        public bool Validate_String(string userInput)
        {
            // Initialize variable
            bool valid = false;

            try
            {
                if ((!userInput.Equals(string.Empty)) && (!userInput.Equals(null)))
                {
                    valid = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Line 75: " + ex.Message);
                valid = false;
            }
            return valid;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method is used to validate a string input and return if its a valid or invalid email.
        /// If the email contains an '@' sign followed by a '.' somewhere after, it will return true
        /// </summary>
        /// <param name="userInput">The user input string to be validated.</param>
        /// <returns>True if the input is a valid email, false otherwise.</returns>
        public bool Validate_Email(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                if (Regex.IsMatch(userInput, pattern))
                {
                    return true;
                }
            }

            return false;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method validates if the user input is a valid password.
        /// </summary>
        /// <param name="userInput">The user input string to be validated as a password.</param>
        /// <returns>True if the input is a valid password, false otherwise.</returns>
        public bool Validate_Password(string userInput)
        {
            // Initialize variable
            int minLength = 8;
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            string uppercasePattern = @"[A-Z]";
            string lowercasePattern = @"[a-z]";
            string digitPattern = @"\d";
            string specialCharPattern = @"[^a-zA-Z0-9]";

            // Check if the password meets the minimum length requirement
            if (string.IsNullOrEmpty(userInput) || userInput.Length < minLength)
            {
                return false;

            }
     
            // Check each character in the password to satisfy the criteria
            foreach (char c in userInput)
            {
                if (Regex.IsMatch(c.ToString(), uppercasePattern))
                {
                    hasUppercase = true;
                }
                else if (Regex.IsMatch(c.ToString(), lowercasePattern))
                {
                    hasLowercase = true;
                }
                else if (Regex.IsMatch(c.ToString(), digitPattern))
                {
                    hasDigit = true;
                }
                else if (Regex.IsMatch(c.ToString(), specialCharPattern))
                {
                    hasSpecialChar = true;
                }
            }

            return hasUppercase && hasLowercase && hasDigit && hasSpecialChar;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method validates if the user input is a valid date.
        /// </summary>
        /// <param name="userInput">The user input string to be validated as a date.</param>
        /// <returns>True if the input is a valid date, false otherwise.</returns>
        public bool Validate_Date(string userInput)
        {
            // Initialize variable
            bool valid = false;

            try
            {
                if (DateTime.TryParse(userInput, out _))
                {
                    valid = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Line 129: " + ex.Message);
                valid = false;
            }

            return valid;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method validates if the user input is a valid integer.
        /// </summary>
        /// <param name="userInput">The user input string to be validated.</param>
        /// <returns>True if the input is a valid integer, false otherwise.</returns>
        public bool Validate_Integer(string userInput)
        {
            // Initialize variable
            bool valid = false;

            try
            {
                if (Int32.TryParse(userInput, out int number) == true)
                {
                    if (number >= 0)
                    {
                        valid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Line 159: " + ex.Message);
                valid = false;
            }

            return valid;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method validates if a user input can be parsed as a float number.
        /// </summary>
        /// <param name="userInput">The user input string to be validated.</param>
        /// <returns>True if the input is a valid float, false otherwise.</returns>
        public bool Validate_Float(string userInput)
        {
            // Initialize variable
            bool valid = false;

            try
            {
                if (float.TryParse(userInput, out float number) == true)
                {
                    if (number >= 0)
                    {
                        valid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Line 189: " + ex.Message);
                valid = false;
            }

            return valid;
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// This method validates that the user's input is between min and max.
        /// </summary>
        /// <param name="userInput">The user input string to be validated.</param>
        /// <param name="min">The minimum valid value.</param>
        /// <param name="max">The maximum valid value.</param>
        /// <returns>True if it is a valid integer and in the valid range, else False.</returns>
        public bool Validate_Range_Int_Input(string userInput, int min, int max)
        {
            if (!Validate_Integer(userInput)) return false;
            var userChoice = Convert.ToInt32(userInput);
            return (userChoice >= min && userChoice <= max);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
