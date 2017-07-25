using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior: MonoBehaviour {

    public int itemID;

    ItemDatabase database;
    InventoryController inventoryController;
    GameObject inventory;

    void Start () {
        inventory = GameObject.Find("Inventory");
        inventoryController = inventory.GetComponent<InventoryController>();
        database = inventory.GetComponent<ItemDatabase>();
        itemID = Random.Range(0, 2);
        Item item = database.FetchItemByID(itemID);
        Debug.Log(item);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.transform.tag == "Player" && !inventoryController.IsInventoryFull() && Input.GetKeyDown(KeyCode.E)) {
            inventoryController.AddItem(0);
            Debug.Log("Player passed over an item.");
            Destroy(gameObject);
        }
    }
}