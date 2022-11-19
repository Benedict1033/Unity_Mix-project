using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float health;
    public GameObject Player;
    public float scoreToGive=10;
    public bool shot;
    public float currenTime;
    public int waitTime;

    public Transform bulletSpawnPoint;
    public GameObject bullet;
    Transform  bulletSpawned;
    Transform pistolHolder;

    private void Start ( )
    {
        Player=GameObject. Find ( "player holder" );
        pistolHolder=this. transform. GetChild ( 0 );
        bulletSpawnPoint=pistolHolder. GetChild ( 2 );
    }

    public void Update ( )
    {
        //PLAYER death stop run the code
        if ( player. death )
        {
            return;
        }



        if ( !bulletSpawnPoint )
        {
            bulletSpawnPoint=this. transform. GetChild ( 2 );
        }

        if ( health<=0 )
        {
            Die ( );
        }

        if ( currenTime==0 )
        {
            shootPlayer ( );
        }

        if ( shot&&currenTime<waitTime )
        {
            currenTime+=1*Time. deltaTime;
        }

        if ( currenTime>=waitTime )
        {
            currenTime=0;
        }

        this. transform. LookAt ( Player. transform );

        //Get distance between 2 obj
        float dis = Vector3.Distance(Player.transform.position, transform.position);

        // if dis <=4 stop move
        if ( dis<=4 )
        {
            return;
        }
        transform. Translate ( Vector3. forward*2.5f*Time. deltaTime );
    } 

    void Die ( )
    {
        Destroy ( this. gameObject );
        Player. GetComponent<player> ( ). Score+=scoreToGive;
    }

    void shootPlayer ( )
    {
        shot=true;
   
        bulletSpawned=Instantiate ( bullet. transform, bulletSpawnPoint. position, Quaternion. identity );
        bulletSpawned. rotation=this. transform. rotation;
    }
}
