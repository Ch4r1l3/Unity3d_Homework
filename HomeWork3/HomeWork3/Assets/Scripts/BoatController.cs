using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PAD
{

    public enum BoatState { From, To };
    public class BoatController
    {
        readonly GameObject boat;
        readonly Vector3 fromPosition;
        readonly Vector3 toPosition;
        readonly Vector3[] from_positions;
        readonly Vector3[] to_positions;

        MyCharacterController[] passenger = new MyCharacterController[2];

        
        private BoatState to_or_from;
        public BoatController(Vector3 frompos,Vector3 topos)
        {
            to_or_from = BoatState.From;
            fromPosition = frompos;
            toPosition = topos;
            from_positions = new Vector3[] { new Vector3(frompos.x-0.5f, frompos.y+0.5f, 0), new Vector3(frompos.x + 0.5f, frompos.y + 0.5f, 0) };
            to_positions = new Vector3[] { new Vector3(topos.x-0.5f, topos.y+0.5F, 0), new Vector3(topos.x + 0.5f, topos.y + 0.5F, 0) };

            boat = Object.Instantiate(Resources.Load("Perfabs/Boat", typeof(GameObject)), fromPosition, Quaternion.identity, null) as GameObject;
            boat.name = "boat";
            
            boat.AddComponent(typeof(ClickGui));
        }

        public Vector3 Move()
        {
            if (!hasPassenger())
                return fromPosition;
            if (to_or_from == BoatState.To)
            {
                to_or_from = BoatState.From;
                return fromPosition;
            }
            else
            {
                to_or_from = BoatState.To;
                return toPosition;
            }
        }

        public bool hasPassenger()
        {
            for (int i = 0; i < passenger.Length; i++)
                if (passenger[i] != null)
                    return true;
            return false;
        }

        public GameObject getGameobj()
        {
            return boat;
        }

        public int getEmptyIndex()
        {
            for (int i = 0; i < passenger.Length; i++)
            {
                if (passenger[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        public Vector3 getEmptyPosition()
        {
            Vector3 pos;
            int emptyIndex = getEmptyIndex();
            if (to_or_from == BoatState.To)
            {
                pos = to_positions[emptyIndex];
            }
            else
            {
                pos = from_positions[emptyIndex];
            }
            return pos;
        }

        public void GetOnBoat(MyCharacterController characterCtrl)
        {
            int index = getEmptyIndex();
            passenger[index] = characterCtrl;
        }

        public void GetOffBoat(MyCharacterController c)
        {
            for(int i=0;i<passenger.Length;i++)
            {
                if(passenger[i]==c)
                {
                    passenger[i] = null;
                    return;
                }
            }
        }
        

        public BoatState getBoatPos()
        {
            return to_or_from;
        }

        public void reset()
        {
            boat.transform.position = fromPosition;
            to_or_from = BoatState.From;
            for (int i = 0; i < passenger.Length; i++)
                passenger[i] = null;
        }

        public int[] checkGame()
        {
            int[] num = new int[2];
            for(int i=0;i<passenger.Length;i++)
            {
                if (passenger[i]!=null)
                {
                    if (passenger[i].type == CharacterType.Devil)
                        num[0]++;
                    else
                        num[1]++;
                }
            }
            return num;
        }
    }
}

