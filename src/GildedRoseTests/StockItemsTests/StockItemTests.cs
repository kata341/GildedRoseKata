using GildedRoseKata;
using GildedRoseKata.StockItems;
using Xunit;

namespace GildedRoseTests.StockItemsTests
{
    public class StockItemTests
    {
        [Fact]
        public void Update_DecreasesSellInBy1()
        {
            var item = new Item() { Quality = 5, SellIn = 5 };
            var stockItem = new StockItem(item);

            stockItem.Update();

            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void Update_DecreasesQualityBy1()
        {
            var item = new Item() { Quality = 5, SellIn = 5 };
            var stockItem = new StockItem(item);

            stockItem.Update();

            Assert.Equal(4, item.Quality);
        }

        [Fact]
        public void QualityIsNeverNegative()
        {
            var item =  new Item { Quality = 1 };
            var stockItem = new StockItem(item);

            stockItem.Update();
            Assert.Equal(0, item.Quality);

            stockItem.Update();
            Assert.Equal(0, item.Quality);
        }
    }
}
