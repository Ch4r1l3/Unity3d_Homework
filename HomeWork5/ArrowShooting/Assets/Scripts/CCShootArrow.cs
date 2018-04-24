using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class CCShootArrow : SSAction
    {
        private CCShootArrow() { }

        public static CCShootArrow GetSSAction()
        {
            CCShootArrow action = CreateInstance<CCShootArrow>();
            return action;
        }
        

        public override void Update()
        {
            if (this.transform.position.z > 15||this.transform.position.z<-10)
            {
                this.destory = true;
                Destroy(gameObject);
            }
        }
        public override void Start()
        {
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.position+Vector3.forward*15, ForceMode.Impulse);
        }
    }
}


