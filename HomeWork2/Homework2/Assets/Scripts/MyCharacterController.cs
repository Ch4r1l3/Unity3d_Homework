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
        readonly Movable move;
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
            move = character.AddComponent(typeof(Movable)) as Movable;
            clickGui = character.AddComponent(typeof(ClickGui)) as ClickGui;
            clickGui.setController(this);
            pos = CharacterPosition.From;
        }

        public void moveToPosition(Vector3 dest)
        {
            move.setDest(dest);
        }

        public void setPosition(Vector3 _pos)
        {
            character.transform.position = _pos;
        }

        public void getOnCoast(GameObject coast,Vector3 _pos ,CharacterPosition cpos)
        {
            character.transform.parent = coast.transform;
            move.setDest(_pos);
            pos = cpos;
        }

        public void getOnBoat(GameObject boat,Vector3 _pos)
        {
            character.transform.parent = boat.transform;
            move.setDest(_pos);
            pos = CharacterPosition.Boat;
        }
        
        public bool isMoving()
        {
            return move.isMoving();
        }
        
    }
}


