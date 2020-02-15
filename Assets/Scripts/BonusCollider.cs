using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCollider : MonoBehaviour
{
    [SerializeField] private BuffReciever buffReciever;
    [SerializeField] private int forceBonus;
    public int ForceBonus
    { get; set; }
    [SerializeField] private int armorBonus;
    public int ArmorBonus
    { get; set; }
    [SerializeField] private int damageBonus;
    public int DamageBonus
    { get; set; }

    public void Update()
    {
        
    }

}
