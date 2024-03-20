namespace Core.Extensions.Objects
{
    public static class NumberExtension
    {
        public static byte ToByte(this string data)
        {
            bool parseSuccess = byte.TryParse(data, out byte result);
            if (parseSuccess)
            {
                return result;
            }

            return default;
        }

        public static bool IsDigit(this string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            data = data.Trim();
            data = data.Replace(" ", string.Empty);
            data = data.Replace(".", string.Empty);
            data = data.Replace(",", string.Empty);

            foreach (char c in data)
            {
                if (!char.IsDigit(c)) return false;
            }

            return true;
        }

        public static bool IsContainNumeric(this string str)
        {
            if (str == null || str.Length == 0)
            {
                return false;
            }
            return str.Any(c => char.IsDigit(c));
        }

        public static string ToNotNullString(this object p)
        {
            string d;
            try
            {
                d = Convert.ToString(p).Trim();
            }
            catch
            {
                d = "";
            }
            return d;
        }

        public static double ToDouble(this object p, int digits = 2)
        {
            double.TryParse(p.ToNotNullString(), out double result);
            if (result == double.MinValue) result = 0;
            return Math.Round(result, digits);
        }

        public static int ToInt32(this object p)
        {
            try
            {
                double tmp = p.ToDouble();
                int result = (int)tmp;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static int? ToNullableInt32(this object p)
        {
            try
            {
                double tmp = p.ToDouble();
                int result = (int)tmp;
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static decimal? Format(this decimal? value, int digits = 0)
        {
            return value != null ? Math.Round(value.Value, digits) : null;
        }

        public static decimal Format(this decimal value, int digits = 0)
        {
            return Math.Round(value, digits);
        }

        public static string ToAlphabet(this int number)
        {
            if (number is < 1 or > 26)
            {
                return number.ToString();
            }
            char alphabetChar = (char)('A' + number - 1);
            return alphabetChar.ToString();
        }
    }
}
