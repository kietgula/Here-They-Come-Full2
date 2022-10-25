using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topper : Actor
{

    protected virtual void Update() //virtual because i want to override it sometime to make some specific botter/topper
    {
        GameObject target = find_target_in_range("Botter");

        if (target == null)     //no target in range
            to_the_South();                             //move down
        else
        {
            if (target_is_in_attack_range(target))
                attack(target);
            else move_to(target);
        }     
    }

    private void LateUpdate()
    {
        if (isDead())
            dead();
    }

    private void to_the_South() //GameObject go down yo yo
    {

        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    protected void dead()
    {
        GameEnvironment.Singleton.RemoveTopper(this.gameObject);
        //add money to balance
        //money += x
        //Dead Animation (in couratine)

        Destroy(this.gameObject);
    }

}
