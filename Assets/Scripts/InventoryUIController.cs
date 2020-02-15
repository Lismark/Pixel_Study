using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] Cell[] cells;
    [SerializeField] int cellCount;
    [SerializeField] Cell cellPrefab;
    [SerializeField] Transform rootParent;
    [SerializeField] GameObject cellImage;
    [SerializeField] private BuffReciever buffReciever;
    private Sprite cellImageBg;

    private void Awake()
    {
        
        cells = new Cell[cellCount];
        for(int i = 0; i < cellCount; i++)
        {
            cells[i] = Instantiate(cellPrefab, rootParent);
        }
        cellPrefab.gameObject.SetActive(false);
       

    }
    private void Start()
    {
        buffReciever.OnBuffsChanged += InventoryRefresh;
    }

    public void InventoryRefresh()
    {
        var inventory = GameManager.Instance.inventory;

        for (int i = 0; i < cells.Length; i++)
        {
            if (i < inventory.Items.Count)
                cells[i].Init(inventory.Items[i]);
            else
                cells[i].Init(null);
            
        }
        Debug.Log("Обновление инвентаря");
        
    }

}
