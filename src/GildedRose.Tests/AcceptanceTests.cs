using System.Collections.Generic;
using System.Linq;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        public void TestQualityDegradingTwiceAsFastWhenSellByDateHasPassed()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Test Item", SellIn = 0, Quality = 40})
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().Item.SellIn);
            Assert.Equal(38, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatItemQualityIsNeverNegative()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Test item", SellIn = 4, Quality = 0})
            };

            Program.UpdateQuality();

            Assert.Equal(3, Program.Items.First().Item.SellIn);
            Assert.Equal(0, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatAgedBrieQualityIncreasesWhenItGetsOlder()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}, new AgedBrieUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(1, Program.Items.First().Item.SellIn);
            Assert.Equal(1, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatAgedBrieQualityIncreasesTwiceAsFastWhenSellInEqualZero()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Aged Brie", SellIn = 0, Quality = 0}, new AgedBrieUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().Item.SellIn);
            Assert.Equal(2, Program.Items.First().Item.Quality);
        }
        
        [Fact]
        public void TestTheItemQualityIsNeverMoreThan50()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Aged Brie", SellIn = 10, Quality = 50}, new AgedBrieUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(9, Program.Items.First().Item.SellIn);
            Assert.Equal(50, Program.Items.First().Item.Quality);
        }
        
        [Fact]
        public void TestUnchangingSulfurasQualityAndSellIn()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}, new SulfurasUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(0, Program.Items.First().Item.SellIn);
            Assert.Equal(80, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatBackstagePassesQualityIncreasesWhenItGetsOlderAndSellInMoreThan10()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20}, new BackstagePassesUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(14, Program.Items.First().Item.SellIn);
            Assert.Equal(21, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatBackstagePassesQualityIncreasesBy2WhenItGetsOlderAndSellInEqualOrLessThan10()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20}, new BackstagePassesUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(9, Program.Items.First().Item.SellIn);
            Assert.Equal(22, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatBackstagePassesQualityIncreasesBy3WhenItGetsOlderAndSellInEqualOrLessThan5()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20}, new BackstagePassesUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(4, Program.Items.First().Item.SellIn);
            Assert.Equal(23, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatBackstagePassesQualityDropsTo0AfterConcert()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20}, new BackstagePassesUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().Item.SellIn);
            Assert.Equal(0, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatConjuredItemQualityDegradesTwiceAsFastAsNormalItems()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Conjured Mana Cake", SellIn = 10, Quality = 40}, new ConjuredUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(9, Program.Items.First().Item.SellIn);
            Assert.Equal(38, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestThatConjuredItemQualityDegradesTwiceAsFastWhenSellInIsNegative()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 40}, new ConjuredUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().Item.SellIn);
            Assert.Equal(36, Program.Items.First().Item.Quality);
        }

        [Fact]
        public void TestConjuredItemQualityWhenItEqualsThree()
        {
            Program.Items = new List<ItemInfo>
            {
                new ItemInfo(new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 3}, new ConjuredUpdater())
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().Item.SellIn);
            Assert.Equal(0, Program.Items.First().Item.Quality);
        }
    }
}
