using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTitlePanel : MonoBehaviour, IPointerDownHandler, IDragHandler {
    GameObject inventoryPanel;
    private Vector2 offset;
    private float minX = 68f;
    private float maxX = 984f;
    private float minY = -171.5f;
    private float maxY = 388.5f;

    void Start () {
		inventoryPanel = transform.parent.gameObject;
	}
    
    public void OnPointerDown(PointerEventData eventData) {
        offset = eventData.position - new Vector2(inventoryPanel.transform.position.x, inventoryPanel.transform.position.y);
        inventoryPanel.transform.position = eventData.position - offset;
    }

    public void OnDrag(PointerEventData eventData) {
        inventoryPanel.transform.position = new Vector3(Mathf.Clamp(eventData.position.x - offset.x, minX, maxX), Mathf.Clamp(eventData.position.y - offset.y, minY, maxY), 0);
    }
}
