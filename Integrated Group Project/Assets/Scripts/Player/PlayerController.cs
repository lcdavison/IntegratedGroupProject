using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum ButtonState
    {
        LEFT = 0x1,
        RIGHT = 0x2,
        UP = 0x4,
        DOWN = 0x8
    }

    [SerializeField]
    private float movement_speed;
    private Rigidbody2D rigidbody;
    private PlayerAnimator animator;

    private byte button_mask;

    public bool movement_enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<PlayerAnimator>();
    }

    void Update ( )
    {
        if ( movement_enabled )
        {
            if ( ( button_mask & (byte) ButtonState.LEFT ) > 0 )
            {
                animator.SetAnimationState ( PlayerAnimator.AnimationState.LEFT );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( -1.0f, 0.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else if ( ( button_mask & (byte) ButtonState.RIGHT ) > 0 )
            {
                animator.SetAnimationState ( PlayerAnimator.AnimationState.RIGHT );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( 1.0f, 0.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else if ( ( button_mask & (byte) ButtonState.UP ) > 0 )
            {
                animator.SetAnimationState ( PlayerAnimator.AnimationState.FORWARD );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( 0.0f, 1.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else if ( ( button_mask & (byte) ButtonState.DOWN ) > 0 )
            {
                animator.SetAnimationState ( PlayerAnimator.AnimationState.BACKWARD );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( 0.0f, -1.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else
            {
                animator.SetAnimationState ( PlayerAnimator.AnimationState.IDLE );
            }
        }
    }

    //  Add a joypad to correspond to these functions
    public void OnMoveLeftPressed ( )
    {
        button_mask |= (byte) ButtonState.LEFT;
    }

    public void OnMoveLeftReleased ( )
    {
        button_mask ^= (byte) ButtonState.LEFT;
    }

    public void OnMoveRightPressed ( )
    {
        button_mask |= (byte) ButtonState.RIGHT;
    }

    public void OnMoveRightReleased ( )
    {
        button_mask ^= (byte) ButtonState.RIGHT;
    }

    public void OnMoveUpPressed ( )
    {
        button_mask |= (byte) ButtonState.UP;
    }

    public void OnMoveUpReleased ( )
    {
        button_mask ^= (byte) ButtonState.UP;
    }

    public void OnMoveDownPressed ( )
    {
        button_mask |= (byte) ButtonState.DOWN;
    }

    public void OnMoveDownReleased ( )
    {
        button_mask ^= (byte) ButtonState.DOWN;
    }

    public void Reset ( )
    {
        button_mask = 0;
        animator.SetAnimationState ( PlayerAnimator.AnimationState.IDLE );
    }
}
