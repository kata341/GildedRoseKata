using GildedRoseKata;
using GildedRoseKata.StockItems;
using Xunit;

namespace GildedRoseTests.StockItemsTests
{
    public class SulfurasTests
    {
        [Fact]
        public void Update_NeverDecreasesQuality()
        {
            var initialQuality = 5;
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = initialQuality };
            var sulfuras = new Sulfuras(item);

            sulfuras.Update();
            Assert.Equal(initialQuality, item.Quality);
        }
    }
}
