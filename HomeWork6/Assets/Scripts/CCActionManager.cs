using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallBack
{
    public void goPatrol(GameObject p,Vector3 pos)
    {
        GoPatrolAction action = GoPatrolAction.GetSSAction(pos);
        this.RunAction(p, action, this);
    }

    public void patrolChase(GameObject p,GameObject player)
    {
        PatrolChaseAction action = PatrolChaseAction.GetSSAction(player);
        this.RunAction(p, action, this);
    }

    public void SSActionEvent(SSAction sourse, SSActionEventType events = SSActionEventType.Completed)
    {
        
        throw new System.NotImplementedException();
    }

    protected new void Update()
    {
        base.Update();
    }
}
