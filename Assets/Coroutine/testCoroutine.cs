using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCoroutine : MonoBehaviour
{
    IEnumerator currentMoveCoroutine;
    public Transform [] path;

    private void Start ( )
    {
        string [] messages = { "welcome","to","this","amazing","game"};
        StartCoroutine ( Messages (messages,0.5f ) );
        StartCoroutine ( FollowPath ( ) );
    }

    private void Update ( )
    {
        

        if ( Input. GetKeyDown ( KeyCode. Space ) )
        {
            if ( currentMoveCoroutine!=null )
            {
                StopCoroutine ( currentMoveCoroutine );
            }

            currentMoveCoroutine=Move ( Random. onUnitSphere*5, 8 );
            StartCoroutine (currentMoveCoroutine);
        }
    }


    //follow path
    IEnumerator FollowPath ( )
    {
        foreach(Transform waypoint in path )
        {
            yield return StartCoroutine ( Move ( waypoint. position, 8 ) );
        }
        StartCoroutine ( FollowPath ( ) );
    }

    IEnumerator Move(Vector3 destination, float speed )
    {
        while(transform.position !=destination )
        {
            transform. position=Vector3. MoveTowards ( transform. position, destination, speed*Time. deltaTime );
            yield return null;
        }
    }

    IEnumerator Messages ( string [ ] messages, float delay )
    {

        foreach ( string msg in messages )
        {
            print ( msg);
            yield return new WaitForSeconds ( delay );
        }
    }
}
