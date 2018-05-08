using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Start, Running, Fail, Win };
public class UserGui : MonoBehaviour {
    public GameState state { get; set; }
    private UserAction action;
    GUIStyle style;
    GUIStyle textstyle;
    GUIStyle buttonStyle;

    public int score;

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

        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (state == GameState.Start)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Start", buttonStyle))
            {
                state = GameState.Running;
                action.start();
            }
        }
        else if (state == GameState.Fail)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                action.restart();
                restart();
                state = GameState.Running;
            }
        }
        else if (state == GameState.Win)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                action.restart();
                restart();
                state = GameState.Running;
            }
        }
        else
        {
            GUI.Label(new Rect(26, 30, 100, 50), "Score: " + score, textstyle);
        }
    }

    public void restart()
    {
        score = 0;
    }
}
