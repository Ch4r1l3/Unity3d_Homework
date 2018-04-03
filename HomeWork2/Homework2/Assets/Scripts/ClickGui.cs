using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAD
{
    public class ClickGui : MonoBehaviour
    {
        UserAction action;
        MyCharacterController character;
        public void setController(MyCharacterController _char)
        {
            character = _char;
        }

        private void Awake()
        {
            action = Director.getInstance().current as UserAction;
        }

        private void OnMouseDown()
        {
            if(gameObject.name=="boat")
            {            
                action.moveBoat();
            }
            else
            {
                action.characterClick(character);
            }
        }
    }

}
