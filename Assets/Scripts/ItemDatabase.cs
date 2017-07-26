using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;

public class ItemDatabase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemsData;

	void Start() {
		itemsData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase(itemsData);
    }

	public Item FetchItemByID(int id) {
		for (int i = 0; i < database.Count; i++) {
			if (database[i].ID == id) {
				return database[i];
			}
		}
		return null;
	}

	void ConstructItemDatabase(JsonData items) {
        foreach (string category in items.Keys) {
            foreach (string subcategory in items[category].Keys) {
                if (category == "weapons") {
                    JsonData weaponCategory = items[category][subcategory];
                    for (int i = 0; i < weaponCategory.Count; i++) {
                        database.Add(new Weapon((int)weaponCategory[i]["id"], weaponCategory[i]["title"].ToString(), (int)weaponCategory[i]["value"], (float)(double)weaponCategory[i]["durability"], weaponCategory[i]["description"].ToString(), (bool)weaponCategory[i]["stackable"], (int)weaponCategory[i]["rarity"], weaponCategory[i]["slug"].ToString(), "melee", (float)(double)weaponCategory[i]["power"], 0, 0, 0));
                    }
                } else if (category =="armor") {
                    JsonData armorCategory = items[category][subcategory];
                    for (int i = 0; i < armorCategory.Count; i++) {
                        
                    }
                }
            }
        }
    }
}

public class Item {
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public float Durability { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
    public int Quantity { get; set; }
    public Guid UniqueID { get; set; }

    public Item(int id, string title, int value, float durability, string description, bool stackable, int rarity, string slug) {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Durability = durability;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
        this.Quantity = 1;
        this.UniqueID = Guid.NewGuid();
    }

    public Item() {
        this.ID = -1;
    }
}

public class Weapon : Item {
    public string Type { get; set; }
    public float Power { get; set; }
    public int AmmoID { get; set; }
    public int ClipCapacity { get; set; }
    public float ReloadTime { get; set; }

    public Weapon(int id, string title, int value, float durability, string description, bool stackable, int rarity, string slug, string type, float power, int ammoID, int clipCapacity, float reloadTime): base(id, title, value, durability, description, stackable, rarity, slug) {
        this.Type = type;
        this.Power = power;
        if (this.Type == "melee" || this.Type == "special") {
            this.AmmoID = -1;
            this.ClipCapacity = -1;
            this.ReloadTime = -1;
        } else {
            this.AmmoID = ammoID;
            this.ClipCapacity = clipCapacity;
            this.ReloadTime = reloadTime;
        }
    }
}

public class Armor : Item {
    
}