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

    private byte button_mask;   //  Contains the state of each button

    public bool movement_enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        //  Spawn player at a spawn position if one exists
        if ( GameManager.spawn_positions.Count > 0 && GameManager.leaving )
        {
            //  Retrieve position
            transform.position = GameManager.spawn_positions.Pop ( );
            GameManager.leaving = false;
        }

        //  Get rigidbody and animation controller
        rigidbody = gameObject.GetComponent < Rigidbody2D > ( );
        animator = gameObject.GetComponent < PlayerAnimator > ( );
    }

    //  Update is called once per frame
    void Update ( )
    {
        if ( movement_enabled )
        {
            //  Check if any button is currently active
            if ( ( button_mask & (byte) ButtonState.LEFT ) > 0 )
            {
                //  Set state and move left
                animator.SetAnimationState ( PlayerAnimator.AnimationState.LEFT );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( -1.0f, 0.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else if ( ( button_mask & (byte) ButtonState.RIGHT ) > 0 )
            {
                //  Set state and move right
                animator.SetAnimationState ( PlayerAnimator.AnimationState.RIGHT );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( 1.0f, 0.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else if ( ( button_mask & (byte) ButtonState.UP ) > 0 )
            {
                //  Set state and move up
                animator.SetAnimationState ( PlayerAnimator.AnimationState.FORWARD );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( 0.0f, 1.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else if ( ( button_mask & (byte) ButtonState.DOWN ) > 0 )
            {
                //  Set state and move down
                animator.SetAnimationState ( PlayerAnimator.AnimationState.BACKWARD );
                rigidbody.MovePosition ( transform.position + ( new Vector3 ( 0.0f, -1.0f  ) * movement_speed * Time.deltaTime ) );
            }
            else
            {
                //  Set state to idle
                animator.SetAnimationState ( PlayerAnimator.AnimationState.IDLE );
            }
        }
    }

    //  Activate left button
    public void OnMoveLeftPressed ( )
    {
        button_mask |= (byte) ButtonState.LEFT;
    }

    //  Deactivate left button
    public void OnMoveLeftReleased ( )
    {
        button_mask ^= (byte) ButtonState.LEFT;
    }

    //  Activate right button
    public void OnMoveRightPressed ( )
    {
        button_mask |= (byte) ButtonState.RIGHT;
    }

    //  Deactivate right button
    public void OnMoveRightReleased ( )
    {
        button_mask ^= (byte) ButtonState.RIGHT;
    }

    //  Activate up button
    public void OnMoveUpPressed ( )
    {
        button_mask |= (byte) ButtonState.UP;
    }

    //  Deactivate up button
    public void OnMoveUpReleased ( )
    {
        button_mask ^= (byte) ButtonState.UP;
    }

    //  Activate down button
    public void OnMoveDownPressed ( )
    {
        button_mask |= (byte) ButtonState.DOWN;
    }

    //  Deactivate down button
    public void OnMoveDownReleased ( )
    {
        button_mask ^= (byte) ButtonState.DOWN;
    }

    //  Reset the controller
    public void Reset ( )
    {
        button_mask = 0;
        animator.SetAnimationState ( PlayerAnimator.AnimationState.IDLE );
    }
}
