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
        int fire_num = 0;
        IActionManager actionManager;

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
                    userGui.hitGround++;
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
            if (userGui.state != GameState.Running&&fire_num<10)
                return;
            if (timeToNextEmission > emissionTime)
            {
                timeToNextEmission = 0;
                emissionDisks((Disk.DiskLevel)(userGui.round-1));
                fire_num++;
                if (fire_num >= 10)
                {
                    userGui.round++;
                    userGui.hitGround = 0;
                    fire_num = 0;
                }
            }
            else
            {
                timeToNextEmission += Time.deltaTime;
            }
            if (userGui.hitGround > 3)
                userGui.state = GameState.Fail;
            if (userGui.round > 3)
                userGui.state = GameState.Win;
        }

        void emissionDisks(Disk.DiskLevel level)
        {
            var d = new DiskController(actionManager);
            disks.Add(d);
            d.fireDisk(level);
        }

        public void loadResources()
        {
            
            disks = new List<DiskController>();
            timeToNextEmission = 0;
            //actionManager = gameObject.AddComponent<CCActionManager>() as CCActionManager;
            actionManager = gameObject.AddComponent<PhysisManager>() as PhysisManager;
        }
        

        public void restart()
        {
            for(int i=0;i<disks.Count;)
            {
                disks[0].freeDisk();
                disks.RemoveAt(0);
            }
            userGui.restart();
            fire_num = 0;
        }
    }

}
