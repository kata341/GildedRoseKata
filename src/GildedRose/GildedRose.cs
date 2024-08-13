using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
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
                    UpdateAgedBrie(Items[i]);
                    continue;
                }

                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePass(Items[i]);
                    continue;
                }

                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            item.SellIn -= 1;

            var qualityChange = item.SellIn < 0 ? 2 : 1;
            item.Quality += qualityChange;

            if (item.Quality > QualityUpperLimit) item.Quality = QualityUpperLimit;
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

    }
}
