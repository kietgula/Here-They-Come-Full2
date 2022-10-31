using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Spell
{
    public float SpellDamage = 1;
    public float ExistTime = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Topper")
        {     
            collision.gameObject.GetComponent<Actor>().TakeDamage(SpellDamage, "magical");
            Destroy(this.gameObject,ExistTime);
        }
    }

}
