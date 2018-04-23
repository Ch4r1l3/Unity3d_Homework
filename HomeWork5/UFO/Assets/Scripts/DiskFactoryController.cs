using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class DiskFactoryController : MonoBehaviour
    {
        public GameObject[] disks;

        void Awake()
        {
            DiskFactory.getInstance().disks = disks;
        }
    }

}

