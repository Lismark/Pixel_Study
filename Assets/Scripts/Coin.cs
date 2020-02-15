using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Start()
    {
        GameManager.Instance.coinContainer.Add(gameObject, this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Destroy");
    }
    public void EndDestroy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
