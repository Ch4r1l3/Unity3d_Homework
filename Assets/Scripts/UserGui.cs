using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum GameState { Start, Running, Fail, Win };
public class UserGui : NetworkBehaviour
{
    private UserAction action;
    
    
    GUIStyle style;
    GUIStyle textstyle;
    GUIStyle buttonStyle;
    bool start;

    // Use this for initialization
    void Start () {
        action = Director.getInstance().current as UserAction;

        style = new GUIStyle();
        style.fontSize = 40;
        style.alignment = TextAnchor.MiddleCenter;

        textstyle = new GUIStyle();
        textstyle.fontSize = 20;
        textstyle.alignment = TextAnchor.MiddleCenter;

        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 30;
        
        start = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        if(isServer)
        {
            if (NetworkServer.connections.Count != 2)
            {
                Director.getInstance().state = GameState.Start;
            }
            else if (!start)
            {
                start = true;
                Director.getInstance().state = GameState.Running;
            }
            RpcSyncValue(Director.getInstance().state);
        }
	}


    [ClientRpc]
    public void RpcSyncValue(GameState s)
    {
        Director.getInstance().state = s;
    }

    private void OnGUI()
    {
        if (!isLocalPlayer)
            return;
        if (Director.getInstance().state == GameState.Start)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Waiting", style);
        }
        else if (Director.getInstance().state == GameState.Fail)
        {
            if(!isServer)
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
            else
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
        }
        else if (Director.getInstance().state == GameState.Win)
        {
            if(!isServer)
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
            else
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
           
        }
    }

    public void restart()
    {
    }
}
