using UnityEngine;
using System.Collections;
using Arj2D;

public class Use_Encryptation : MonoBehaviour
{
    public int SomeValue = 10;
    private BlowFish b = new BlowFish("MyPassword");

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPreferX.SetInt(b, "Key_SomeValue", SomeValue);
            Debug.Log("Saved");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(PlayerPreferX.GetInt(b, "Key_SomeValue", -1));
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
    }
}