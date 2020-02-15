using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuffReciever : MonoBehaviour
{
    [SerializeField] ItemBase itemBase;
    // [SerializeField] Arrow arrow;
    [SerializeField] Health playerHealth;
    [SerializeField] Player player;
    [SerializeField] int forceBonus;
    [SerializeField] int armorBonus;
    [SerializeField] int damageBonus;
 
    private List<Buff> buffs;
    public Action OnBuffsChanged;
    private void Start()
    {
        GameManager.Instance.buffRecieverContainer.Add(gameObject, this);
        buffs = new List<Buff>();

        
    }
    public void AddBuff(Buff buff)
    {
        if (!buffs.Contains(buff))
            buffs.Add(buff);
        if (OnBuffsChanged != null)
            OnBuffsChanged();



        switch (buff.type)
        {
            case BuffType.Damage:
                if(damageBonus == 0)
                {
                    damageBonus = (int)(itemBase.GetItemOfId(1).Value);
                    player.SetDamage(damageBonus);
                    Debug.Log($"damage bonus: {damageBonus}");
                }
                break;
            case BuffType.Force:
                if (forceBonus == 0)
                {
                    forceBonus = (int)(itemBase.GetItemOfId(2).Value);
                    player.Force += forceBonus;
                }
                break;
            case BuffType.Armor:
                if (armorBonus == 0)
                {
                    armorBonus = (int)(itemBase.GetItemOfId(3).Value);
                    player.Armor += armorBonus;
                }
                break;
            default:
                break;
        }
    }
    public void RemoveBuff(Buff buff)
    {
        if (buffs.Contains(buff))
            buffs.Remove(buff);
        if (OnBuffsChanged != null)
            OnBuffsChanged();
        Debug.Log(buff);
    }

}

