using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Xunit.Abstractions;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQualityDoesNotChangeItemName()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void QualityIsNeverNegative()
        {
            var items = new List<Item> { new Item { Quality = 1 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);

            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void QualityIsNeverMoreThan50()
        {
            var items = new List<Item> { new Item { Name="Aged Brie", Quality = 49 } };
            var app = new GildedRose(items);

            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);

            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void SulfurasNeverDecreasesInQuality()
        {
            var initialQuality = 5;
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = initialQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();
            Assert.Equal(initialQuality, items[0].Quality);
        }

        [Theory]
        [InlineData(11, 5, 6)] // Quality increases by 1 when SellIn > 10
        [InlineData(10, 5, 7)] // Quality increases by 2 when SellIn <= 10
        [InlineData(9, 5, 7)]
        [InlineData(8, 5, 7)]
        [InlineData(7, 5, 7)]
        [InlineData(6, 5, 7)]
        [InlineData(5, 5, 8)] // Quality increases by 3 when SellIn <= 5
        [InlineData(4, 5, 8)]
        [InlineData(3, 5, 8)]
        [InlineData(2, 5, 8)]
        [InlineData(1, 5, 8)]
        [InlineData(0, 5, 0)] // Quality set to 0 when SellIn <= 0
        [InlineData(-1, 5, 0)]
        public void BackstagePassesQualityChanges(int initialSellIn, int initialQuality, int expectedQuality)
        {
            var items = new List<Item> {
                new Item {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = initialQuality,
                    SellIn = initialSellIn
                }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();
            Assert.Equal(expectedQuality, items[0].Quality);
        }
    }
}
