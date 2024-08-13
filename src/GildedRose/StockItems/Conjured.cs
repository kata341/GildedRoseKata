namespace GildedRoseKata.StockItems;

public class Conjured : StockItem
{
    public Conjured(Item item) : base(item)
    {
    }

    public override void Update()
    {
        Item.SellIn -= 1;

        var qualityChange = Item.SellIn < 0 ? -4 : -2;
        Item.Quality += qualityChange;

        EnforceQualityLimits();
    }
}
