﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	private int slotCount;

	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start() {
		database = GetComponent<ItemDatabase>();
		slotCount = 20;
		inventoryPanel = GameObject.Find("Inventory Panel");
		slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;

		for(int i = 0; i < slotCount; i++) {
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<InventorySlot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform);
		}
		AddItem(0);
		AddItem(1);
		AddItem(1);
		AddItem(1);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.I)) {
			if(inventoryPanel.activeSelf) {
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
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
				}
			}
		} else {
			for(int i = 0; i < items.Count; i++) {
				if(items[i].ID == -1) {
					items[i] = itemToAdd;
					GameObject itemObj = Instantiate(inventoryItem);
					itemObj.GetComponent<ItemData>().item = itemToAdd;
					itemObj.GetComponent<ItemData>().slot = i;
					itemObj.transform.SetParent(slots[i].transform);
					itemObj.transform.position = Vector2.zero;
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
					itemObj.GetComponent<ItemData>().amount++;
					itemObj.name = itemToAdd.Title;
					slots[i].name = itemToAdd.Title + " Slot";
					break;
				}
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
}
