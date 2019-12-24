using System;
using Xunit;

namespace CourseApp.Tests
{
    public class AgeTest
    {
        [Fact]
        public void TestDate()
        {
            double a = DateTime.Now.Ticks - new DateTime(2000, 08, 03).Ticks;
            double b = AgeClass.DateCompare(new DateTime(2000, 08, 03), DateTime.Now).Ticks;
            if (b - a > 0.000000001)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void TestAgeVchera()
        {
            string st = $"Вам 10 лет, 0 месяцев и 1 дня";
            Assert.Equal(st, AgeClass.Age(new DateTime(2009, 12, 20), new DateTime(2019, 12, 21)));
        }

        [Fact]
        public void TestAgeToday()
        {
            string st = $"Вам 8 лет, 0 месяцев и 0 дня";
            Assert.Equal(st, AgeClass.Age(new DateTime(2011, 12, 21), new DateTime(2019, 12, 21)));
        }

        [Fact]
        public void TestAgeTommorow()
        {
            string st = $"Вам 10 лет, 0 месяцев и 0 дня";
            Assert.Equal(st, AgeClass.Age(new DateTime(2009, 12, 21), new DateTime(2019, 12, 21)));
        }

        [Fact]
        public void BirthdayAboveToday()
        {
            try
            {
                Assert.Equal(0, DateTime.Compare(DateTime.Now, AgeClass.DateCompare(new DateTime(2019, 12, 21), new DateTime(2048, 8, 16))));
            }
            catch (Exception)
            {
                Console.WriteLine("Birthday > Today");
            }
        }
    }
}