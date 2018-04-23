using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{

    public class Disk : MonoBehaviour
    {
        public enum DiskLevel:int { Easy=0,Medium=1,Hard=2};
        public int score;
        public int speed;
        public DiskLevel level;

    }

}