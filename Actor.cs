using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//PLEASE READ
//all of character's class should be inherited from this class
//SOOOOOOOO IMPORTANT
public class Actor : MonoBehaviour
{
    protected Animator animator;

    //basic stats
    public double maxHP = 100;
    public double HP;
    public float moveSpeed = 1;

    //attack stats
    public double attackDamage = 10;
    public float attackSpeed = 1;
    public double attackRange = 1;
    public float next_attack_time; //to control attack speed

    //defense stats
    public double armorPoint = 1;
    public string attackType = "physical";
    public string armorType = "steel";

    [System.NonSerialized] protected GameObject target = null; //this actor will follow and attack this target

    public void Start()
    {
        //animation prepare
        animator = GetComponent<Animator>();
        animator.SetFloat("AttackFreq", 0.3f / 1 * attackSpeed);
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsDead", false);


        HP = maxHP;
        next_attack_time = Time.time + 1 / this.attackSpeed;
        next_reset_target_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        AutoAttack();

        //set the target to null if this actor is not attacking
        if (next_reset_target_time < Time.time && animator.GetBool("IsAttacking")==false)
        {
            resetTarget();
            next_reset_target_time = Time.time + delay_reset_target_time;
        }
    }

    public virtual void AutoAttack()
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
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", false);

        }
    }

    //attack target aka call target's TakeDamage() function
    public virtual void attack() //attack target
    {
        if (next_attack_time <= Time.time)
        {
            target.GetComponent<Actor>().TakeDamage(this.attackDamage, this.attackType, this.gameObject);
            next_attack_time = Time.time + 1 / this.attackSpeed;
        }
    }

    //this actor take damage, the damage will increase or decrease depend on attack type and armor type
    public void TakeDamage(double damage, string type, GameObject attacker)
    {
        if (this.armorType == "steel" && type == "physical")
            damage = damage * 0.75;
        else if (this.armorType == "steel" && type == "magical")
            damage = damage * 1.5;
        else if (this.armorType == "wood" && type == "physical")
            damage = damage * 1.5;
        else if (this.armorType == "wood" && type == "magical")
            damage = damage * 0.75;

        damage = damage - (this.armorPoint * 0.06) / (1 + this.armorPoint * 0.06) * damage;

        this.HP = this.HP - damage;

        if (this.HP <= 0)
        {
            Destroy(this.gameObject,1);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsDead", true);
            attacker.GetComponent<Actor>().resetTarget();
        }
    }

    //reset target (to avoid this actor do everything to attack another one)
    private float delay_reset_target_time = 0.1f;
    private float next_reset_target_time;
    public void resetTarget() //its public to allow others actor set target to null when they get destroyed
    {
        target = null;
    }

    //look for target
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null && collision.tag != this.tag && collision.tag!= "Wall")
        {
            target = collision.gameObject;
        }
    }

    //check if target is in attack range
    protected bool target_is_in_range()
    {
        //if (target == null)

        float target_x = target.transform.position.x;
        float target_y = target.transform.position.y;
        float this_x = this.transform.position.x;
        float this_y = this.transform.position.y;

        float aim_x = target_x - this_x;
        float aim_y = target_y - this_y;

        if (aim_x * aim_x + aim_y * aim_y <= attackRange * attackRange)
            return true;
        return false;
    }

    //just move to the target, nothing more
    protected void move_to_target()
    {
        float target_x = target.transform.position.x;
        float target_y = target.transform.position.y;
        float this_x = this.transform.position.x;
        float this_y = this.transform.position.y;

        float aim_x = target_x - this_x;
        float aim_y = target_y - this_y;

        //move to target
        var aim = new Vector3(aim_x, aim_y, 0);
        aim.Normalize();
        this.transform.Translate(aim * this.moveSpeed * Time.deltaTime);
    }
}
