using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arrow
{
    public class SSActionManager : MonoBehaviour
    {
        private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
        private List<SSAction> waitingAdd = new List<SSAction>();
        private List<int> waitingDelete = new List<int>();

        protected void Update()
        {
            foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
            waitingAdd.Clear();
            foreach (KeyValuePair<int, SSAction> kv in actions)
            {
                SSAction ac = kv.Value;
                if (ac.destory)
                {
                    waitingDelete.Add(ac.GetInstanceID());
                }
                else if (ac.enabled)
                {
                    ac.Update();
                }
            }

            foreach (int key in waitingDelete)
            {
                SSAction ac = actions[key];
                actions.Remove(key);
                DestroyObject(ac);
            }
            waitingDelete.Clear();
        }

        protected void Start() { }

        public void RunAction(GameObject gameObject, SSAction action, ISSActionCallBack manager)
        {
            action.gameObject = gameObject;
            action.callback = manager;
            action.transform = gameObject.transform;
            waitingAdd.Add(action);
            action.Start();
        }
    }


}