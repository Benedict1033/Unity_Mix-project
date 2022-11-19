using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public static event System.Action OnGuardasSpottedPlayer;

    public Transform pathHolder;
    public  float speed =5;
    public  float waitTime =0.3f;

    public  float turnSpeed =50;

    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
    float viewAngle;

    Transform Player;
    Color originalSpotLightColour;

    float playerVisibleTimer;
    public float timeToSpotPlayer=0.5f;

    private void Start ( )
    {
        Player=GameObject. FindGameObjectWithTag ( "Player" ). transform;
        viewAngle=spotlight. spotAngle;
        originalSpotLightColour=spotlight. color;

        Vector3[]waypoints = new Vector3[pathHolder.childCount];
        for ( int i = 0; i<waypoints. Length; i++ )
        {
            waypoints [ i ]=pathHolder. GetChild ( i ). position;
            waypoints [ i ]=new Vector3 ( waypoints [ i ]. x, transform. position. y, waypoints [ i ]. z );
        }
        StartCoroutine ( FollowPath ( waypoints ) );
    }

    private void Update ( )
    {
        if ( CanSeePlayer ( ) )
        {
            playerVisibleTimer+=Time. deltaTime;
        }
        else
        {
            playerVisibleTimer-=Time. deltaTime;
        }
        playerVisibleTimer=Mathf. Clamp ( playerVisibleTimer, 0, timeToSpotPlayer );
        spotlight. color=Color. Lerp ( originalSpotLightColour, Color. red, playerVisibleTimer/timeToSpotPlayer );
        if ( playerVisibleTimer>=timeToSpotPlayer )
        {
            if ( OnGuardasSpottedPlayer!=null )
            {
                OnGuardasSpottedPlayer ( );
            }
        }
    }

    bool CanSeePlayer ( )
    {
        if ( Vector3. Distance ( transform. position, Player. position )<viewDistance )
        {
            Vector3 dirToPlayer = (Player.position-transform.position).normalized;
            float angleBetweenGuardAndPlayer =Vector3.Angle(transform.forward,dirToPlayer);
            if ( angleBetweenGuardAndPlayer<viewAngle/2 )
            {
                if ( !Physics. Linecast ( transform. position, Player. position, viewMask ) )
                {
                    return true;
                }
            }
        }
       
            return false;
      
    }

    IEnumerator FollowPath ( Vector3 [ ] waypoints )
    {
        transform. position=waypoints [ 0 ];
        int targetWayPointIndex=1;
        Vector3 targetWayPoint = waypoints [targetWayPointIndex];
        transform. LookAt ( targetWayPoint );

        while ( true )
        {
            transform. position=Vector3. MoveTowards ( transform. position, targetWayPoint, speed*Time. deltaTime );
            if ( transform. position==targetWayPoint )
            {
                targetWayPointIndex=( targetWayPointIndex+1 )%waypoints. Length;
                targetWayPoint=waypoints [ targetWayPointIndex ];
                yield return new WaitForSeconds ( waitTime );
                yield return StartCoroutine ( TurnToFace ( targetWayPoint ) );
            }
            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget )
    {
        Vector3 dirToLookTarget = (lookTarget-transform.position).normalized;
        float targetAngle = 90- Mathf.Atan2 (dirToLookTarget.z,dirToLookTarget.x)*Mathf.Rad2Deg;

        while (Mathf.Abs( Mathf. DeltaAngle ( transform. eulerAngles. y, targetAngle ))>0.05f )
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetAngle,turnSpeed*Time.deltaTime);
            transform. eulerAngles=Vector3. up*angle;
            yield return null;
        }
    }

    private void OnDrawGizmos ( )
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach ( Transform waypoint in pathHolder )
        {
            Gizmos. DrawSphere ( waypoint. position, .3f );
            Gizmos. DrawLine ( previousPosition, waypoint. position );
            previousPosition=waypoint. position;
        }
        Gizmos. DrawLine ( previousPosition, startPosition );

        Gizmos. color=Color. red;
        Gizmos. DrawLine ( transform. position, transform. forward*viewDistance );
    }
}
