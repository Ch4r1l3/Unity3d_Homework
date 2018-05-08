using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        (Director.getInstance().current as UserAction).win();
    }
}
