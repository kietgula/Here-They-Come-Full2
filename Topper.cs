using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topper : Actor
{
    override public void AutoAttack()
    {
        if (target != null)
        {
            if (target_is_in_range())
            {
                attack();
                animator.SetBool("IsAttacking", true);
                animator.SetBool("IsWalking", false);
            }
            else
            {
                move_to_target();
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalking", true);
            }
            //animator.SetBool("IsAttacking", false);
        }
        else
        {
            this.transform.Translate(new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", true);
        }

    }
}
