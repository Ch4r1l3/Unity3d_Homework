using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChobiAssets.KTP;

[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class AI : MonoBehaviour {

    // Use this for initialization
    public Transform player;
    public ID_Control_CS idScript;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public Vector3[] partol = {new Vector3(-60,2,128),new Vector3(60,2,128),new Vector3(60,2,-128),new Vector3(-60,2,-128)};
    int idx = 0;
    bool isChase = false;
    void Start () {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updatePosition = true;
        agent.stoppingDistance = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {

        //agent.SetDestination(player.position);

        var direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        
        if(angle<55)
        {
            RaycastHit hit;
            var tmp_dire = player.position- transform.position;
            if(Physics.Raycast(transform.position, tmp_dire.normalized ,out hit,1000))
            {
                if (player.IsChildOf(hit.collider.gameObject.transform))
                {
                    isChase = true;
                }
            }
        }
        

        if(!isChase)
        {
            agent.SetDestination(partol[idx % 4]);

            var speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude;
            transform.LookAt(transform.position + agent.desiredVelocity);

            var wheel = gameObject.GetComponent<Wheel_Control_CS>();
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                wheel.leftRate = -0.5f;
                wheel.rightRate = 0.5f;
            }

            if (Vector3.Distance(transform.position, partol[idx % 4]) < 10)
                idx++;
        }
        else
        {
            if(Vector3.Distance(transform.position,player.position)>100)
            {

                agent.SetDestination(player.transform.position);

                transform.LookAt(transform.position + agent.desiredVelocity);
                var wheel = gameObject.GetComponent<Wheel_Control_CS>();
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    wheel.leftRate = -0.5f;
                    wheel.rightRate = 0.5f;
                }
            }
            else
            {
                var wheel = gameObject.GetComponent<Wheel_Control_CS>();
                if(gameObject.GetComponent<Rigidbody>().velocity.magnitude>3)
                {

                    wheel.leftRate = 0.5f;
                    wheel.rightRate = -0.5f;
                }
                else
                {
                    wheel.leftRate = 0f;
                    wheel.rightRate = 0f;
                }
            }
            var turret = gameObject.GetComponentInChildren<Turret_Control_CS>();
            turret.targetTransform = player;
            turret.targetPos = player.position;
            turret.targetOffset.y = 0.5f;
            turret.isTracking = true;
            
            idScript.fireButton = true;
        }
        
	}
}
