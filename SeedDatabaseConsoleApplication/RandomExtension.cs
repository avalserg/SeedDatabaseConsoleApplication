using SeedDatabaseConsoleApplication.Enums;

namespace SeedDatabaseConsoleApplication
{
    public static class RandomExtension
    {
        public static Gender RandomGender()
        {
            var values = Enum.GetValues(typeof(Gender));
            var random = new Random();
            return (Gender)values.GetValue(random.Next(values.Length))!;
        }
        public static string RandomUse()
        {
            Random random = new Random();
            var inofficialValue = "official";
            var officialValue = "inofficial";
            return random.Next(2) == 0 ? inofficialValue : officialValue;
        }

        public static bool RandomBooleanValue()
        {
            var random = new Random();
            return random.NextDouble() > 0.5;
        }

        public static int RandomPostfixValue()
        {
            var random = new Random();
            return random.Next(0, int.MaxValue);
        }

        public static DateTime GetRandomDate(this Random random, int minYear = 2000, int maxYear = 2023)
        {
            var year = random.Next(minYear, maxYear);
            var month = random.Next(1, 12);
            var noOfDaysInMonth = DateTime.DaysInMonth(year, month);
            var day = random.Next(1, noOfDaysInMonth);

            return new DateTime(year, month, day);
        }
    }
}
