﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Database", menuName ="Databases/Items")]

public class ItemBase : ScriptableObject
{
    [SerializeField] List<Item> items;
    [SerializeField] Item currentItem;
    private int currentIndex;
    public void CreateItem()
    {

        if (items == null)
            items = new List<Item>();
        Item item = new Item();
        items.Add(item);
        currentItem = item;
        currentIndex = items.Count - 1;
    }
    public void RemoveItem()
    {
        if (items == null)
            return;
        if (currentItem == null)
            return;
        items.Remove(currentItem);
        if (items.Count > 0)
            currentItem = items[0];
        else CreateItem();
        currentIndex = 0;
    }
    public void NextItem()
    {
        currentIndex++;
        if (currentIndex < items.Count)
            currentItem = items[currentIndex];
    }
    public void PrevItem()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            currentItem = items[currentIndex];
        }

    }
    public Item GetItemOfId(int id)
    {
        return items.Find(t => t.ID == id);
    }
}

[System.Serializable]
public class Item
{
    [SerializeField] private int id;
    public int ID
    { get { return id; } }

    [SerializeField] private string itemName;
    public string ItemName
    { get { return itemName; } }

    [SerializeField] private string description;
    public string Description
    { get { return description; } }

    [SerializeField] Sprite icon;
    public Sprite Icon
    { get { return icon; } }

    [SerializeField] private BuffType buffType;
    public BuffType Type
    { get { return buffType; } }

    [SerializeField] private float value;
    public float Value
    { get { return value; } }

}
