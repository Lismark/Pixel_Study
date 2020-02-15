using UnityEngine.UI;
using UnityEngine;
using System;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Item item;
    public Action InventoryRefresh;
    private void Awake()
    {
        icon.sprite = null;
       icon.color = Color.clear;
    }
    public void Init(Item item)
    {
        this.item = item;
        if (item == null)
        {
            icon.color = Color.clear;
            icon.sprite = null;
        }
        else
        {
            icon.sprite = item.Icon;
            icon.color = Color.white;
        }
    }
    public void OnClickCell()
    {
        if (item == null)
            return;
        GameManager.Instance.inventory.Items.Remove(item);
        Buff buff = new Buff
        {
            type = item.Type,
            additiveBuff = item.Value
        };
        GameManager.Instance.inventory.buffReciever.AddBuff(buff);
        if(InventoryRefresh != null)
        InventoryRefresh();
    }
}
