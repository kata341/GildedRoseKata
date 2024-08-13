using GildedRoseKata;
using GildedRoseKata.StockItems;
using Xunit;

namespace GildedRoseTests.ConjuredsTests
{
    public class ConjuredTests
    {
        [Fact]
        public void Update_DecreasesSellInBy1()
        {
            var item = new Item() { Quality = 5, SellIn = 5 };
            var conjured = new Conjured(item);

            conjured.Update();

            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void Update_DecreasesQualityBy2()
        {
            var item = new Item() { Quality = 5, SellIn = 5 };
            var conjured = new Conjured(item);

            conjured.Update();

            Assert.Equal(3, item.Quality);
        }

        [Fact]
        public void QualityIsNeverNegative()
        {
            var item =  new Item { Quality = 1 };
            var conjured = new Conjured(item);

            conjured.Update();
            Assert.Equal(0, item.Quality);

            conjured.Update();
            Assert.Equal(0, item.Quality);
        }
    }
}
