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
    private SpriteAtlas sprite_atlas;

    [SerializeField]
    private SpriteRenderer sprite_r;

    [SerializeField]
    private Sprite [ ] sprites;

    private AnimationState current_state  = AnimationState.FORWARD;
    private AnimationState previous_state = AnimationState.FORWARD;
    private byte animation_frame = 0;
    private byte anim_state_start = 0;
    private float last_time;
    private bool sprite_update = false;

    void Awake ( )
    {
        Sprite [ ] t_sprites = new Sprite [ sprite_atlas.spriteCount ];
        sprites = new Sprite [ sprite_atlas.spriteCount ];

        sprite_atlas.GetSprites ( t_sprites );

        foreach ( Sprite sprite in t_sprites )
        {
            int start_index = 0;

            switch ( sprite.name [ 0 ] )
            {
                case 'B':
                start_index = 4;
                break;
                case 'L':
                start_index = 8;
                break;
                case 'R':
                start_index = 12;
                break;
            }

            //  ASCII Value - 48 = Numerical Value : Subtract 49 to prevent skipping indices
            int index = start_index + ( Convert.ToInt16 ( sprite.name [ 1 ] ) - 49 );

            sprites [ index ] = sprite;
        }

        sprite_r.sprite = sprites [ 0 ];

        last_time = Time.time;
    }

    // Update is called once per frame
    void Update ( )
    {
        sprite_update = false;
        float current_time = Time.time;
        byte frame = (byte)(previous_state);

        if ( current_state != AnimationState.IDLE )
        {
            if ( current_time - last_time >= ( 1.0f / 4.0f ) )
            {
                int anim_start = (int) current_state;   //  Animation starting frame

                frame = ( byte ) ( Convert.ToByte ( anim_start ) + ( animation_frame++ & 3 ) );

                last_time = current_time;
                sprite_update = true;
            }
        }
        else
        {
            if ( previous_state != current_state )
                sprite_update = true;
        }

        if ( sprite_update )
            sprite_r.sprite = sprites [ frame ];
    }

    public void SetAnimationState ( AnimationState new_state )
    {
        if ( new_state != current_state )
        {
            previous_state = current_state;
            current_state = new_state;
        }
    }
}
