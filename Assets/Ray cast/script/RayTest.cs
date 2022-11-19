using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public LayerMask mask;

    private void Update ( )
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hitInfo;

        //raycast 
        if(Physics.Raycast(ray, out hitInfo, 100, mask ) )
        {
            Debug. DrawLine ( ray. origin, hitInfo. point, Color. red );

            //transform.localScale=hitInfo. collider. gameObject. transform.localScale*2;

            hitInfo. transform. localScale=new Vector3 ( 2, 2, 2 );

            Destroy ( hitInfo. transform. gameObject );
        }
        else
        {
            Debug. DrawLine ( ray. origin, ray. origin+ray. direction*100, Color. green );
        }
    }
}
