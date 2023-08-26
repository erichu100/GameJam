using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : HealthManager
{
    public override void Die()
    {

        transform.position = Vector3.zero;
        //SetHealth(3);
        //
        //EventManager.TriggerEvent("Player_Death");

    }
}
