using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class DiskFactory
    {
        private static DiskFactory _instance;
        private static List<List<GameObject>> buffer;
        public GameObject[] disks;

        public static DiskFactory getInstance()
        {
            if(_instance==null)
            {
                _instance = new DiskFactory();
                buffer = new List<List<GameObject>>();
                for (int i = 0; i < System.Enum.GetValues(typeof(Disk.DiskLevel)).Length; i++)
                    buffer.Add(new List<GameObject>());
            }
            return _instance;
        }
        
        public GameObject getDisk(Disk.DiskLevel level)
        {
            if(buffer[(int)level].Count<=0)
            {
                for (int i = 0; i < 10; i++)
                    buffer[(int)level].Add(GameObject.Instantiate(disks[(int)level]));
                foreach(var disk in disks)
                {
                    disk.SetActive(false);
                }
            }
            var tmp = buffer[(int)level][0];
            buffer[(int)level].Remove(tmp);
            return tmp;
        }

        public void freeDisk(GameObject disk)
        {
            Disk d=disk.GetComponent(typeof(Disk)) as Disk;
            disk.SetActive(false);
            buffer[(int)d.level].Add(disk);
        }
    }
    
}
