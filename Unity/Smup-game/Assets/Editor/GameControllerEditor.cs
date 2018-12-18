using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerEditor : Editor {


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameController gameControl = (GameController)target;

        GUILayout.Label("amount of time to start spawning waves:");
        gameControl.startWaitTime = EditorGUILayout.Slider(gameControl.startWaitTime, 1, 10);

        GUILayout.Label("time inbetween spawning waves:");
        gameControl.spawnWaitTime = EditorGUILayout.Slider(gameControl.spawnWaitTime,1,10);


    }

}
