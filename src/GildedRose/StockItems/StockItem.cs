namespace GildedRoseKata.StockItems;

public class StockItem
{
    private const int QualityLowerLimit = 0;
    private const int QualityUpperLimit = 50;

    public Item Item { get; }

    public StockItem(Item item)
    {
        Item = item;
    }

    public virtual void Update()
    {
        Item.SellIn -= 1;

        var qualityChange = Item.SellIn < 0 ? -2 : -1;
        Item.Quality += qualityChange;

        EnforceQualityLimits();
    }

    protected void EnforceQualityLimits()
    {
        if (Item.Quality < QualityLowerLimit) Item.Quality = QualityLowerLimit;
        if (Item.Quality > QualityUpperLimit) Item.Quality = QualityUpperLimit;
    }
}
