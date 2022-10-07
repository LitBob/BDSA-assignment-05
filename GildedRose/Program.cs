using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args){} //OneLine Main
           
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++) {
                //Items[i] => Type Of "LegendaryItem" or something like this
                Items[i].UpdateItemQuality();
                if(Items[i].Quality < 0)
                {
                    Items[i].Quality = 0;
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void UpdateItemQuality() {}
        
    }

    public class LegendaryItem : Item
    {
        //We want to set Quality to always be 80 on all Legendary Items but right now it is just done when creating the item (in tests)
    }

    public class NormalItem : Item
    {
        public bool isConjured { get; set; }
    
        public override void UpdateItemQuality(){
            SellIn = SellIn - 1;
            if (isConjured || SellIn < 0) 
            {
                if (isConjured && SellIn < 0)
                {
                    Quality -= 4;
                }
                else 
                {
                    Quality -= 2;
                }
                
            } 
            else 
            {  
                Quality -= 1;
            }
        }
    }


    public class Cheese : Item
    {
        public override void UpdateItemQuality()
        {
            if(Quality < 50)
            {
                Quality += 1;
            }
            SellIn -= 1;
        }
    }

    public class ConcertTicket : Item
    {
        public override void UpdateItemQuality()
        {
            SellIn -= 1;
            
            if (SellIn > 10)
            {
                Quality += 1;
            }
            else if (SellIn > 5)
            {
                Quality += 2;
            }
            else if (SellIn >= 0)
            {
                Quality += 3;
            }
            else 
            {
                Quality = 0;
            }
         
            
            if (Quality > 50) Quality = 50;
            
        }
    }

}