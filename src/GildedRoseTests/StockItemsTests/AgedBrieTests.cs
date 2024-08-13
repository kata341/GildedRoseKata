using GildedRoseKata;
using GildedRoseKata.StockItems;
using Xunit;

namespace GildedRoseTests.StockItemsTests
{
    public class AgedBrieTests
    {
        [Fact]
        public void Update_DecreasesSellInBy1()
        {
            var item = new Item() { Quality = 5, SellIn = 5 };
            var agedBrie = new AgedBrie(item);

            agedBrie.Update();

            Assert.Equal(4, item.SellIn);
        }

        [Theory]
        [InlineData(2, 5, 6)] // Quality increases by 1 when SellIn > 0
        [InlineData(1, 5, 6)]
        [InlineData(0, 5, 7)] // Quality increases by 1 when SellIn <= 0
        [InlineData(-1, 5, 7)]
        [InlineData(-2, 5, 7)]
        public void AgedBrieIncreasesInQuality(int initialSellIn, int initialQuality, int expectedQuality)
        {
            var item = new Item {
                Name = "Aged Brie",
                Quality = initialQuality,
                SellIn = initialSellIn
            };
            var agedBrie = new AgedBrie(item);

            agedBrie.Update();
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void QualityIsNeverOver50()
        {
            var item =  new Item { Quality = 49 };
            var agedBrie = new AgedBrie(item);

            agedBrie.Update();
            Assert.Equal(50, item.Quality);

            agedBrie.Update();
            Assert.Equal(50, item.Quality);
        }
    }
}
