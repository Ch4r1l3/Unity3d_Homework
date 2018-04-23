using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class PhyDiskFly : SSAction
    {
        Vector3 dire;
        float speed;
        Vector3 force;

        public static PhyDiskFly GetSSAction(Vector3 direction,float sp)
        {
            PhyDiskFly action = ScriptableObject.CreateInstance<PhyDiskFly>();
            action.dire = direction;
            action.speed = sp;
            return action;
        }

        public override void Start()
        {
            force = dire * Random.Range(1.0f, 1.1f) * speed /15;
            if(gameObject.GetComponent<Rigidbody>())
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
            else
            {
                gameObject.AddComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
            
        }

        public override void Update()
        {
        }
    }
}