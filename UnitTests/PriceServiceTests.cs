using Domain;
using Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests
{
    public class PriceServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1", Status.Discontinued, Category.Hardware, 10, 10, false)]
        [TestCase("2", Status.Wholesale, Category.Clothing, 10, 10, true)]
        [TestCase("3", Status.Discounted, Category.Clothing, 10, 8, true)]
        [TestCase("4", Status.Retail, Category.Clothing, 10, 9, true)]
        [TestCase("5", Status.Discounted, Category.Hardware, 10, 8.5, true)]
        [TestCase("6", Status.Wholesale, Category.Hardware, 10, 10, true)]
        public void ProcessInputRecordsTest(string id, Status status, Category category, double inputPrice, double outputPrice, bool isAvailable)
        {
            var inputRecords = new List<InputFormat>()
            {
                new InputFormat() { Id = id,Category=category, Status=status, Price=inputPrice}
            };
            var priceService = new PriceService();
            var outputRecords = priceService.processInputRecords(inputRecords);
            Assert.IsNotNull(outputRecords);
            if (isAvailable)
            {
                Assert.IsTrue(outputRecords.Count > 0);
                Assert.AreEqual(outputRecords[0].Price, outputPrice);
            }
            else
            {
                Assert.IsTrue(outputRecords.Count == 0);
            }
        }
    }
}