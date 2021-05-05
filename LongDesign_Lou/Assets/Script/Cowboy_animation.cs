using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cowboy_animation : MonoBehaviour{
    private Cowboy_master cowboyMaster; 
    private Animator myAnimator;
    float forwardAmount;


    // Start is called before the first frame update
    void OnEnable() 
    {

        SetinitialRefrence();
        cowboyMaster.EventCowboyReachedTarget += SetAnimationToIdle;
        cowboyMaster.EventCowboyAttack += SetAnimationToAttack;
        cowboyMaster.EventCowboyWander += SetAnimationToWalk;
        cowboyMaster.EventCowboyChase += SetAnimationToRun;
    }

    // Update is called once per frame
    void OnDisable() 
    {
        cowboyMaster.EventCowboyReachedTarget -= SetAnimationToIdle;
        cowboyMaster.EventCowboyAttack -= SetAnimationToAttack;
        cowboyMaster.EventCowboyWander -= SetAnimationToWalk;
        cowboyMaster.EventCowboyChase -= SetAnimationToRun;
    }

    void SetinitialRefrence()
    {
        cowboyMaster = GetComponent<Cowboy_master>();
        if(GetComponent<Animator>() != null)
        {
            myAnimator = GetComponent<Animator>();
        }
    }

    void SetAnimationToIdle()
    {
        if(myAnimator != null)
        {
            if(myAnimator.enabled)
            {
               myAnimator.SetBool("IsWalking",false);
            }
        }
    }

    void SetAnimationToRun()
    {
        if(myAnimator != null)
        {
            if(myAnimator.enabled)
            {
               myAnimator.SetBool("IsPursuing",true);
            }
        }
    }

    void SetAnimationToAttack()
    {
        if(myAnimator != null)
        {
            if(myAnimator.enabled)
            {
                myAnimator.SetTrigger("Attack");
            }
        }
    }

     void SetAnimationToWalk()
    {
        if(myAnimator != null)
        {
            if(myAnimator.enabled)
            {
                myAnimator.SetBool("IsWandering",true);
            }
        }
    }

    void DisableAnimator()
    {
        if(myAnimator != null)
        {
            myAnimator.enabled = false;
        }
    }
}
