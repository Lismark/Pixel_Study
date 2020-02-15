using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private WaitForSeconds delay;
    private Coroutine damageProcess = null;
    private Health target = null;
    private void Awake()
    {
        delay = new WaitForSeconds(0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false && GameManager.Instance.healthContainer.ContainsKey(collision.gameObject))
        {
            target = GameManager.Instance.healthContainer[collision.gameObject];
            damageProcess = StartCoroutine(Trapping());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false && GameManager.Instance.healthContainer.ContainsKey(collision.gameObject))
        {
            if(target == GameManager.Instance.healthContainer[collision.gameObject])
            {
                StopCoroutine(damageProcess);
                target = null;
                damageProcess = null;
            }
        }
    }
    private IEnumerator Trapping()
    {
        while(true)
        {
            target.TakeHit(damage);
            yield return delay;
        }

    }

}

