using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest2 : MonoBehaviour
{
    public Transform objectToPlace;
    public Camera gameCamera;

    private void Update ( )
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo ) )
        {
            objectToPlace. position=hitInfo. point;
            objectToPlace. rotation=Quaternion. FromToRotation ( Vector3. up, hitInfo. normal );
        }
    }
}
