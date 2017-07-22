﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot;

	private InventoryController inv;
	private Tooltip tooltip;
	private Vector2 offset;

	void Start() {
		inv = GameObject.Find("Inventory").GetComponent<InventoryController>();
		tooltip = inv.GetComponent<Tooltip>();
	}

	public void OnPointerDown(PointerEventData eventData) {
		if(item != null) {
			offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
			this.transform.SetParent(this.transform.parent.parent);
			this.transform.position = eventData.position - offset;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if(item != null) {
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData) {
		this.transform.SetParent(this.transform.parent.parent);
		this.transform.SetParent(inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		tooltip.Activate(item);
	}

	public void OnPointerExit(PointerEventData eventData) {
		tooltip.Deactivate();
	}
}
