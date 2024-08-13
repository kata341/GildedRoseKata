namespace GildedRoseKata.StockItems
{
    public class BackstagePass
    {
        private const int QualityUpperLimit = 50;

        public Item Item { get; }

        public BackstagePass(Item item)
        {
            Item = item;
        }

        public void Update()
        {
            Item.SellIn -= 1;

            var qualityChange = 1;
            if (Item.SellIn < 10) qualityChange = 2;
            if (Item.SellIn < 5) qualityChange = 3;
            Item.Quality += qualityChange;

            if (Item.SellIn < 0) Item.Quality = 0;

            EnforceQualityLimits();
        }

        private void EnforceQualityLimits()
        {
            if (Item.Quality > QualityUpperLimit) Item.Quality = QualityUpperLimit;
        }
    }
}
