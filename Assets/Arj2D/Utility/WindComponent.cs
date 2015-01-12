using UnityEngine;
using System.Collections.Generic;

//Original from http://wiki.unity3d.com/index.php/WindComponent by GameDevGuy

public class WindComponent : MonoBehaviour
{
    // To use:
    // 1. Create an empty game object
    // 2. Add a Collider2D to the empty object as a trigger.
    // 3. Add this WindComponent to the empty object.
    // Note: Only works on game objects that have the Rigid Body 2D and Collider 2D components

    // Directional force applied to objects that enter this object's Collider 2D boundaries
    public Vector2 Force = Vector2.zero;
    // Internal list that tracks objects that enter this object's "zone"
    private List<Collider2D> objects = new List<Collider2D>();

    void FixedUpdate()
    {
        // For every object being tracked
        for (int i = 0; i < objects.Count; i++)
        {
            // Get the rigid body for the object.
            Rigidbody2D body = objects[i].attachedRigidbody;

            // Apply the force
            body.AddForce(Force);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        objects.Add(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objects.Remove(other);
    }

    public Collider2D[] GetObjectInArea()
    {
        return objects.ToArray();
    }
}