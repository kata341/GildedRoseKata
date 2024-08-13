namespace GildedRoseKata.StockItems;

public class StockItem
{
    private const int QualityLowerLimit = 0;

    public Item Item { get; }

    public StockItem(Item item)
    {
        Item = item;
    }

    public void Update()
    {
        Item.SellIn -= 1;

        var qualityChange = Item.SellIn < 0 ? -2 : -1;
        Item.Quality += qualityChange;

        EnforceQualityLimits();
    }

    private void EnforceQualityLimits()
    {
        if (Item.Quality < QualityLowerLimit) Item.Quality = QualityLowerLimit;
    }
}
