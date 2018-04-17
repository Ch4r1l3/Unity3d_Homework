using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFO
{
    public enum GameState { Start, Running, Fail ,Win};
    public class UserGui : MonoBehaviour
    {
        public GameState state { get; set; }
        public int score,round;
        private UserAction action;
        GUIStyle style;
        GUIStyle textstyle;
        GUIStyle buttonStyle;

        void Start()
        {
            action = Director.getInstance().current as UserAction;

            style = new GUIStyle();
            style.fontSize = 40;
            style.alignment = TextAnchor.MiddleCenter;

            textstyle = new GUIStyle();
            textstyle.fontSize = 20;
            textstyle.alignment = TextAnchor.MiddleCenter;

            buttonStyle = new GUIStyle("button");
            buttonStyle.fontSize = 30;
            state = GameState.Start;
            score = 0;
            round = 1;
        }

        void restart()
        {
            score = 0;
            round = 1;
        }

        void OnGUI()
        {
            if (state==GameState.Start)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Start", buttonStyle))
                {
                    state = GameState.Running;
                    action.restart();
                }
            }
            else if (state == GameState.Fail)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    state = GameState.Running;
                    action.restart();
                    restart();
                }
            }
            else if (state == GameState.Win)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    state = GameState.Running;
                    action.restart();
                    restart();
                }
            }
            else
            {
                GUI.Label(new Rect(26, 30, 100, 50), "Score: "+score, textstyle);
                GUI.Label(new Rect(30, 60, 100, 50), "Round: " + round, textstyle);
            }
        }
    }
}