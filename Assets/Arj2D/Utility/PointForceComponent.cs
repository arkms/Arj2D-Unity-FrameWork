using UnityEngine;
using System.Collections.Generic;

//original from http://wiki.unity3d.com/index.php/PointForceComponent by GameDevGuy

[RequireComponent(typeof(CircleCollider2D))]
public class PointForceComponent : MonoBehaviour
{
    public bool NonLinear = true;
    public float Force = 0f;
    private float forceSqr;
    public float LinearDrag = 0f;
    public float AngularDrag = 0f;
    private float radiusSqr;
    private CircleCollider2D myCircleCollider;
    private List<Collider2D> objects = new List<Collider2D>();
    private float FLT_EPSILON = 1.19209290E-07F;

    // Use this for initialization
    void Start()
    {
        myCircleCollider = this.GetComponent<CircleCollider2D>();
        //Clamp if in editor put high value
        LinearDrag = Mathf.Clamp(LinearDrag, 0.0f, 1.0f);
        AngularDrag = Mathf.Clamp(AngularDrag, 0.0f, 1.0f);

        //pre calculated
        radiusSqr = myCircleCollider.radius * myCircleCollider.radius;
        // Calculate the force squared in-case we need it.
        forceSqr= Force * Force * ((Force < 0.0f) ? -1.0f : 1.0f);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            // Fetch the object rigid body
            Rigidbody2D body = objects[i].attachedRigidbody;

            // Calculate the force distance to the controllers current position.
            Vector2 distanceForce = transform.position - body.transform.position;

            // Fetch distance squared.
            float distanceSqr = distanceForce.x * distanceForce.x + distanceForce.y * distanceForce.y;

            // Skip if the position is outside the radius or is centered on the controller.
            if (distanceSqr > radiusSqr || distanceSqr < FLT_EPSILON)
                continue;

            // Non-Linear force?
            if (NonLinear)
            {
                // Yes, so use an approximation of the inverse-square law.
                distanceForce *= (1.0f / distanceSqr) * forceSqr;
            }
            else
            {
                // No, so normalize to the specified force (linear).
                distanceForce = Vector2.ClampMagnitude(distanceForce, Force);
            }

            // Apply the force
            body.AddForce(distanceForce);

            // Linear drag?
            if (LinearDrag > 0.0f)
            {
                // Yes, so fetch linear velocity.
                Vector2 linearVelocity = body.velocity;

                // Calculate linear velocity change.
                Vector2 linearVelocityDelta = linearVelocity * LinearDrag;

                // Set linear velocity.
                body.velocity = new Vector2(linearVelocity.x - linearVelocityDelta.x, linearVelocity.y - linearVelocityDelta.y);
            }

            // Angular drag?
            if (AngularDrag > 0.0f)
            {
                // Yes, so fetch angular velocity.
                float angularVelocity = body.angularVelocity;

                // Calculate angular velocity change.
                float angularVelocityDelta = angularVelocity * AngularDrag;

                // Set angular velocity.
                body.angularVelocity = angularVelocity - angularVelocityDelta;
            }
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

    //public functions

    public void Set_Radio(float _r)
    {
        myCircleCollider.radius = _r;
        radiusSqr = myCircleCollider.radius * myCircleCollider.radius;
    }

    public void Set_Force(float _force)
    {
        Force = _force;
        forceSqr = Force * Force * ((Force < 0.0f) ? -1.0f : 1.0f);
    }

    /// <summary>
    /// Set LinearDrag
    /// </summary>
    /// <param name="_lineardrag">min 0.0f - max 1.0f</param>
    public void Set_LinearDrag(float _lineardrag)
    {
        LinearDrag = Mathf.Clamp(_lineardrag, 0.0f, 1.0f);
    }

    /// <summary>
    /// Set Angular Drag
    /// </summary>
    /// <param name="_angulardrag">min 0.0f - max 1.0</param>
    public void Set_AngularDrag(float _angulardrag)
    {
        AngularDrag = Mathf.Clamp(_angulardrag, 0.0f, 1.0f);
    }
}