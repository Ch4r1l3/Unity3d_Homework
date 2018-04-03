using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PAD
{
    public interface UserAction
    {
        void moveBoat();
        void characterClick(MyCharacterController c);
        void restart();
    }

}