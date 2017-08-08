using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WorldController))]
public class TileMapInspector : Editor {

	public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if(GUILayout.Button("Regenerate")) {
            WorldController worldController = (WorldController)target;
            worldController.BuildMesh();
        }
    }
}
