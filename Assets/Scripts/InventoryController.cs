using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryController : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;
    public GameObject inGameItem;
    public Tooltip tooltip;

	private int maxSlotCount;
    private int currentSlotCount;

	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start() {
		database = GameObject.FindObjectOfType<ItemDatabase>();
        Debug.Log(database.FetchItemByID(10));
		maxSlotCount = 20;
        currentSlotCount = 0;
		inventoryPanel = GameObject.Find("Inventory Panel");
		slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;

        for (int i = 0; i < maxSlotCount; i++) {
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<InventorySlot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform);
        }
        for (int i = 0; i < slots.Count; i++) {
            slots[i].name = "Empty Inventory Slot";
        }
        AddItem(10);
        AddItem(10);
        AddItem(11);
		AddItem(11);
		AddItem(11);
        inventoryPanel.SetActive(false);
    }

	void Update() {
		if(Input.GetKeyDown(KeyCode.I)) {
			if(inventoryPanel.activeSelf) {
                tooltip.Deactivate();
                inventoryPanel.SetActive(false);
			} else {
				inventoryPanel.SetActive(true);
			}
		}
	}

	public void AddItem(int id) {
		Item itemToAdd = database.FetchItemByID(id);
		if (itemToAdd.Stackable && IsItemInInventory(itemToAdd)) {
			for(int i = 0; i < items.Count; i++) {
				if(items[i].ID == id) {
                    items[i].Quantity++;
                    InventorySlotData data = slots[i].transform.GetChild(0).GetComponent<InventorySlotData>();
					data.transform.GetChild(0).GetComponent<Text>().text = items[i].Quantity.ToString();
				}
			}
		} else {
			for(int i = 0; i < items.Count; i++) {
				if(items[i].ID == -1) {
                    currentSlotCount++;
					items[i] = itemToAdd;

                    // Completely UI tweaks, no game functionality
                    GameObject itemObj = Instantiate(inventoryItem);
					itemObj.GetComponent<InventorySlotData>().item = itemToAdd;
					itemObj.GetComponent<InventorySlotData>().slot = i;
					itemObj.transform.SetParent(slots[i].transform);
					itemObj.transform.position = slots[i].transform.position;
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					slots[i].name = itemToAdd.Title + " Slot";
                    break;
				}
			}
		}
	}

    public void DropItem(Guid itemUniqueID) {
        
        for (int i = 0; i < items.Count; i++) {
            if (items[i].UniqueID == itemUniqueID ) {
                inGameItem.GetComponent<ItemBehavior>().itemID = items[i].ID;
                Instantiate(inGameItem);
                items.Remove(items[i]);
            }
        }
    }

	bool IsItemInInventory(Item item) {
		for(int i = 0; i < items.Count; i++) {
			if(items[i].ID == item.ID) {
				return true;
			}
		}
		return false;
	}

    public bool IsInventoryFull() {
        if(currentSlotCount == maxSlotCount) {
            return true;
        } else {
            return false;
        }
    }

    public Item FetchItemByUniqueID(Guid uniqueID)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].UniqueID == uniqueID) {
                return items[i];
            }
        }
        return null;
    }
}
