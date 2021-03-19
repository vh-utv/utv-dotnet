using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace UtvDotNet.Lib.Tests
{
    public class Tests
    {
        private static Func<long, Func<long, bool>> lt = max => x => x < max;
        private static Func<long, bool> isEven = x => x % 2 == 0;
        private static Func<long, long> square = x => x * x;
        private static Func<long, long, long> mult = (x, y) => x * y;
        private static Func<long, long, long> sum = (x, y) => x + y;
        private static Func<string, Func<string, bool>> startsWith = (s) => x => x.StartsWith(s, ignoreCase: true, culture: CultureInfo.InvariantCulture);
        private static Func<string, Func<string, string, string>> concat = seperator => (string a, string b) => a != String.Empty ? $"{a}{seperator}{b}" : b;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanFilterLazily()
        {
            var count = TestData.Infinite(1)
                .Filter(x => x == 1)
                .Take(10)
                .Count();
            Assert.AreEqual(10, count);
        }

        [Test]
        public void CanFilterEmpty()
        {
            var actual = new long[0]
                .Filter(lt(100))
                .ToArray();
            CollectionAssert.AreEqual (new long[0], actual);
        }

        [Test]
        public void CanFilterNumbers()
        {
            var expected = new [] { 2L };
            var actual = TestData.Numbers
                .Filter(isEven)
                .ToArray();
            CollectionAssert.AreEqual (expected, actual);
        }

        [Test]
        public void CanFilterTuples()
        {
            var expected = new []
                {
                    "Afghanistan",
                    "Albania",
                    "Algeria",
                    "American Samoa",
                    "AndorrA",
                    "Angola",
                    "Anguilla",
                    "Antarctica",
                    "Antigua and Barbuda",
                    "Argentina",
                    "Armenia",
                    "Aruba",
                    "Australia",
                    "Austria",
                    "Azerbaijan"
                };
            var actual = TestData.Countries
                .Filter<(string name, string code)>(x => startsWith("A")(x.name))
                .Map(x => x.name)
                .ToArray();
            Console.WriteLine(String.Join(',', actual));
            CollectionAssert.AreEqual (expected, actual);
        }

        [Test]
        public void CanMapLazily()
        {
            var result = TestData
                .Infinite(1L)
                .Map(square)
                .Take(5)
                .ToArray();
            CollectionAssert.AreEqual(new [] { 1, 1, 1, 1, 1 }, result);
        }

        [Test]
        public void CanMapEmpty()
        {
            var actual = new long[0]
                .Map(square)
                .ToArray();
            CollectionAssert.AreEqual(new long[0], actual);
        }

        [Test]
        public void CanMapNumbers()
        {
            var expected = new[] { 4, 9, 25, 49, 121, 169 };
            var actual = TestData.Numbers
                .Map(square)
                .Take(6)
                .ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void CanMapTuples()
        {
            var expected = new[] { "AF", "AX", "AL", "DZ", "AS" };
            var actual = TestData.Countries
                .Map<(string name, string code), string>(x => x.code)
                .Take(5)
                .ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void CanReduceEmpty()
        {
            var result = new long[0]
                .Reduce(25L, sum);
            Assert.AreEqual(25, result);
        }

        [Test]
        public void CanReduceNumbers()
        {
            var result = TestData.Numbers
                .Reduce(0L, sum);
            Assert.AreEqual(32615, result);
        }

        [Test]
        public void CanReduceStrings()
        {
            var result = TestData.Countries
                .Take(5)
                .Map(x => x.code)
                .Reduce(String.Empty, concat(","));
            Assert.AreEqual("AF,AX,AL,DZ,AS", result);
        }

        [Test]
        public void Chain1()
        {
            var nums = TestData.Numbers;
            var actual = nums.Filter(lt(100))
                             .Map(square)
                             .Reduce(0, sum);
            Assert.AreEqual(52545, actual);
        }

        [Test]
        public void Chain2()
        {
            var expected = "AF-AL-AR-AU-AZ-BE-BO-BR-CA-CO-CU-CY-CZ-DJ-DO-EC-EG-ER-ET-FI-FR-GA-GE-GH-GI-GR-GU-HU-IN-IR-IT-JE-JO-KE-KI-LA-LI-LU-NA-NI-NO-OM-PA-PE-PH-QA-RE-RO-RU-RW-SA-SO-SY-TH-TO-UG-UZ-VE-VI-YE";
            var actual = TestData.Countries
                .Filter(c => startsWith(c.code)(c.name))
                .Map(c => c.code)
                .Reduce("", concat("-"));
            Assert.AreEqual(expected, actual);
        }
    }
}
