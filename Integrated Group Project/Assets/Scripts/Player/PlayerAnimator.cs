﻿using System;
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
        RIGHT = 0xC
    };

    [SerializeField]
    private SpriteAtlas sprite_atlas;

    [SerializeField]
    private SpriteRenderer sprite_r;

    [SerializeField]
    private Sprite [ ] sprites;

    private AnimationState animation_state  = AnimationState.FORWARD;
    private byte animation_frame = 0;
    private byte anim_state_start = 0;
    private float last_time;

    // Start is called before the first frame update
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

            int index = start_index + ( Convert.ToInt16 ( sprite.name [ 1 ] ) - 49 );

            sprites [ index ] = sprite;
        }

        sprite_r.sprite = sprites [ 0 ];

        last_time = Time.time;
    }

    // Update is called once per frame
    void Update ( )
    {
        float current_time = Time.time;

        if ( current_time - last_time >= ( 1.0f / 4.0f ) )
        {
            int anim_start = (int) animation_state;
            Debug.Log ( "Animation Start Frame : " + anim_start + " STATE : " + animation_state );

            animation_frame = ( byte ) ( ( ++animation_frame & 3 ) + Convert.ToByte ( anim_start ) );
            sprite_r.sprite = sprites [ animation_frame ];
            last_time = current_time;
        }
    }

    public void SetAnimationState ( AnimationState new_state )
    {
        animation_state = new_state;
    }
}
