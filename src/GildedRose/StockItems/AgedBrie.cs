namespace GildedRoseKata.StockItems
{
    public class AgedBrie
    {
        private const int QualityUpperLimit = 50;

        public Item Item { get; }

        public AgedBrie(Item item)
        {
            Item = item;
        }

        public void Update()
        {
            Item.SellIn -= 1;

            var qualityChange = Item.SellIn < 0 ? 2 : 1;
            Item.Quality += qualityChange;

            EnforceQualityLimits();
        }

        private void EnforceQualityLimits()
        {
            if (Item.Quality > QualityUpperLimit) Item.Quality = QualityUpperLimit;
        }
    }
}
