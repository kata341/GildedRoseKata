using GildedRoseKata;
using GildedRoseKata.StockItems;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests.StockItemsTests
{
    public class BackstagePassTests
    {
        [Fact]
        public void Update_DecreasesSellInBy1()
        {
            var item = new Item() { Quality = 5, SellIn = 5 };
            var BackstagePass = new BackstagePass(item);

            BackstagePass.Update();

            Assert.Equal(4, item.SellIn);
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
            var item = new Item {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = initialQuality,
                SellIn = initialSellIn
            };

            var backstagePass = new BackstagePass(item);

            backstagePass.Update();
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void QualityIsNeverOver50()
        {
            var item =  new Item { Quality = 49, SellIn = 3 };
            var backstagePass = new BackstagePass(item);

            backstagePass.Update();
            Assert.Equal(50, item.Quality);

            backstagePass.Update();
            Assert.Equal(50, item.Quality);
        }
    }
}
