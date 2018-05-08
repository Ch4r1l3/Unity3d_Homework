using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFactory  {
    private static PatrolFactory _instance;
    private static List<GameObject> buffer;


    public static PatrolFactory getInstance()
    {
        if(_instance == null)
        {
            _instance = new PatrolFactory();
            buffer = new List<GameObject>();
        }
        return _instance;
    }
	
    public GameObject getPatrol()
    {
        if(buffer.Count<=0)
        {
            for(int i=0;i<10;i++)
            {
                var _gameobject = GameObject.Instantiate(Resources.Load("Patrol")) as GameObject;
                var t = _gameobject.transform.GetChild(1);
                var rend = t.GetComponent<Renderer>();
                rend.material.SetColor("_Color", Color.green);
                _gameobject.AddComponent<PatrolData>();
                buffer.Add(_gameobject);
            }
            foreach(var tp in buffer)
            {
                tp.SetActive(false);
            }
        }
        var p = buffer[0];
        buffer.Remove(p);
        return p;
    }

    public void freePatrol(GameObject p)
    {
        p.SetActive(false);
        buffer.Add(p);
    }
}
