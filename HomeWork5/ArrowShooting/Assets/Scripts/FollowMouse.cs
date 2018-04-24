using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class FollowMouse : MonoBehaviour
    {
        Camera mycam;
        // Use this for initialization
        void Start()
        {
            mycam = GetComponent<Camera>();

        }

        // Update is called once per frame
        void Update()
        {
            GameState state = (Director.getInstance().current as FirstController).gameState;
            if ( state!= GameState.Running)
                return;
            float sensitivity = 0.05f;
            Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
            vp.x -= 0.5f;
            vp.y -= 0.5f;
            vp.x *= sensitivity;
            vp.y *= sensitivity;
            vp.x += 0.5f;
            vp.y += 0.5f;
            Vector3 sp = mycam.ViewportToScreenPoint(vp);

            Vector3 v = mycam.ScreenToWorldPoint(sp);
            if (v.y <= 0.8 || v.y >= 1.2)
                return;
            transform.LookAt(v, Vector3.up);
        }
    }

}
