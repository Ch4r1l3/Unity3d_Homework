using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAD
{
    public enum CharacterType { Priest, Devil };
    public enum CharacterPosition {From,Boat,To };
    public class MyCharacterController
    {
        readonly GameObject character;
        readonly ClickGui clickGui;
        public readonly CharacterType type;

        public CharacterPosition pos { get; set; }

        public MyCharacterController(CharacterType _type)
        {
            if(_type==CharacterType.Priest)
            {
                character = Object.Instantiate(Resources.Load("Perfabs/Priest", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
                character.name = "priest";
                type = _type;
            }
            else
            {
                character = Object.Instantiate(Resources.Load("Perfabs/Devil", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
                character.name = "devil";
                type = _type;
            }
            clickGui = character.AddComponent(typeof(ClickGui)) as ClickGui;
            clickGui.setController(this);
            pos = CharacterPosition.From;
        }
        

        public void setPosition(Vector3 _pos)
        {
            character.transform.position = _pos;
        }

        public void getOnCoast(GameObject coast,Vector3 _pos ,CharacterPosition cpos)
        {
            character.transform.parent = coast.transform;
            pos = cpos;
        }

        public void getOnBoat(GameObject boat,Vector3 _pos)
        {
            character.transform.parent = boat.transform;
            pos = CharacterPosition.Boat;
        }

        public GameObject getGameobj()
        {
            return character;
        }

    }
}


