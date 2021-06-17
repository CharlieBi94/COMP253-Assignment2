using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    Animator anim;
    PlayerMovement player;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void UpdateAnimator(string parameter, bool state)
    {
        anim.SetBool(parameter, state);
    }
    
    public void FinishAttacking()
    {
        UpdateAnimator("IsAttacking", false);
        player.isAttacking = false;
        rbody.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    }

    public void FinishJumping()
    {
        UpdateAnimator("IsJumping", false);
        player.isGrounded = true;

    }

}
