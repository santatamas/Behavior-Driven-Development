using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    /// <summary>
    /// Sample implementation of the famous String Calculator TDD Kata
    /// For more information please visit: http://osherove.com/tdd-kata-1/
    /// 
    /// Author:     Tamas Santa
    /// Company:    EPAM Systems
    /// </summary>
    public class StringCalculator
    {
        int _defaultValue = 0;
        char _defaultSeparator = ',';
        InputSanitizer _sanitizer;

        public StringCalculator()
        {
            _sanitizer = new InputSanitizer(_defaultSeparator);
        }

        public int Add(string input)
        {
            input = _sanitizer.Sanitize(input);
            List<int> numbers = ExtractNumbers(input);

            var negatives = numbers.Where(n => n < 0).ToList();
            if (negatives.Count() > 0)
            {
                throw new Exception("input contains negative(s)!");
            }

            return numbers.Sum();

        }

        private List<int> ExtractNumbers(string input)
        {
            List<int> result = new List<int>();

            if (ShouldReturnDefaultValue(input))
            {
                result.Add(_defaultValue);
                return result;
            }

            if (ShouldConvertMultipleNumbers(input))
            {
                result.AddRange(ConvertMultipleNumbers(input));
                return result;
            }

            result.Add(ConvertSingleNumber(input));
            return result;
        }

        private int ConvertSingleNumber(string input)
        {
            return int.Parse(input);
        }

        private List<int> ConvertMultipleNumbers(string input)
        {
            List<int> result = new List<int> { _defaultValue };
            string[] inputNumbers = input.Split(_defaultSeparator);
            foreach (string number in inputNumbers)
            {
                result.Add(ConvertSingleNumber(number));
            }

            return result;
        }

        private bool ShouldConvertMultipleNumbers(string input)
        {
            return input.Contains(_defaultSeparator);
        }

        private static bool ShouldReturnDefaultValue(string input)
        {
            return input == String.Empty;
        }
    }

    public class InputSanitizer
    {
        char _defaultSeparator;
        string[] _supportedSeparators = new[] { ",", "\n" };

        public InputSanitizer(char defaultSeparator)
        {
            _defaultSeparator = defaultSeparator;
        }

        public string Sanitize(string input)
        {
            string customSeparator;
            if (TryGetCustomSeparator(input, out customSeparator))
            {
                input = input.Split(Environment.NewLine.ToCharArray())[1];
                input = input.Replace(customSeparator, _defaultSeparator.ToString());
            }

            foreach (string separator in _supportedSeparators)
            {
                input = input.Replace(separator, _defaultSeparator.ToString());
            }
            return input;
        }

        private bool TryGetCustomSeparator(string input, out string delimiter)
        {
            delimiter = String.Empty;
            if (input.StartsWith("//"))
            {
                string delimiterPart = input.Split(Environment.NewLine.ToCharArray())[0];
                delimiter = delimiterPart.Substring(2, delimiterPart.Length - 2);
                return true;
            }
            return false;
        }
    }
}