using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    public int PHealth { get { return health; } }
    [SerializeField] Animator selfAnimator;

public void TakeHit(int damage){
        health -= damage;
        if (selfAnimator != null)
            selfAnimator.SetTrigger("takeDamage");
        Debug.Log($"Жизни {gameObject}: {health}");
    if(health <= 0){
        Destroy(gameObject);
    }
}


public void AddHealth(int add){
    health += add;
        Debug.Log(health);
    }

    private void Start()
    {
        GameManager.Instance.healthContainer.Add(gameObject, this);
    }

}
