using UnityEngine;
using System.Collections;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Stackable { get; set; }
    public int Amount { get; set; }
    public string SpriteName { get; set; }
    public Sprite Sprite;


    public Item(int id, string name, string type, bool stackable, int amount, string spriteName)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
        //this.BagNumber = bagNumber;
        this.Stackable = stackable;
        this.Amount = amount;
        this.SpriteName = spriteName;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + spriteName);
    }


    public Item()
    {
        this.Id = -1;
    }
}
