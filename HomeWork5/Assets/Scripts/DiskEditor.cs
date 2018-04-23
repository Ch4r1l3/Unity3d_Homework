using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UFO
{
    [CustomEditor(typeof(Disk))]
    public class UFOEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Disk ufo = target as Disk;
            ufo.level = (Disk.DiskLevel)EditorGUILayout.EnumPopup("Level",ufo.level);
            ufo.score = EditorGUILayout.IntSlider("Score", ufo.score,0,100);
            ProgressBar(ufo.score/100.0f, "Score");
            ufo.speed = EditorGUILayout.IntSlider("Speed", ufo.speed, 0, 100);
            ProgressBar(ufo.speed / 100.0f, "Speed");
        }

        private void ProgressBar(float value, string label)
        {
            Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rect, value, label);
            EditorGUILayout.Space();
        }
    }

}
