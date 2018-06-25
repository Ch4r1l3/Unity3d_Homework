using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoalTrigger : NetworkBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(isServer)
         (Director.getInstance().current as UserAction).win();
    }
}
