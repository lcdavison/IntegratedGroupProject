using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerAnimator : MonoBehaviour
{
    public enum AnimationState
    {
        FORWARD = 0x0,
        BACKWARD = 0x4,
        LEFT = 0x8,
        RIGHT = 0xC,
        IDLE = 0x10
    };

    [SerializeField]
    private SpriteAtlas sprite_atlas;   //  Texture that holds each sprite image

    [SerializeField]
    private SpriteRenderer sprite_r;

    [SerializeField]
    private Sprite [ ] sprites;     //  The player sprites

    private AnimationState current_state  = AnimationState.FORWARD;
    private AnimationState previous_state = AnimationState.FORWARD;

    private byte animation_frame = 0;
    private byte anim_state_start = 0;

    private float last_time;    //  Last time sprite was updated

    private bool sprite_update = false;

    //  Runs before the scene starts
    void Awake ( )
    {
        //  Set default sprite
        if ( GameManager.player_sprite != null )
            sprite_atlas = GameManager.player_sprite;

        //  Create temporary sprite array
        Sprite [ ] t_sprites = new Sprite [ sprite_atlas.spriteCount ];
        sprites = new Sprite [ sprite_atlas.spriteCount ];

        //  Get sprites from sprite atlas
        sprite_atlas.GetSprites ( t_sprites );

        //  Seperate and sort sprites based on preceding letter
        foreach ( Sprite sprite in t_sprites )
        {
            //  Forward animation start index
            int start_index = 0;

            switch ( sprite.name [ 0 ] )
            {
                case 'B':   //  Backward animation start index
                start_index = 4;
                break;
                case 'L':   //  Left animation start index
                start_index = 8;
                break;
                case 'R':   //  Right animation start index
                start_index = 12;
                break;
            }

            //  ASCII Value - 48 = Numerical Value : Subtract 49 to prevent skipping indices
            int index = start_index + ( Convert.ToInt16 ( sprite.name [ 1 ] ) - 49 );

            //  Store sprite
            sprites [ index ] = sprite;
        }

        //  Set first sprite to render
        sprite_r.sprite = sprites [ 0 ];

        //  Set last update time
        last_time = Time.time;
    }

    //  Update is called once per frame
    void Update ( )
    {
        sprite_update = false;
        float current_time = Time.time;

        //  Get IDLE sprite index
        byte frame = (byte) ( previous_state );

        //  Check the state isn't IDLE
        if ( current_state != AnimationState.IDLE )
        {
            //  Check if 0.25 ms have passed
            if ( current_time - last_time >= ( 1.0f / 4.0f ) )
            {
                int anim_start = (int) current_state;   //  Animation starting frame

                //  Calculate next frame to display
                frame = (byte) ( Convert.ToByte ( anim_start ) + ( animation_frame++ & 3 ) );

                //  Set previous update time
                last_time = current_time;
                sprite_update = true;
            }
        }
        else
        {
            //  Update if previous state wasn't IDLE
            if ( previous_state != current_state )
                sprite_update = true;
        }

        //  Set the sprite to render
        if ( sprite_update )
            sprite_r.sprite = sprites [ frame ];
    }

    //  Sets the state for the animation controller
    public void SetAnimationState ( AnimationState new_state )
    {
        //  Check that the states are different
        if ( new_state != current_state )
        {
            previous_state = current_state;
            current_state = new_state;
        }
    }
}
