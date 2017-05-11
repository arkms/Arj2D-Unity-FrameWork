using UnityEngine;
using Arj2D;

public class scr_CharacterLookAt2D : MonoBehaviour
{
    public Transform _Target;
    public float Offset;


    void Update()
    {
        transform.LookAt2D(_Target, Offset);
    }
}