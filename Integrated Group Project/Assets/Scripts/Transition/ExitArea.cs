using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArea : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn_marker;    //  Location to respawn player upon exit

    [SerializeField]
    private string area;    //  Level to move player to

    //  Detects objects that enter trigger zone
    void OnTriggerEnter2D ( Collider2D collider )
    {
        //  Checks other object is player
        if ( collider.gameObject.tag == "Player" )
        {
            GameManager.EnterArea ( area, spawn_marker.transform.position );
        }
    }
}
