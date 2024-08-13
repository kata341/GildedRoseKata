namespace GildedRoseKata.StockItems
{
    public class AgedBrie : StockItem
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        public override void Update()
        {
            Item.SellIn -= 1;

            var qualityChange = Item.SellIn < 0 ? 2 : 1;
            Item.Quality += qualityChange;

            EnforceQualityLimits();
        }
    }
}
