using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Helper
{
    public class DateUtils
    {
        public static int ConvertPersianToDecimal(string persianNumeral)
        {
            // Create a dictionary to map Persian numerals to their decimal equivalents
            Dictionary<char, int> persianToDecimal = new()
            {
                {'۰', 0},
                {'۱', 1},
                {'۲', 2},
                {'۳', 3},
                {'۴', 4},
                {'۵', 5},
                {'۶', 6},
                {'۷', 7},
                {'۸', 8},
                {'۹', 9}
            };

            int result = 0;

            // Iterate through each character in the Persian numeral string
            foreach (char c in persianNumeral)
            {
                // If the character is a valid Persian numeral, convert it to decimal and add it to the result
                if (persianToDecimal.ContainsKey(c))
                    result = result * 10 + persianToDecimal[c];
            }

            return result;
        }
        public static DateTime ConvertToDate(string persianDate)
        {
            CultureInfo persianCulture = new("fa-IR");
            PersianCalendar persianCalendar = new();

            string[] dateParts = persianDate.Split(' ');
            string dayy = dateParts[0];
            int day = ConvertPersianToDecimal(dayy);
            string monthName = dateParts[1];
            string yearr = dateParts[2];
            int year = ConvertPersianToDecimal(yearr);

            int month = Array.IndexOf(persianCulture.DateTimeFormat.MonthNames, monthName) + 1;

            return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


        public static List<DateTime> GenerateTimeList(DateTime date, TimeSpan startTime, TimeSpan endTime, TimeSpan interval)
        {
            List<DateTime> timeList = new List<DateTime>();

            DateTime currentTime = date.Add(startTime);
            while (currentTime.TimeOfDay <= endTime)
            {
                if (currentTime > DateTime.Now)
                {
                    timeList.Add(currentTime);
                }
                currentTime = currentTime.Add(interval);
            }

            return timeList;
        }


        public string ConvertToPersianDate(DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            string[] monthNames = new string[]
            {
        "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
        "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
            };

            string persianDate = $"{day} {monthNames[month - 1]} {year}";

            return persianDate;
        }


        public static int ConvertToInteger(string input)
        {
            // Remove any non-digit characters from the input string
            string cleanedInput = new String(input.Where(Char.IsDigit).ToArray());

            // Parse the cleaned input as an integer using the Persian culture
            int value = int.Parse(cleanedInput, NumberStyles.AllowThousands, new CultureInfo("fa-IR"));

            return value;
        }

        static string PersianDate(string date)
        {
            DateTime persianDate = ConvertToDate(date);
            return persianDate.ToShortDateString();
        }
    }
}
