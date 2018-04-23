using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class CCDiskFly:SSAction
    {
        public float gravity;                      
        private Vector3 start_vector;
        private Vector3 gravity_vector;            
        private float time;
        private Vector3 current_angle;           

        public static CCDiskFly GetSSAction(Vector3 direction, float angle, float power)
        {
            CCDiskFly action =ScriptableObject.CreateInstance<CCDiskFly>();
            action.start_vector = Quaternion.Euler(new Vector3(-angle, 0,0)) * Vector3.forward * power+Vector3.right*Random.Range(-10,10);
            return action;
        }

        public override void Start()
        {
            gravity = -6;
            gravity_vector = Vector3.zero;
            current_angle = Vector3.zero;
        }

        public override void Update()
        {
            time += Time.fixedDeltaTime;
            gravity_vector.y = gravity * time;
            
            transform.position += (start_vector + gravity_vector) * Time.fixedDeltaTime;
            current_angle.x = -Mathf.Atan((start_vector.y + gravity_vector.y) / start_vector.z) * Mathf.Rad2Deg;
            transform.eulerAngles = current_angle;
            
        }
    }

}