using UnityEngine;
using UnityEditor;
using Arj2D;
using System;
using UnityEditorInternal;
using System.Reflection;

[CustomEditor(typeof(RendererSetLayer))]
[CanEditMultipleObjects]
public class Inpect_RenderSetLayer : Editor
{
    string[] LayersNames;

    void OnEnable()
    {
        if (LayersNames == null)
        {
            LayersNames = GetSortingLayerNames();

            //We Search last picked by name, because if the order change, the ID is not going to be the same
            RendererSetLayer miTarget = (RendererSetLayer)target;
            bool StillExist = false;
            for(int i=LayersNames.Length; i-- != 0;)
            {
                if(LayersNames[i] == miTarget.LayerName)
                {
                    miTarget.IDLayerName = i;
                    StillExist = true;
                    break;
                }
            }

            if(!StillExist)
            {
                //If the code enter here, the LayerName was deleted, so we return to Default
                miTarget.LayerName = "Default";
                for (int i = LayersNames.Length; i-- != 0; )
                {
                    if (LayersNames[i] == "Default")
                    {
                        miTarget.IDLayerName = i;
                        break;
                    }
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        RendererSetLayer miTarget = (RendererSetLayer)target;
        int newID = EditorGUILayout.Popup("SortingOrder: ", miTarget.IDLayerName, LayersNames);
        if (newID != miTarget.IDLayerName)//save changes
        {
            miTarget.IDLayerName = newID;
            miTarget.LayerName = LayersNames[newID];
        }
        miTarget.orderLayer = EditorGUILayout.IntField("Order Layer", miTarget.orderLayer);
    }

    string[] GetSortingLayerNames()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        return (string[])sortingLayersProperty.GetValue(null, new object[0]);
    }
}