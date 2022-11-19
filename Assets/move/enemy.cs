using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform targetTransform;
    public float speed =7;

    private void Update ( )
    {
        Vector3 displacementFromTarget = targetTransform .position - transform.position;
        print ( displacementFromTarget );
        Vector3 directionToTarget = displacementFromTarget.normalized;
        //print ( directionToTarget );
        Vector3 velocity = directionToTarget*speed;

        float distanceToTarget = displacementFromTarget.magnitude;

        print ( distanceToTarget );

        if ( distanceToTarget>3f )
        {
            transform. Translate ( velocity*Time. deltaTime );
        }
    }
}
