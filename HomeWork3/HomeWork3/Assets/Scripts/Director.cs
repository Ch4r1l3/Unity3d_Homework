using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PAD
{
    class Director: System.Object
    {
        private static Director _instance;
        public SceneController current { set; get; }

        public static Director getInstance()
        {
            if(_instance==null)
                _instance=new Director();
            return _instance;
        }
    }
}
