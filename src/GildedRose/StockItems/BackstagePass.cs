namespace GildedRoseKata.StockItems
{
    public class BackstagePass : StockItem
    {
        public BackstagePass(Item item) : base(item)
        {
        }

        public override void Update()
        {
            Item.SellIn -= 1;

            var qualityChange = 1;
            if (Item.SellIn < 10) qualityChange = 2;
            if (Item.SellIn < 5) qualityChange = 3;
            Item.Quality += qualityChange;

            if (Item.SellIn < 0) Item.Quality = 0;

            EnforceQualityLimits();
        }
    }
}
