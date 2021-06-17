using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
    }

    public void FinishJumping()
    {
        UpdateAnimator("IsJumping", false);
    }

}
