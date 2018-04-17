using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class DiskController
    {
        public Color[] Colors = { Color.black, Color.blue, Color.cyan, Color.green, Color.grey, Color.red, Color.yellow };
        GameObject disk;
        Vector3 emissionPositon;
        Vector3 emissionDiretion;
        Vector3 force;
        public DiskController()
        {
            emissionPositon = new Vector3(1.5f, 6.2f, -10f);
            emissionDiretion = new Vector3(5.5f, 8.0f, 14f);
        }

        public void fireDisk()
        {
            var factory = DiskFactory.getInstance();
            disk = factory.getDisk(Disk.DiskLevel.Easy);
            var diskScale = Random.Range(1, 3);
            disk.transform.localScale *= diskScale;
            int chooseColor = Random.Range(0, 7);
            disk.GetComponent<Renderer>().material.color = Colors[chooseColor];
            disk.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), emissionPositon.y, emissionPositon.z);
            emissionDiretion.x = emissionDiretion.x * Random.Range(-1, 1);
            disk.SetActive(true);
            force = emissionDiretion * Random.Range(1.0f, 2.0f) / 15;
            disk.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }

        public bool checkHitGround()
        {
            return disk.transform.position.y < 0;
        }

        public void freeDisk()
        {
            var factory = DiskFactory.getInstance();
            disk.GetComponent<Rigidbody>().velocity = Vector3.zero;
            disk.SetActive(false);
            factory.freeDisk(disk);
        }
    }
}