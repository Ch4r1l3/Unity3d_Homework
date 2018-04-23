using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class RoundController
    {
        private int round;
        RoundController()
        {
            round = 1;
        }

        public void nextRound()
        {
            if (round <= 3)
                round++;
        }

        public void Restart()
        {
            round = 1;
        }


    }
}

