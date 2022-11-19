using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //variables

    public float movespeed;
    public GameObject playerObj;

    public float waitTime;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    Transform  bulletSpawned;

    public float Score=0;

    public float maxhealth;
    public float health;
    public static bool death =false;

    private void Start ( )
    {
        health=maxhealth;
    }


    private void Update ( )
    {
        //Player facing mouse
        Plane playerPlane = new Plane(Vector3.up,transform.position);
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDis=0.0f;

        if ( playerPlane. Raycast ( ray, out hitDis ) )
        {
            Vector3 targetPonit =ray.GetPoint(hitDis);
            Quaternion targetRotation =Quaternion. LookRotation ( targetPonit-transform. position );
            targetRotation. x=0;
            targetRotation. z=0;
            playerObj. transform. rotation=Quaternion. Slerp ( playerObj. transform. rotation, targetRotation, 7f*Time. deltaTime );

            //interest moving (follow the mouse position)
            // transform. rotation=Quaternion. Slerp ( transform. rotation, targetRotation, 7f*Time. deltaTime );
        }


        //player move
        if ( Input. GetKey ( KeyCode. W ) )
        {
            transform. Translate ( Vector3. forward*movespeed*Time. deltaTime );
        }
        if ( Input. GetKey ( KeyCode. A ) )
        {
            transform. Translate ( Vector3. left*movespeed*Time. deltaTime );
        }
        if ( Input. GetKey ( KeyCode. S ) )
        {
            transform. Translate ( Vector3. back*movespeed*Time. deltaTime );
        }
        if ( Input. GetKey ( KeyCode. D ) )
        {
            transform. Translate ( Vector3. right*movespeed*Time. deltaTime );
        }


        //shooting 
        if ( Input. GetMouseButtonDown ( 0 ) )
        {
            shoot ( );
        }

        //check die
        if ( health<=0 )
        {
            Die ( );
        }
    }


    void shoot ( )
    {
        bulletSpawned=Instantiate ( bullet. transform, bulletSpawnPoint. transform. position, Quaternion. identity );
        bulletSpawned. rotation=bulletSpawnPoint. transform. rotation;
    }

    void Die ( )
    {
        death=true;
        Time. timeScale=0; 
        Destroy ( this. gameObject );
    }
}
