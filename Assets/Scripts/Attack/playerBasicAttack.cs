using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBasicAttack : Attack {

	// Use this for initialization
    public playerBasicAttack()
    {
        base.AttackValue = 5f;
        base.AttackRange = 1f;
        base.Cooldown = 1f;
        
    }
    public playerBasicAttack(int a)
    {

    }


	
	// Update is called once per frame

}
