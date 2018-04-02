using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAD
{
    public class CCCharacterMove : SSAction
    {
        private Vector3 dest;
        private Vector3 middle;
        private enum moving_state { Start, Middle, Stop };
        private moving_state state = moving_state.Stop;
        public float move_speed = 20;

        public static CCCharacterMove GetSSAction(Vector3 target)
        {
            CCCharacterMove action = ScriptableObject.CreateInstance<CCCharacterMove>();
            action.dest = target;
            action.middle = target;
            return action;
        }

        public override void Start()
        {
            if (dest.y < transform.position.y)
            {
                middle.y = transform.position.y;
            }
            else
            {
                middle.x = transform.position.x;
            }
            state = moving_state.Start;
        }

        public override void Update()
        {
            if (state == moving_state.Start)
            {
                transform.position = Vector3.MoveTowards(transform.position, middle, move_speed * Time.deltaTime);
                if (transform.position == middle)
                {
                    state = moving_state.Middle;
                }
            }
            else if (state == moving_state.Middle)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest, move_speed * Time.deltaTime);
                if (transform.position == dest)
                {
                    state = moving_state.Stop;
                }
            }
        }


    }
}