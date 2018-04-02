using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PAD
{
    public enum GameState { Win, NotWin, Fail };
    public class UserGui : MonoBehaviour
    {
        public GameState state  { get;set; }
        private UserAction action;
        GUIStyle style;
        GUIStyle buttonStyle;

        void Start()
        {
            action = Director.getInstance().current as UserAction;

            style = new GUIStyle();
            style.fontSize = 40;
            style.alignment = TextAnchor.MiddleCenter;

            buttonStyle = new GUIStyle("button");
            buttonStyle.fontSize = 30;
        }

        void OnGUI()
        {
            if (state == GameState.Fail)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    state = GameState.NotWin;
                    action.restart();
                }
            }
            else if (state == GameState.Win)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    state = GameState.NotWin;
                    action.restart();
                }
            }
        }
    }
}

