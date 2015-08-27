using UnityEngine;
using System.Collections;
using Arj2D;

public class scr_Character_LookAt : MonoBehaviour2D
{
    public Transform Destiny_ToLookAt;
    public float RotationSpeed = 100f;

	void Update ()
	{
        float Rotation = Mathf.Sign(AMath.Angle_Relative(transform, Destiny_ToLookAt));
        transform.Rotate(0f, 0f, Rotation * Time.deltaTime * RotationSpeed, Space.World);
	}

    void OnGUI()
    {
        GUILayout.Label("Move the 'Destiny to see' GameObject in Editor");
        GUILayout.Label("Theangle between Character and destiny is: " + (AMath.Angle_RelativeAbs(transform, Destiny_ToLookAt) * Mathf.Rad2Deg).ToString("000.0"));
        GUILayout.Label("In Background change color before play");
    }
}