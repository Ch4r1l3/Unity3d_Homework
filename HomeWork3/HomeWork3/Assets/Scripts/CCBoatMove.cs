using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAD
{
    public class CCBoatMove : SSAction
    {
        public Vector3 target;
        public float speed = 20;

        public static CCBoatMove GetSSAction(Vector3 target)
        {
            CCBoatMove action = ScriptableObject.CreateInstance<CCBoatMove>();
            action.target = target;
            return action;
        }

        public override void Start()
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, this.speed * Time.deltaTime);
        }

        public override void Update()
        {
            if (this.transform.position == target)
            {
                this.destory = true;
                this.callback.SSActionEvent(this);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, this.speed * Time.deltaTime);
            }
        }
    }

}