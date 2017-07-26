using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior: MonoBehaviour {

    public int itemID;
    Item item;
    ItemDatabase database;
    InventoryController inventoryController;
    GameObject inventory;

    void Start () {
        itemID = 10;
        inventory = GameObject.Find("Inventory");
        inventoryController = inventory.GetComponent<InventoryController>();
        database = GameObject.FindObjectOfType<ItemDatabase>();
        item = database.FetchItemByID(itemID);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.Sprite;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.transform.tag == "Player" && !inventoryController.IsInventoryFull() && Input.GetKeyDown(KeyCode.E)) {
            inventoryController.AddItem(itemID);
            Destroy(gameObject);
            //inventoryController.DropItem(item.UniqueID);
        }
    }
}