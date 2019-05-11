using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    private Text coin_text;

    private int last_value = -1;

    // Update is called once per frame
    void Update ( )
    {
        int coins = GameManager.GetCoins ( );

        //  Update text if coins value has changed
        if ( coins != last_value )
        {
            coin_text.text = "Coins : " + coins;
            last_value = coins;
        }
    }
}
