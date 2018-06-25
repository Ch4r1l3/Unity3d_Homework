using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour {

    public delegate void OnEnterEvent();
    public event OnEnterEvent enter;

    public delegate void OnExitEvent();
    public event OnExitEvent exit;

    private void OnTriggerEnter(Collider other)
    {
        if(enter!=null && other.tag=="Player")
            enter();
    }

    private void OnTriggerExit(Collider other)
    {
        if(exit!=null && other.tag=="Player")
            exit();
    }
}
