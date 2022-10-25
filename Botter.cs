using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botter : Actor
{
    protected virtual void Update()
    {
        GameObject target = find_target_in_range("Topper");

        if (target == null) ;     //no target in range
                                  //stand still
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

    protected void dead()
    {
        //Botter dead is not actually destroyed but just disable to be enable again in next turn
        GameEnvironment.Singleton.RemoveBotter(this.gameObject);
        GameEnvironment.Singleton.AddDeadBotter(this.gameObject);
        //Dead Animation (in couratine)

        this.gameObject.SetActive(false);
    }
}
