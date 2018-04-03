using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAD
{
    public class Movable : MonoBehaviour
    {
        readonly float move_speed = 10;
        private enum moving_state {Start,Middle ,Stop };
        private moving_state state;
        Vector3 dest,middle;
        void Awake()
        {
            state = moving_state.Stop;
        }

        void Update()
        {
            if (state == moving_state.Start)
            {
                transform.position = Vector3.MoveTowards(transform.position, middle, move_speed * Time.deltaTime);
                if (transform.position == middle)
                {
                    state = moving_state.Middle;
                }
            }
            else if (state==moving_state.Middle)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest, move_speed * Time.deltaTime);
                if (transform.position == dest)
                {
                    state = moving_state.Stop;
                }
            }
        }

        public bool isMoving()
        {
            return state != moving_state.Stop;
        }

        public void setDest(Vector3 _dest)
        {
            dest = _dest;
            middle = _dest;
            if (_dest.y == transform.position.y)
            {
                state = moving_state.Middle;
            }
            else if (_dest.y < transform.position.y)
            {
                middle.y = transform.position.y;
            }
            else
            {
                middle.x = transform.position.x;
            }
            state=moving_state.Start;
        }

        public void reset()
        {
            state = moving_state.Stop;
        }
    }

}


