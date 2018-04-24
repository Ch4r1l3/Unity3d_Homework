using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arrow
{
    public class UserGui : MonoBehaviour
    {
        GUIStyle style;
        GUIStyle textstyle;
        GUIStyle buttonStyle;
        private UserAction action;
        

        void Start()
        {
            action = Director.getInstance().current as UserAction;
            textstyle = new GUIStyle();
            textstyle.fontSize = 20;
            textstyle.alignment = TextAnchor.MiddleCenter;

            buttonStyle = new GUIStyle("button");
            buttonStyle.fontSize = 30;
        }

        // Update is called once per frame
        void OnGUI()
        {
            GameState state = (Director.getInstance().current as FirstController).gameState;
            if (state == GameState.Start)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Start", buttonStyle))
                {
                    (Director.getInstance().current as FirstController).gameState = GameState.Running;
                    action.restart();
                }
            }
            else if (state == GameState.Fail)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    (Director.getInstance().current as FirstController).gameState = GameState.Running;
                    action.restart();
                    restart();
                }
            }
            else if (state == GameState.Win)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    (Director.getInstance().current as FirstController).gameState = GameState.Running;
                    action.restart();
                    restart();
                }
            }
            else
            {
                GUI.Label(new Rect(26, 30, 100, 50), "Score: " + ScoreRecorder.getInstance().getScore(), textstyle);
            }
        }

        private void Update()
        {
            GameState state = (Director.getInstance().current as FirstController).gameState;
            if(state==GameState.Running&&Input.GetMouseButtonDown(0))
            {
                (Director.getInstance().current as UserAction).shootArrow();
            }
        }

        public void restart()
        {
            ScoreRecorder.getInstance().setScore(0);
        }
    }

}
