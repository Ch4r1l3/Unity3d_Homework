using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType : int { Started, Completed };

public interface ISSActionCallBack
{
    void SSActionEvent(SSAction sourse, SSActionEventType events = SSActionEventType.Completed);
}

public class SSAction : ScriptableObject
{
    public bool enabled = true;
    public bool destory = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public ISSActionCallBack callback { get; set; }

    protected SSAction() { }

    public virtual void Start() { throw new System.NotImplementedException(); }

    public virtual void Update() { throw new System.NotImplementedException(); }
}