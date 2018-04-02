using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PAD
{
    public class CoastController
    {
        readonly GameObject coast;
        private Vector3[] positions;
        private MyCharacterController[] characters;
        public CoastController(Vector3 Base)
        {
            coast = Object.Instantiate(Resources.Load("Perfabs/Stone", typeof(GameObject)), Base, Quaternion.identity, null) as GameObject;
            characters = new MyCharacterController[6];
            positions = new Vector3[6];
            for (int i = 0; i < 6; i++)
            {
                positions[i] = new Vector3(Base.x-2.5F + i * 1F, 2.25F, 0);
            }
        }

        public int getEmptyIndex()
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == null)
                    return i;
            }
            return -1;
        }

        public Vector3 getEmptyPosition()
        {
            int idx = getEmptyIndex();
            return positions[idx];
        }

        public void addCharacter(MyCharacterController c)
        {
            int idx = getEmptyIndex();
            characters[idx] = c;
        }

        public void removeCharacter(MyCharacterController c)
        {
            for(int i=0;i<characters.Length;i++)
            {
                if (characters[i] == c)
                {
                    characters[i] = null;
                    return;
                }
            }
        }

        public GameObject getGameobj()
        {
            return coast;
        }

        public int[] checkGame()
        {
            int[] num = new int[2];
            for(int i=0;i<characters.Length;i++)
            {
                if(characters[i]!=null)
                {
                    if (characters[i].type == CharacterType.Devil)
                        num[0]++;
                    else
                        num[1]++;
                }
            }
            return num;
        }

        public void reset()
        {
            for (int i = 0; i < characters.Length; i++)
                characters[i] = null;
        }
    }
}