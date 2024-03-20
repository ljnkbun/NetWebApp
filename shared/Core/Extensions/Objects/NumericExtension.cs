namespace Core.Extensions.Objects
{
    public static class NumericExtension
    {
        public static string GetTrailingNumbers(this decimal _decimal)
        {
            decimal decimalNumbers = _decimal - Math.Round(_decimal, 0);
            if (decimalNumbers == 0) return string.Empty;

            return decimalNumbers.ToString().Split('.').LastOrDefault();
        }

        public static string ConvertToWords(this decimal? money)
        {
            var unit = "đồng";
            if (money == null) return string.Empty;
            var convertedValue = $"{NumberToWords(money.Value)} {unit}";
            if (!string.IsNullOrEmpty(convertedValue))
            {
                convertedValue = convertedValue.Trim().ToLower();
                var firstLetter = convertedValue[0].ToString().ToUpper();
                var lowerContent = convertedValue[1..];

                convertedValue = $"{firstLetter}{lowerContent}";
            }

            return convertedValue;
        }

        private static string[] unitsMap = new[] {
                    "Không",
                    "Một",
                    "Hai",
                    "Ba",
                    "Bốn",
                    "Năm",
                    "Sáu",
                    "Bảy",
                    "Tám",
                    "Chín",
                    "Mười",
                    "Mười một",
                    "Mười hai",
                    "Mười ba",
                    "Mười bốn",
                    "Mười lăm",
                    "Mười sáu",
                    "Mười bảy",
                    "Mười tám",
                    "Mười chín",
                };

        private static string[] tensMap = new[] {
                    "Không",
                    "Mười",
                    "Hai mươi",
                    "Ba mươi",
                    "Bốn mươi",
                    "Năm mươi",
                    "Sáu mươi",
                    "Bảy mươi",
                    "Tám mươi",
                    "Chín mươi",
                };

        private static string NumberToWords(decimal number)
        {
            if (number == 0)
                return "Không";

            if (number < 0)
                return $"Âm " + NumberToWords(Math.Abs(number));

            string words = "";

            decimal oddNum = Math.Truncate(number / 1000000000);
            if (oddNum > 0)
            {
                words += NumberToWords(oddNum) + $" tỷ ";
                number %= 1000000000;
            }

            decimal milions = Math.Truncate(number / 1000000);
            if (milions > 0)
            {
                words += NumberToWords(milions) + $" triệu ";
                number %= 1000000;
            }

            decimal thousands = Math.Truncate(number / 1000);
            if (thousands > 0)
            {
                words += NumberToWords(thousands) + $" ngàn ";
                number %= 1000;

                if (number > 0 && number < 100)
                {
                    string zero = "không";
                    string humdr = "Trăm";

                    words += $"{zero} {humdr} ";

                    if (number < 10)
                    {
                        string odd = "lẻ";
                        words += $"{odd} ";
                    }
                }
            }

            decimal hundreds = Math.Truncate(number / 100);
            if (hundreds > 0)
            {
                words += NumberToWords(hundreds) + $" trăm ";
                number %= 100;

                if (number > 0 && number < 10)
                {
                    string odd = "lẻ";
                    words += $"{odd} ";
                }
            }

            if (number > 0)
            {
                if (number < 20)
                {
                    words += unitsMap[(int)number];
                }
                else
                {
                    words += tensMap[(int)number / 10];
                    if (number % 10 > 0)
                        words += " " + unitsMap[(int)number % 10];
                }
            }
            return words.Trim();
        }
    }
}
