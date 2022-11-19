using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    public float damage;

    private void Update ( )
    {
        transform. Translate ( Vector3. forward*Time. deltaTime*speed );
        maxDistance+=1*Time. deltaTime;

        if ( maxDistance>=5 )
        {
            Destroy ( this. gameObject );
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other. tag=="Enemy" )
        {
            other. gameObject.GetComponent<enemy2>().health-=damage;
            Destroy ( this. gameObject );
        }

        if ( other. tag=="Player" )
        {
            other. gameObject. GetComponent<player> ( ). health-=damage;
            Destroy ( this. gameObject );
        }
    }
}
