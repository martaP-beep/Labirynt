using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
       DrawDefaultInspector();

        LevelGenerator levelGenerator = (LevelGenerator)target;

        if(GUILayout.Button("Stwórz labirynt"))
        {
            levelGenerator.GenerateLabirynth();
        }
    }
}
