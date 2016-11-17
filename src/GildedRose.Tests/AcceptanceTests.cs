using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        public void When_SellByDate_has_passed_then_Quality_degrades_twice_as_fast()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Test Item", SellIn = 0, Quality = 40}
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().SellIn);
            Assert.Equal(38, Program.Items.First().Quality);
        }

        [Fact]
        public void Given_Quality_is_zero_when_Quality_is_updated_then_It_is_equal_or_above_zero()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Test item", SellIn = 4, Quality = 0}
            };

            Program.UpdateQuality();

            Assert.Equal(3, Program.Items.First().SellIn);
            Assert.Equal(0, Program.Items.First().Quality);
        }

        [Fact]
        public void When_AgedBrie_gets_older_then_Its_quality_increases()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}
            };

            Program.UpdateQuality();

            Assert.Equal(1, Program.Items.First().SellIn);
            Assert.Equal(1, Program.Items.First().Quality);
        }
        
        [Fact]
        public void When_SellByDate_has_passed_then_AgedBrie_quality_increases_twice_as_fast()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 0}
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().SellIn);
            Assert.Equal(2, Program.Items.First().Quality);
        }
        
        [Fact]
        public void Given_Quality_is_fifty_when_Quality_is_updated_then_It_is_equal_or_below_fifty()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 50}
            };

            Program.UpdateQuality();

            Assert.Equal(9, Program.Items.First().SellIn);
            Assert.Equal(50, Program.Items.First().Quality);
        }

        [Fact]
        public void When_Sulfuras_gets_older_then_Its_quality_and_sellIn_are_unchanged()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
            };

            Program.UpdateQuality();

            Assert.Equal(0, Program.Items.First().SellIn);
            Assert.Equal(80, Program.Items.First().Quality);
        }
        
        [Fact]
        public void Given_BackstagePasses_sellIn_is_above_ten_when_It_gets_older_then_Its_quality_increases_by_one()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20}
            };

            Program.UpdateQuality();

            Assert.Equal(14, Program.Items.First().SellIn);
            Assert.Equal(21, Program.Items.First().Quality);
        }
        
        [Fact]
        public void Given_BackstagePasses_sellIn_is_equal_or_below_ten_when_It_gets_older_then_Its_quality_increases_by_two()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20}
            };

            Program.UpdateQuality();

            Assert.Equal(9, Program.Items.First().SellIn);
            Assert.Equal(22, Program.Items.First().Quality);
        }
        
        [Fact]
        public void Given_BackstagePasses_sellIn_is_equal_or_below_five_when_It_gets_older_then_Its_quality_increases_by_three()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20}
            };

            Program.UpdateQuality();

            Assert.Equal(4, Program.Items.First().SellIn);
            Assert.Equal(23, Program.Items.First().Quality);
        }
        
        [Fact]
        public void Given_BackstagePasses_sellIn_is_equal_or_below_zero_when_It_gets_older_then_Its_quality_drops_to_zero()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20}
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().SellIn);
            Assert.Equal(0, Program.Items.First().Quality);
        }
        
        [Fact]
        public void When_ConjuredItem_gets_older_then_Its_quality_degrades_twice_as_fast_as_normal_items()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 10, Quality = 40}
            };

            Program.UpdateQuality();

            Assert.Equal(9, Program.Items.First().SellIn);
            Assert.Equal(38, Program.Items.First().Quality);
        }
        
        [Fact]
        public void When_SellByDate_has_passed_then_ConjuredItem_quality_degrades_twice_as_fast()
        {
            Program.Items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 40}
            };

            Program.UpdateQuality();

            Assert.Equal(-1, Program.Items.First().SellIn);
            Assert.Equal(36, Program.Items.First().Quality);
        }
    }
}
