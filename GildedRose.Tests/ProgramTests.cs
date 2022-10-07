namespace GildedRose.Tests;

public class ProgramTests
{   
    
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void AgedBrieIncreaseQualityDecreaseSellIn()
    {
        // Given
        Cheese agedBrie = new Cheese { Name = "Aged Brie", SellIn = 2, Quality = 0 };
        IList<Item> items = new List<Item>{agedBrie};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 });
    }

    [Fact]
    public void SulfurasNeverChange()
    {
        // Given
        LegendaryItem sulfur1 = new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        LegendaryItem sulfur2 = new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 6, Quality = 80 };
        LegendaryItem sulfur3 = new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -6, Quality = 80 };
        IList<Item> items = new List<Item>{sulfur1, sulfur2, sulfur3};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        program.Items[1].Should().BeEquivalentTo(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 6, Quality = 80 });
        program.Items[2].Should().BeEquivalentTo(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -6, Quality = 80 });
    }

    [Fact]
    public void ElixirDecreaseQualityDecreaseSellIn()
    {
        // Given
        NormalItem exlixir = new NormalItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };
        IList<Item> items = new List<Item>{exlixir};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 });
    }

    [Fact]
    public void BackstagePassNormalSellInAndNormalQualityWhenAbove10DaysSellin()
    {
        // Given
        ConcertTicket BSP1 = new ConcertTicket
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                };
        IList<Item> items = new List<Item>{BSP1};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21 });
    }

    [Fact]
    public void BackstagePassNormalSellInAndDoubleQualityWhenBelow10DaysSellin()
    {
        // Given
        ConcertTicket BSP1 = new ConcertTicket
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 20
                };
        IList<Item> items = new List<Item>{BSP1};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 22 });
    }

    [Fact]
    public void BackstagePassQualityIncreasesBy3WhenSellInBetween0And5()
    {
        // Given
        ConcertTicket BSP1 = new ConcertTicket
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                };
        IList<Item> items = new List<Item>{BSP1};
        Program program = new Program() { Items = items };
    
        // When
        
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 23 });
    }

    [Fact]
    public void BackstagePassQuality0WhenSellin0()
    {
        // Given
        ConcertTicket BSP1 = new ConcertTicket
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20
                };
        IList<Item> items = new List<Item>{BSP1};
        Program program = new Program() { Items = items };
    
        // When
        
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 });
    }

    [Fact]
    public void ElixirDecreaseQualityTwiceWhenNegativeSellin()
    {
        // Given
        NormalItem exlixir = new NormalItem { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 7 };
        IList<Item> items = new List<Item>{exlixir};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Elixir of the Mongoose", SellIn = -2, Quality = 5 });
    }

    [Fact]
    public void ElixirQualityNotBelow0()
    {
        // Given
        NormalItem exlixir = new NormalItem { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 1 };
        IList<Item> items = new List<Item>{exlixir};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Elixir of the Mongoose", SellIn = -2, Quality = 0 });
    }

    [Fact]
    public void AgedBrieQualityCapAt50()
    {
        // Given
        Cheese agedBrie = new Cheese { Name = "Aged Brie", SellIn = -2, Quality = 50 };
        IList<Item> items = new List<Item>{agedBrie};
        Program program = new Program() { Items = items };
    
        // When
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Aged Brie", SellIn = -3, Quality = 50 });
    }

    [Fact]
    public void BackstagePassQualityStay0WhenNegative0()
    {
        // Given
        ConcertTicket BSP1 = new ConcertTicket
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -5,
                    Quality = 0
                };
        IList<Item> items = new List<Item>{BSP1};
        Program program = new Program() { Items = items };
    
        // When
        
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -6, Quality = 0 });
    }

    [Fact]
    public void BackstagePassQualityStay50()
    {
        // Given
        ConcertTicket BSP1 = new ConcertTicket
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 2,
                    Quality = 50
                };
        IList<Item> items = new List<Item>{BSP1};
        Program program = new Program() { Items = items };
    
        // When
        
        program.UpdateQuality();
    
        // Then
        program.Items[0].Should().BeEquivalentTo(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 });
    }
}