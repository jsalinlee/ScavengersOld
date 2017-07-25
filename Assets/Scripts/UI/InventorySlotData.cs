using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventorySlotData : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
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
            if (this.transform.parent.transform.GetComponent<InventorySlot>() != null && this.transform.parent.transform.GetComponent<InventorySlot>().GetType() == typeof(InventorySlot)) {
                this.transform.SetParent(this.transform.parent.parent);
                this.transform.position = eventData.position - offset;
            } 
            GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

    public void OnPointerUp(PointerEventData eventData) {
        if (this.transform.parent.parent.transform.GetComponent<InventoryController>() != null && this.transform.parent.parent.transform.GetComponent<InventoryController>().GetType() == typeof(InventoryController)) {
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.SetParent(inv.slots[slot].transform);
            this.transform.position = inv.slots[slot].transform.position;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
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
