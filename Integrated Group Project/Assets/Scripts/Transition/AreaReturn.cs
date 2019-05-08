using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaReturn : MonoBehaviour
{
    [SerializeField]
    private string area;

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            GameManager.LeaveArea ( area );
        }
    }
}
