using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normalboy_animation : MonoBehaviour{
    private Normalboy_Master normalboyMaster; 
    private Animator myAnimator;
    private float forwardAmount;

    void OnEnable() 
    {
        SetinitialRefrence();
        normalboyMaster.EventNormalboyReachedTarget += SetAnimationToIdle;
        normalboyMaster.EventNormalboyAttack += SetAnimationToAttack;
        normalboyMaster.EventNormalboyWander += SetAnimationToWalk;
        normalboyMaster.EventNormalboyFlee += SetAnimationToRun;
    }
    void OnDisable() 
    {
        normalboyMaster.EventNormalboyReachedTarget -= SetAnimationToIdle;
        normalboyMaster.EventNormalboyAttack -= SetAnimationToAttack;
        normalboyMaster.EventNormalboyWander -= SetAnimationToWalk;
        normalboyMaster.EventNormalboyFlee -= SetAnimationToRun;
    }

    void SetinitialRefrence()
    {
        normalboyMaster = GetComponent<Normalboy_Master>();
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
               myAnimator.SetFloat("Forward", 0);
               myAnimator.SetFloat("Turn", 0);
            }
        }
    }

    void SetAnimationToRun()
    {
        if(myAnimator != null)
        {
            if(myAnimator.enabled)
            {
               myAnimator.SetFloat("Forward", forwardAmount, 0.3f, Time.deltaTime);
               forwardAmount = Vector3.forward.z;
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
                myAnimator.SetFloat("Forward", forwardAmount, 0.2f, Time.deltaTime);
                forwardAmount = Vector3.forward.z;
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
