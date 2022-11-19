using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnReachedEndOfLevel;

    public float moveSpeed =7;
    public float smoothMoveTime=0.1f;
    public float turnSpeed =8;


    float angle;
    float smoothInputMagnitude;
    float smoothMOveVelocity;
    Vector3 velocity;

    Rigidbody rb;

    bool disable;

    private void Start ( )
    {
        rb=GetComponent<Rigidbody> ( );
        Guard. OnGuardasSpottedPlayer+=Disable;
    }


    private void Update ( )
    {
        Vector3 inputDirection =Vector3.zero;
        if ( !disable )
        {
            inputDirection=new Vector3 ( Input. GetAxisRaw ( "Horizontal" ), 0, Input. GetAxisRaw ( "Vertical" ) ). normalized;
        }
         
        float inputMagnitude = inputDirection.magnitude;
        smoothInputMagnitude=Mathf. SmoothDamp ( smoothInputMagnitude, inputMagnitude, ref smoothMOveVelocity, smoothMoveTime );

        float targetAngle = Mathf.Atan2 (inputDirection.x,inputDirection.z)*Mathf.Rad2Deg;
        angle=Mathf. LerpAngle ( angle, targetAngle, Time. deltaTime*turnSpeed*inputMagnitude );

        velocity=transform. forward*moveSpeed*smoothInputMagnitude;


    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other. tag=="Finish" )
        {
            Disable ( );
            if ( OnReachedEndOfLevel!=null )
            {
                OnReachedEndOfLevel ( );
            }
        }
    }

    private void Disable ( )
    {
        disable=true;
    }

    private void FixedUpdate ( )
    {
        rb. MoveRotation ( Quaternion. Euler ( Vector3. up*angle ) );
        rb. MovePosition ( rb. position+velocity*Time. deltaTime );
    }

    private void OnDestroy ( )
    {
        Guard. OnGuardasSpottedPlayer-=Disable;
    }

}
