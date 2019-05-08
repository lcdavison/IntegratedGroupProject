using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Text coin_output;
    private Transform target;

    void Start ( )
    {
        coin_output = GameObject.Find ( "CoinText" ).GetComponent < Text > ( );
        target = coin_output.gameObject.transform;
    }

    // Update is called once per frame
    void Update ( )
    {
        transform.position = Vector3.Lerp ( transform.position, target.position, Time.deltaTime );
    }

    void OnCollisionEnter2D ( Collision2D collision )
    {
        if ( collision.gameObject.name == "Coins" )
        {
            GameManager.AddCoins ( 1 );
            coin_output.text = "Coins : " + GameManager.GetCoins ( );
            GameObject.Destroy ( this.gameObject );
        }
    }

    public void SetTarget ( Transform new_target )
    {
        target = new_target;
    }
}
