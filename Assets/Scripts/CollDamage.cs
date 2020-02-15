using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollDamage : MonoBehaviour
{
    [SerializeField] private int collDamage = 10;
    [SerializeField] private Health health;
    [SerializeField] private Animator animator;
    private float direction;
    public float Direction { get { return direction; } }



    private void OnCollisionStay2D(Collision2D collision)
     {
        if (GameManager.Instance.healthContainer.ContainsKey(collision.gameObject))
        {
            health = GameManager.Instance.healthContainer[collision.gameObject];
            direction = (gameObject.transform.position - collision.transform.position).x;
        }
        animator.SetFloat("Damage", Mathf.Abs(direction));


    }
    private void SetDamage()
    {
        if (health != null)
        {
            health.TakeHit(collDamage);
            health = null;
        }
        direction = 0f;
        animator.SetFloat("Damage", 0.0f);

    }
    
}
