using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class RayTest3 : MonoBehaviour
{
    private void Start ( )
    {
        Physics2D. queriesStartInColliders=false;
    }

    private void Update ( )
    {
        RaycastHit2D hitInfo =Physics2D.Raycast(transform.position,transform.right,100);
        if ( hitInfo. collider!=null )
        {
            Debug. DrawLine ( transform. position, hitInfo. point, Color. red );
            Debug.Log(hitInfo.point.x);
        }
        else
        {
            Debug. DrawLine ( transform. position, transform. position+transform. right*100, Color. green );
        }
    }
}
