namespace XUnitTestRomanNumbers
{
    public class RomanArabic
    {

        private static readonly Dictionary<char, int> RomanToArabicMap = new Dictionary<char, int>
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

        public static int ConvertToArabic(string romanNumber)
        {
            int result = 0;
            int previousValue = 0;

            foreach (var numeral in romanNumber)
            {
                int value = RomanToArabicMap[numeral];

                if (value > previousValue)
                {
                    result += value - 2 * previousValue;
                }
                else
                {
                    result += value;
                }

                previousValue = value;
            }

            return result;
        }

        public static string ConvertToRoman(int arabicNumber)
        {
            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[arabicNumber / 1000] +
                   hundreds[(arabicNumber % 1000) / 100] +
                   tens[(arabicNumber % 100) / 10] +
                   ones[arabicNumber % 10];
        }



        [Fact]
        public void Test1()
        {
           
            string romanNumber = "XLII";
            int arabicNumber = ConvertToArabic(romanNumber);
            //Console.WriteLine($"Arabic number for {romanNumber}: {arabicNumber}");
            Assert.Equal(arabicNumber, ConvertToArabic(romanNumber));

            
        }
        [Fact]
        public void Test2()
        {
                        
            int numberToConvert = 42;
            string romanNumber = "XLII";
            string convertedRomanNumber = ConvertToRoman(numberToConvert);
            Assert.Equal(numberToConvert, ConvertToArabic(romanNumber));
        }
    }
}