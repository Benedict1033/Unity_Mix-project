using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCamera : MonoBehaviour
{
    //variable
    public Transform target;
    public float smooth = 0.3f;
    public float height=7;
    public float far=10;
    Vector3 velocity = Vector3.zero;

    //methods 
    private void Update ( )
    {
        if ( player. death )
        {
            return;
        }

        Vector3 pos= new Vector3();
        pos. x=target. position. x;
        pos. y=target. position. y+height;
        pos. z=target. position. z-far;
        transform. position=Vector3. SmoothDamp ( transform. position, pos, ref velocity, smooth );
    }

}
