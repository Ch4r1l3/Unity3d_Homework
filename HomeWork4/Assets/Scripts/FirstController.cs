using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class FirstController : MonoBehaviour,SceneController,UserAction
    {
        List<DiskController> disks;
        float timeToNextEmission;
        private SceneController scene;
        readonly float emissionTime=1.0f;
        UserGui userGui;

        void Awake()
        {
            Director director = Director.getInstance();
            director.current = this;
            userGui = gameObject.AddComponent<UserGui>() as UserGui;
            loadResources();
        }

        void Update()
        {
            if (userGui.state != GameState.Running)
                return;
            for (int i=0;i<disks.Count;i++)
            {
                if(disks[i].checkHitGround())
                {
                    disks[i].freeDisk();
                    disks.RemoveAt(i);
                    i--;
                }
                else if (!disks[i].getGameObject().activeInHierarchy)
                {
                    userGui.score += disks[i].getScore();
                    disks[i].freeDisk();
                    disks.RemoveAt(i);
                    i--;
                }
            }
        }

        void FixedUpdate()
        {
            if (userGui.state != GameState.Running)
                return;
            if (timeToNextEmission > emissionTime)
            {
                timeToNextEmission = 0;
                emissionDisks();
            }
            else
            {
                timeToNextEmission += Time.deltaTime;
            }
        }

        void emissionDisks()
        {
            var d = new DiskController();
            disks.Add(d);
            d.fireDisk();
        }

        public void loadResources()
        {
            
            disks = new List<DiskController>();
            timeToNextEmission = 0;
        }

        public void start()
        {
            throw new System.NotImplementedException();
        }

        public void fire()
        {
            throw new System.NotImplementedException();
        }

        public void restart()
        {
            for(int i=0;i<disks.Count;)
            {
                disks[0].freeDisk();
                disks.RemoveAt(0);
            }
        }
    }

}
