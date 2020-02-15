using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEmitter : MonoBehaviour
{
    [SerializeField] private Buff buff;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.buffRecieverContainer.ContainsKey(collision.gameObject))
        {
            var reciever = GameManager.Instance.buffRecieverContainer[collision.gameObject];
            reciever.AddBuff(buff);
        }
    }
}

[System.Serializable]
public class Buff
{
    public float additiveBuff;
    public float multiplyBuff;
    public BuffType type;
}

public enum BuffType
{
    Damage = 1, Force = 2, Armor = 3
}
