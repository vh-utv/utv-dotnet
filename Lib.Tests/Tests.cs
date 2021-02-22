using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using UtvDotNet.Lib;
using System.Linq;

namespace UtvDotNet.Lib.Tests
{
    public class Tests
    {
        private List<CountryRaw> _data;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader("./Data/data.json"))
            {
                // Read the stream as a string, and write the string to the console.
                var json = sr.ReadToEnd();
                _data = JsonSerializer.Deserialize<List<CountryRaw>>(json);
                
            }
        }

        [Test]
        public void HasData()
        {
            Assert.AreEqual(_data.Count, 263);
        }

        [Test]
        public void SimpleTest()
        {
            var result = _data
                .Filter(x => x.Year_2016 != null)
                .Map(x => new { Name = x.Country, Population = x.Year_2016 })
                .Aggregate(0l, (sum, country) => sum + (long)country.Population);
            Assert.AreEqual(result, 78823760692l);
        }

        [Test]
        public void IsLazy()
        {
            var first10 = Infinite(_data.First()).Map(x => x.Country).Take(10).ToArray();
            Assert.AreEqual(first10.Length, 10);
            Assert.AreEqual("Aruba,Aruba,Aruba,Aruba,Aruba,Aruba,Aruba,Aruba,Aruba,Aruba", System.String.Join(',', first10));
        }

        private static IEnumerable<T> Infinite<T>(T seed)
        {
            while(true)
            {
                yield return seed;
            }
        }
    }
}