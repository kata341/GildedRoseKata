using GildedRoseKata.StockItems;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const int QualityLowerLimit = 0;
        private const int QualityUpperLimit = 50;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {

                if (Items[i].Name == "Aged Brie")
                {
                    new AgedBrie(Items[i]).Update();
                    continue;
                }

                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    new BackstagePass(Items[i]).Update();
                    continue;
                }

                if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    new Sulfuras(Items[i]).Update();
                    continue;
                }

                new StockItem(Items[i]).Update();
            }
        }

        private void UpdateBackstagePass(Item item)
        {
            item.SellIn -= 1;

            var qualityChange = 1;
            if (item.SellIn < 10) qualityChange = 2;
            if (item.SellIn < 5) qualityChange = 3;
            item.Quality += qualityChange;

            if (item.SellIn < 0) item.Quality = 0;

            if (item.Quality > QualityUpperLimit) item.Quality = QualityUpperLimit;
        }

        private void UpdateSulfuras(Item item)
        {
        }
    }
}
