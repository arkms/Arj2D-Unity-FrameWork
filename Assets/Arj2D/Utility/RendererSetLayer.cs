using UnityEngine;
using System.Collections;

namespace Arj2D
{
    [RequireComponent(typeof(MeshRenderer))]
    public class RendererSetLayer : MonoBehaviour
    {
        public int orderLayer;
        public int IDLayerName;
        public string LayerName= "Default"; //NEVER CHANGE THIS!!!!


        void Awake()
        {
            Renderer paint = GetComponent<Renderer>();
            paint.sortingLayerID = SortingLayer.NameToID(LayerName);
            paint.sortingOrder = orderLayer;
        }
    }
}