using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class CollisionDetection : MonoBehaviour
    {

        void Start()
        {
        }

        void OnTriggerEnter(Collider arrow_head)
        {
            Transform arrow = arrow_head.gameObject.transform.parent;
            if (arrow == null)
            {
                return;
            }
            if (arrow.tag == "arrow")
            {
                arrow.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                arrow.GetComponent<Rigidbody>().isKinematic = true;
                arrow_head.gameObject.gameObject.SetActive(false);
                ScoreRecorder.getInstance().addScore(gameObject.GetComponent<RingScore>().score);
            }
        }
    }

}

