﻿using UnityEngine;
using System.Collections;

/*
Original from: http://wiki.unity3d.com/index.php/DontGoThroughThings
 * Adapt for 2D by: ARKMS for ARJ2D
*/

namespace Arj2D
{
    public class DontGoThroughThings : MonoBehaviour
    {
        public LayerMask layerMask; //make sure we aren't in this layer 
        public float skinWidth = 0.1f; //probably doesn't need to be changed 

        private float minimumExtent;
        private float partialExtent;
        private float sqrMinimumExtent;
        private Vector2 previousPosition;
        private Rigidbody2D myRigidbody;
        private RaycastHit2D hitInfo;


        //initialize values 
        void Awake()
        {
            myRigidbody = this.GetComponent<Rigidbody2D>();
            previousPosition = myRigidbody.position;
            minimumExtent = Mathf.Min(Mathf.Min(GetComponent<Collider>().bounds.extents.x, GetComponent<Collider>().bounds.extents.y), GetComponent<Collider>().bounds.extents.z);
            partialExtent = minimumExtent * (1.0f - skinWidth);
            sqrMinimumExtent = minimumExtent * minimumExtent;
        }

        void FixedUpdate()
        {
            //have we moved more than our minimum extent? 
            Vector2 movementThisStep = myRigidbody.position - previousPosition;
            float movementSqrMagnitude = movementThisStep.sqrMagnitude;

            if (movementSqrMagnitude > sqrMinimumExtent)
            {
                float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
                hitInfo = Physics2D.Raycast(previousPosition, movementThisStep, movementMagnitude, layerMask.value);

                //check for obstructions we might have missed 
                if (hitInfo)
                    myRigidbody.position = hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;
            }

            previousPosition = myRigidbody.position;
        }
    }
}
