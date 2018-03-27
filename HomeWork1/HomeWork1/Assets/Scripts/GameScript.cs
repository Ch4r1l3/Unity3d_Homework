using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    int current_user = 0;
    int[] flag;
    string symbol = "○x ";
    bool running;
    // Use this for initialization
    void Start()
    {
        flag = new int[9];
        for (int i = 0; i < 9; i++)
            flag[i] = 2;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool Check_Win()
    {
        for(int i=0;i<2;i++)
        {
            for(int q=0;q<3;q++)
            {
                if((flag[3*q]==flag[3*q+1]&&flag[3*q]==flag[3*q+2]&&flag[3*q]==i)
                    || (flag[q]==flag[q+3]&&flag[q]==flag[q+6]&&flag[q]==i)
                    || (flag[0]==flag[4]&&flag[0]==flag[8]&& flag[0]==i)
                    || (flag[2]==flag[4]&&flag[2]==flag[6]&& flag[2]==i)
                    )
                {
                    GUI.Label(new Rect(800, 100, 120, 80), symbol[i]+" is Winning!");
                    return true;
                }
            }
        }
        return false;
    }

    void OnGUI()
    {
        GUIStyle button_style = GUI.skin.GetStyle("button");
        button_style.fontSize = 30;
        GUIStyle label_style = GUI.skin.GetStyle("label");
        label_style.fontSize = 20;
        running = !Check_Win();
        for (int i = 0; i < 9; i++)
        {
            int x = i % 3;
            int y = i / 3;
            if (GUI.Button(new Rect(300 + 100 * x, 50 + 100 * y, 100, 100), "" + symbol[flag[i]]))
            {
                if (flag[i] == 2&& running)
                {
                    flag[i] = current_user % 2;
                    current_user += 1;
                }

            }
        }
        if (current_user == 9||!running)
        {
            if (GUI.Button(new Rect(800, 200, 120, 80), "Reset"))
            {
                current_user = 0;
                for (int i = 0; i < 9; i++)
                    flag[i] = 2;
            }
        }
    }
}
