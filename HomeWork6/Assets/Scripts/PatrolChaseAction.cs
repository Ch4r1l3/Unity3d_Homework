using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolChaseAction : SSAction {
    private GameObject player;
    private readonly float m_interpolation = 10;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private Vector3 m_currentDirection = Vector3.zero;
    private float m_moveSpeed = 2;

    public static PatrolChaseAction GetSSAction(GameObject p)
    {
        PatrolChaseAction action = ScriptableObject.CreateInstance<PatrolChaseAction>();
        action.player = p;
        return action;
    }

	public override void Start () {
		
	}
	

	public override void Update () {
        this.transform.LookAt(player.transform.position);
        var target = player.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime);
        gameObject.GetComponent<Animator>().SetFloat("MoveSpeed", 1);
        if(!gameObject.GetComponent<PatrolData>().IsInArea||!gameObject.GetComponent<PatrolData>().IsChasing)
        {
            this.destory = true;
        }
    }
    
}
