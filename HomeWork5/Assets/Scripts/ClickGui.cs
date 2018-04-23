using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class ClickGui : MonoBehaviour
    {

        UserAction action;

        private void Awake()
        {
            action = Director.getInstance().current as UserAction;
        }

        private void OnMouseDown()
        {
        }
    }

}
