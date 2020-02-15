using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    #endregion
    public Dictionary<GameObject, Health> healthContainer;
    public Dictionary<GameObject, Coin> coinContainer;
    public Dictionary<GameObject, BuffReciever> buffRecieverContainer;
    public Dictionary<GameObject, ItemComponent> itemsContainer;
    [HideInInspector] public PlayersInventory inventory;
    public ItemBase itemDataBase;

    private void Awake()
    {
        Instance = this;
        healthContainer = new Dictionary<GameObject, Health>();
        coinContainer = new Dictionary<GameObject, Coin>();
        buffRecieverContainer = new Dictionary<GameObject, BuffReciever>();
        itemsContainer = new Dictionary<GameObject, ItemComponent>();
    }


}
