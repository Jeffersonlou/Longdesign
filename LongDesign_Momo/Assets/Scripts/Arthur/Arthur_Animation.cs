using UnityEngine;

public class Arthur_Animation : MonoBehaviour{
    private Arthur_Master _arthurMaster; 
    private Animator _myAnimator;
    private float _forwardAmount;
    private static readonly int Forward = Animator.StringToHash("Forward");
    private static readonly int Attack = Animator.StringToHash("Attack");

    void OnEnable() 
    {
        SetinitialRefrence();
        _arthurMaster.EventArthurReachedTarget += SetAnimationToIdle;
        _arthurMaster.EventArthurAttack += SetAnimationToAttack;
        _arthurMaster.EventArthurWander += SetAnimationToWalk;
    }
    void OnDisable() 
    {
        _arthurMaster.EventArthurReachedTarget -= SetAnimationToIdle;
        _arthurMaster.EventArthurAttack -= SetAnimationToAttack;
        _arthurMaster.EventArthurWander -= SetAnimationToWalk;
    }

    void SetinitialRefrence()
    {
        _arthurMaster = GetComponent<Arthur_Master>();
        if(GetComponent<Animator>() != null)
        {
            _myAnimator = GetComponent<Animator>();
        }
    }

    void SetAnimationToIdle()
    {
        if(_myAnimator != null)
        {
            if(_myAnimator.enabled)
            {
                _myAnimator.SetFloat(Forward, 0);
            }
        }
    }

     void SetAnimationToAttack()
    {
        if(_myAnimator != null)
        {
            if(_myAnimator.enabled)
            {
                _myAnimator.SetTrigger(Attack);
            }
        }
    }

    void SetAnimationToWalk()
    {
        if(_myAnimator != null)
        {
            if(_myAnimator.enabled)
            {
                _myAnimator.SetFloat(id: Forward, _forwardAmount, 0.2f, Time.deltaTime);
                _forwardAmount = Vector3.forward.z;
            }
        }
    }

    void DisableAnimator()
    {
        if(_myAnimator != null)
        {
            _myAnimator.enabled = false;
        }
    }
}

