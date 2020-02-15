using UnityEngine;

public class ItemComponent : MonoBehaviour, IObjectDestroyer
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Item item;
    public Item Item
    { get { return item; } }

    public void Destroy(GameObject gameObject)
    {
        MonoBehaviour.Destroy(gameObject);
    }

    private void Start()
    {
        item = GameManager.Instance.itemDataBase.GetItemOfId((int)itemType);
        spriteRenderer.sprite = item.Icon;
        GameManager.Instance.itemsContainer.Add(gameObject, this);
    }

}
public enum ItemType
{
    HealthPotion = 1, DamagePotion = 2, DefensePotion = 3
}
