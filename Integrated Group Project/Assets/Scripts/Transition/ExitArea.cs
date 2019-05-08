using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArea : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn_marker;

    [SerializeField]
    private string area;

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            GameManager.EnterArea ( area, spawn_marker.transform.position );
        }
    }
}
