using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class ResetCamera
{
    static ResetCamera ()
    {
        SceneView.duringSceneGui -= DrawEditor;
        SceneView.duringSceneGui += DrawEditor;
    }

    private static void DrawEditor (SceneView sceneView)
    {
        Rect sceneRect = sceneView.position;

        Handles.BeginGUI();
        GUILayout.BeginArea(new Rect(2, sceneRect.height - 47,
                                     sceneRect.width - 12, 19));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        Reset();

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        Handles.EndGUI();
    }

    private static void Reset()
    {
        GUIContent content = EditorGUIUtility.IconContent("SceneViewCamera");
        content.text = "Rest Camera";
        content.tooltip = "Set the camera’s to the game’s angle";
        if (!GUILayout.Button(content))
            return;

        SceneView view = SceneView.currentDrawingSceneView;
        if (view == null)
            return;

        view.rotation = Quaternion.Euler(30, 0, 0);

        view.orthographic = false;
    }
}
