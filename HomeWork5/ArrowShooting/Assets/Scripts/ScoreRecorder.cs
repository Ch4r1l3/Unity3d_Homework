using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class ScoreRecorder
    {
        private static ScoreRecorder _instance;
        public SceneController current { set; get; }
        private int score = 0;

        public static ScoreRecorder getInstance()
        {
            if (_instance == null)
                _instance = new ScoreRecorder();
            return _instance;
        }

        public int getScore()
        {
            return score;
        }

        public void addScore(int s)
        {
            score += s;
        }

        public void setScore(int s)
        {
            score = s;
        }
    }

}

