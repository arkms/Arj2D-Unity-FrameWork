using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class TransformInspector : Editor
{
    public override void OnInspectorGUI()
    {
        Transform t = (Transform)target;

        //EditorGUIUtility.LookLikeControls();
        EditorGUI.indentLevel = 0;
        Vector3 position = EditorGUILayout.Vector3Field("Position", t.localPosition);
        Vector3 positionWorld = EditorGUILayout.Vector3Field("Position World", t.position);
        Vector3 eulerAngles = EditorGUILayout.Vector3Field("Rotation", t.localEulerAngles);
        Vector3 scale = EditorGUILayout.Vector3Field("Scale", t.localScale);

        if (GUI.changed)
        {
            Undo.RecordObject(t, "Transform Change");

            if (position != t.localPosition)
                t.localPosition = FixIfNaN(position);
            else if (positionWorld != t.position)
                t.position = FixIfNaN(positionWorld);
            t.localEulerAngles = FixIfNaN(eulerAngles);
            t.localScale = FixIfNaN(scale);
        }
    }

    private Vector3 FixIfNaN(Vector3 v)
    {
        if (float.IsNaN(v.x))
        {
            v.x = 0f;
        }
        if (float.IsNaN(v.y))
        {
            v.y = 0f;
        }
        if (float.IsNaN(v.z))
        {
            v.z = 0f;
        }
        return v;
    }

}