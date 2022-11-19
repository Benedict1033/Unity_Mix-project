using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. UI;

public class TimeGame : MonoBehaviour
{
    float roundStartTime;
    int waitTime;
    public float playerWaitTime;
    public bool GameStarted;

    public Text ans;
    public Text my;
    public Text miss;

    public float error;

    private void Start ( )
    {
        SetNewRandomTime ( );

    }

    public void yes ( )
    {
        InputRecive ( );
    }

    public void replay ( )
    {
        SetNewRandomTime ( );
        my. text="ans";
        miss. text="miss";

    }

    private void Update ( )
    {

    }

    void InputRecive ( )
    {
        GameStarted=false;
        playerWaitTime = Time.time - roundStartTime;
        error =Mathf.Abs(waitTime-playerWaitTime);

        my. text="my"+playerWaitTime;
        miss. text="miss"+error;
        //print ("result" +GenerateMessage(error) );

        print ( GenerateMessage(error) );
    }

    void SetNewRandomTime ( )
    {
        waitTime=Random. Range ( 5, 21 );
        roundStartTime=Time. time;
        GameStarted=true;

        ans. text="ans"+waitTime;
 
    }

    string GenerateMessage ( float error )
    {
        string message= "";

        if ( error<=.15f )
        {
            message="nice";
        }
        else if ( error<=1.75f )
        {
            message="worse";
        }
        else if ( error<=10f )
        {
            message="die";
        }

        return message;
    }
}
