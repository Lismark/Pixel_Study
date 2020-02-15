using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int healingAmount;
    [SerializeField] Animator medPackAnimator;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(GameManager.Instance.healthContainer.ContainsKey(collision.gameObject))
        {
            Health playerHealth = GameManager.Instance.healthContainer[collision.gameObject];
            playerHealth.AddHealth(healingAmount);
            medPackAnimator.SetTrigger("Healing");

            
        }

    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
