using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public class PhysisManager : SSActionManager, ISSActionCallBack, IActionManager
    {
        public void playDisk(GameObject disk, float speed)
        {
            var diskScale = Random.Range(1, 3);
            var emissionDiretion = new Vector3(5.5f, 13.0f, 14f);
            disk.transform.localScale *= diskScale;
            disk.transform.rotation = Quaternion.identity;
            emissionDiretion.x = emissionDiretion.x * Random.Range(-1, 1);
            var fly = PhyDiskFly.GetSSAction(emissionDiretion,speed);
            this.RunAction(disk, fly, this);
        }

        public void SSActionEvent(SSAction sourse, SSActionEventType events = SSActionEventType.Completed)
        {
            if (transform.position.y <= 0)
                Destroy(gameObject.GetComponent<Rigidbody>());
        }
    }

}
 