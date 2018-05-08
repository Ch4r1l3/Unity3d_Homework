using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPatrolAction : SSAction {
    public Vector3 center;
    private Vector3 target;
    private int[] tx = { 1, 1, -1, -1 };
    private int[] tz = {1, -1, -1, 1};
    private int idx = 0;

    private readonly float m_interpolation = 10;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private Vector3 m_currentDirection = Vector3.zero;
    private float m_moveSpeed = 2;

    public static GoPatrolAction GetSSAction(Vector3 pos)
    {
        GoPatrolAction action = ScriptableObject.CreateInstance<GoPatrolAction>();
        action.center = pos;
        return action;
    }


    public override void Start()
    {
        target = transform.position;
        idx = Random.Range(0, 4)%4;
        gameObject.GetComponent<Animator>().SetBool("Grounded", true);
    }

    public override void Update()
    {
        if(gameObject.GetComponent<PatrolData>().IsChasing)
        {
            this.destory = true;
        }

        //if(this.transform.position==target)
        if(Vector3.Distance(this.transform.position,target)<0.1f)
        {
            idx++;
            idx %= 4;
            target = center + new Vector3(tx[idx], 0, tz[idx])*Random.Range(0.5f,1.5f);
        }
        else
        {
            this.transform.LookAt(target);
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, Time.deltaTime);
            gameObject.GetComponent<Animator>().SetFloat("MoveSpeed", 1);
        }
    }

}
