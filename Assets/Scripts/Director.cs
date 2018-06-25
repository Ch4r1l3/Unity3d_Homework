using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;



public class Director :  NetworkBehaviour
{
    private static Director _instance;
    public SceneController current { set; get; }
    public GameState state;

    public static Director getInstance()
    {
        if (_instance == null)
        {
            GameObject go = new GameObject();
            _instance = go.AddComponent<Director>();
        }
        return _instance;
    }

}