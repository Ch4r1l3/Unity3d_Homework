using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class FirstController : NetworkBehaviour, SceneController,UserAction{
    public UserGui userGui;
    public bool is_start = false;

    public void loadResources()
    {
    }

    public override void OnStartLocalPlayer()
    {
        if (!isLocalPlayer)
            return;
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        if (!isServer)
            gameObject.transform.position = new Vector3(-10, 0, 0);
        else
            gameObject.transform.position = new Vector3(0, 0, 5);
    }

    public void start()
    {
        
    }
    

    public void restart()
    {
        if(!isLocalPlayer)
            gameObject.transform.position = Vector3.zero;
    }
    
	
	// Update is called once per frame
	void Update () {
    }

    void Awake()
    {
        Director director = Director.getInstance();
        director.current = this;
        
        userGui = gameObject.AddComponent<UserGui>() as UserGui;
        loadResources();
    }

    public void stop()
    {
        Director.getInstance().state = GameState.Fail;
        is_start = false;
    }

    public void win()
    {
        Director.getInstance().state = GameState.Win;
        is_start = false;
    }
}
