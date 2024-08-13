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
    }
}
