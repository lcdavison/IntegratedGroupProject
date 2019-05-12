using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaReturn : MonoBehaviour
{
    [SerializeField]
    private string area;

    //  Detects objects that enter the trigger zone
    void OnTriggerEnter2D ( Collider2D collider )
    {
        //  Checks other object is the player
        if ( collider.gameObject.tag == "Player" )
        {
            GameManager.LeaveArea ( area );
        }
    }
}
