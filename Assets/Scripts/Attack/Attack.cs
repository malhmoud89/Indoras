using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

    private float attackValue;
    private float attackRange;
    private float cooldown;

    public Attack()
    {
        attackValue = attackRange = cooldown = 0f;
    }

    public float AttackValue
    {
        get
        {
            return attackValue;
        }
        set
        {
            attackValue = value;
        }
    }

    public float AttackRange
    {
        get
        {
            return attackRange;
        }
        set
        {
            attackRange = value;
        }
    }
    public float Cooldown
    {
        get
        {
            return cooldown;
        }
        set
        {
            cooldown = value;
        }
    }



}
