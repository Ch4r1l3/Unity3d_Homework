using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolData :MonoBehaviour {
    public Vector3 center;
    public bool IsInArea;
    public bool IsChasing = false;
    public void OnPlayerEnterArea()
    {
        IsInArea = true;
        Debug.Log("enter area");
    }

    public void OnPlayerExitArea()
    {
        IsInArea = false;
        Debug.Log("exit area");
        if (IsChasing)
        {
            (Director.getInstance().current as FirstController).patrolOut(gameObject);
            if((Director.getInstance().current as FirstController).is_start)
                (Director.getInstance().current as FirstController).userGui.score += 1;
        }
    }

    
}
