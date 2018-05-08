using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTrigger : MonoBehaviour {
    public delegate void OnPlayerEnter(GameObject ga);
    public event OnPlayerEnter enter;

    public delegate void OnPlayerExit(GameObject ga);
    public event OnPlayerExit exit;

    private float enterTime;

    private void OnTriggerEnter(Collider other)
    {
        if (enter != null && other.tag == "Player")
        {
            enter(gameObject);
            enterTime = Time.time;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit != null && other.tag == "Player")
        {
            if (Time.time - enterTime > 1.5f && (Director.getInstance().current as FirstController).is_start && gameObject.GetComponent<PatrolData>().IsChasing)
            {
                (Director.getInstance().current as FirstController).userGui.score += 1;
            }
            exit(gameObject);
        }
    }
}
