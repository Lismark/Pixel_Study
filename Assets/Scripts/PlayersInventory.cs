using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PlayersInventory : MonoBehaviour
{
    [SerializeField] InventoryUIController UIcontroller;
    public BuffReciever buffReciever;
    public int coins;
    private List<Item> items;
    public List<Item> Items
    { get { return items; } set { items = value; } }

    [SerializeField] private Text coinsText;

    private void Start()
    {
        items = new List<Item>();
        GameManager.Instance.inventory = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.coinContainer.ContainsKey(collision.gameObject))
        {
            coins++;
            coinsText.text = coins.ToString();
            Debug.Log($"Монеток в кармане: {coins}");
        }
        if(GameManager.Instance.itemsContainer.ContainsKey(collision.gameObject))
        {
            
            var itemComponent = GameManager.Instance.itemsContainer[collision.gameObject];
            Items.Add(itemComponent.Item);
            itemComponent.Destroy(collision.gameObject);
            UIcontroller.InventoryRefresh();

        }
    }

}
