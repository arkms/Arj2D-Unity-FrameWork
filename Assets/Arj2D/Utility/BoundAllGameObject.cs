using UnityEngine;

///Gizmos dont draw correctly if father GameObject is scaled

namespace ARJ2D
{
    [ExecuteInEditMode]
    public class BoundAllGameObject : MonoBehaviour
    {
        private Bounds bounds;
        private Transform _transform;

        void Awake()
        {
            _transform = base.transform;
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(bounds.center, bounds.size);
            //only calculate when is not playing
            if (!Application.isPlaying)
                RecalculateBounds();
        }

        public Bounds WorldBounds()
        {
            Bounds b = bounds;
            b.center += _transform.position;

            Vector3 size = b.size;
            Vector3 tsize = _transform.lossyScale;
            size.x *= tsize.x;
            size.y *= tsize.y;
            size.z *= tsize.z;
            b.size = size;

            return b;
        }

        [ContextMenu("Recalculate Bounds")]
        public void RecalculateBounds()
        {
            MeshFilter this_mf = GetComponent<MeshFilter>();
            if (this_mf == null)
            {
                bounds = new Bounds(Vector3.zero, Vector3.zero);
            }
            else
            {
                bounds = this_mf.sharedMesh.bounds;
            }

            MeshFilter[] mfs = GetComponentsInChildren<MeshFilter>();
            Vector3 Min= Vector3.zero;
            Vector3 Max= Vector3.zero;
            if (mfs.Length > 0)
            {
                Min = mfs[0].sharedMesh.bounds.min +mfs[0].transform.position;
                Max = mfs[0].sharedMesh.bounds.max +mfs[0].transform.position;

                for (int i = 1; i < mfs.Length; i++)
                {
                    Vector3 child_boundsMin = mfs[i].sharedMesh.bounds.min + mfs[i].transform.position;
                    Vector3 child_boundsMax = mfs[i].sharedMesh.bounds.max + mfs[i].transform.position;

                    if (child_boundsMin.x < Min.x)
                    {
                        Min.x = child_boundsMin.x;
                    }
                    if (child_boundsMax.x > Max.x)
                    {
                        Max.x = child_boundsMax.x;
                    }
                    if (child_boundsMin.y < Min.y)
                    {
                        Min.y = child_boundsMin.y;
                    }
                    if (child_boundsMax.y > Max.y)
                    {
                        Max.y = child_boundsMax.y;
                    }
                    if (child_boundsMin.z < Min.z)
                    {
                        Min.x = child_boundsMin.z;
                    }
                    if (child_boundsMax.z > Max.z)
                    {
                        Max.x = child_boundsMax.z;
                    }
                }
            }

            bounds.SetMinMax(Min, Max);
        }
    }
}