using UnityEngine;
using System.Collections;
using Arj2D;

public class Use_Encryptation : MonoBehaviour
{
    //NOTE: --------------------------------------------
    //Go to blowfish.cs at the top and change 
    //const string BlowFishPassword;


    public int SomeValue = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPreferX.SetInt("Key_SomeValue", SomeValue);
            Debug.Log("Saved");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(PlayerPreferX.GetInt("Key_SomeValue", -1));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Save reset");
        }
    }



    void OnGUI()
    {
        GUILayout.Label("Press 'S' to sava Value, 'L' for load and 'R' for delete key");
        GUILayout.Label("Scale the background and see autotiled in action");
    }
}