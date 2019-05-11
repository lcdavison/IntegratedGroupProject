using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Text coin_output;
    private Transform target;

    //  Start is called before the first frame update
    void Start ( )
    {
        //  Get the text object for coin text
        coin_output = GameObject.Find ( "CoinText" ).GetComponent < Text > ( );

        //  Set text object as the coins target
        target = coin_output.gameObject.transform;
    }

    // Update is called once per frame
    void Update ( )
    {
        //  Gradually move the coin towards the target
        transform.position = Vector3.Lerp ( transform.position, target.position, Time.deltaTime );
    }

    //  Detects objects that collide with the coin
    void OnCollisionEnter2D ( Collision2D collision )
    {
        //  Check the other object is the coin text
        if ( collision.gameObject.name == "Coins" )
        {
            GameManager.AddCoins ( 1 );

            //  Update text and destroy coin object
            coin_output.text = "Coins : " + GameManager.GetCoins ( );
            GameObject.Destroy ( this.gameObject );
        }
    }

    //  Sets the target for the coin to move towards
    public void SetTarget ( Transform new_target )
    {
        target = new_target;
    }
}
