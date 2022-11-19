using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    float speed =10;

    private void Update ( )
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity =direction*speed;
        Vector3 moveAmount = velocity*Time.deltaTime;
 
        transform. Translate ( moveAmount );



        //keybord/UI move
        if ( Input. GetKey( KeyCode. H ) )
        {
            Vector3 xinput=new Vector3(-1,0,0);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
        if ( Input. GetKey ( KeyCode.K ) )
        {
            Vector3 xinput=new Vector3(1,0,0);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
        if ( Input. GetKey ( KeyCode.U) )
        {
            Vector3 xinput=new Vector3(0,0,1);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
        if ( Input. GetKey ( KeyCode.J) )
        {
            Vector3 xinput=new Vector3(0,0,-1);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
    }
}
