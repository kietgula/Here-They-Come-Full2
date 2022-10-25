using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Witch : Botter
{
    public GameObject SpellBullet;
    protected override void attack(GameObject target)
    {
        if (next_attack_time <= Time.time)
        { 
            GameObject spell = Instantiate(SpellBullet, target.transform.position, target.transform.rotation);
            spell.GetComponent<Spell>().SpellOwner = this.gameObject;
            next_attack_time = Time.time + 1 / this.attackSpeed;
        }
    }
}
