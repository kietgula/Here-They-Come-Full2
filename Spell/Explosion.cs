using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Spell
{
    public float SpellDamage = 1;
    public float ExistTime = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != SpellOwner.tag && collision.tag!="Walls")
        {     
            collision.gameObject.GetComponent<Actor>().TakeDamage(SpellDamage, "magical", SpellOwner);
            Destroy(this.gameObject,ExistTime);
        }
    }

}
