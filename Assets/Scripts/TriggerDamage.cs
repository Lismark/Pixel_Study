using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private bool isDestroingAfter;
    [SerializeField] private GameObject parent;
    private IObjectDestroyer destroyer;
    public GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }
    [SerializeField] private int damage;
    public void Init(IObjectDestroyer destroyer)
    {
        this.destroyer = destroyer;
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == parent)
            return;


           if (GameManager.Instance.healthContainer.ContainsKey(collision.gameObject))
        {
            var health = GameManager.Instance.healthContainer[collision.gameObject];
            health.TakeHit(damage);
            var collAnimator = collision.gameObject.GetComponent<Animator>();
            collAnimator.SetTrigger("takeDamage");
            if (isDestroingAfter)
            {
                if (destroyer == null)
                    Destroy(gameObject);
                else destroyer.Destroy(gameObject);
            }
        }
    }

}



public interface IObjectDestroyer
{
    void Destroy(GameObject gameObject);
}
