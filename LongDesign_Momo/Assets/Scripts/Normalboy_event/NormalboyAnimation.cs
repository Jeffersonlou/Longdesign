using UnityEngine;

namespace Normalboy_event
{
    public class NormalboyAnimation : MonoBehaviour{
        private NormalboyMaster _normalboyMaster; 
        private Animator _myAnimator;
        private float _forwardAmount;

        void OnEnable() 
        {
            SetinitialRefrence();
            _normalboyMaster.EventNormalboyReachedTarget += SetAnimationToIdle;
            _normalboyMaster.EventNormalboyAttack += SetAnimationToAttack;
            _normalboyMaster.EventNormalboyWander += SetAnimationToWalk;
            _normalboyMaster.EventNormalboyFlee += SetAnimationToRun;
        }
        void OnDisable() 
        {
            _normalboyMaster.EventNormalboyReachedTarget -= SetAnimationToIdle;
            _normalboyMaster.EventNormalboyAttack -= SetAnimationToAttack;
            _normalboyMaster.EventNormalboyWander -= SetAnimationToWalk;
            _normalboyMaster.EventNormalboyFlee -= SetAnimationToRun;
        }

        void SetinitialRefrence()
        {
            _normalboyMaster = GetComponent<NormalboyMaster>();
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
                    _myAnimator.SetFloat("Forward", 0);
                    _myAnimator.SetFloat("Turn", 0);
                }
            }
        }

        void SetAnimationToRun()
        {
            if(_myAnimator != null)
            {
                if(_myAnimator.enabled)
                {
                    _myAnimator.SetFloat("Forward", _forwardAmount, 0.3f, Time.deltaTime);
                    _forwardAmount = Vector3.forward.z;
                }
            }
        }

        void SetAnimationToAttack()
        {
            if(_myAnimator != null)
            {
                if(_myAnimator.enabled)
                {
                    _myAnimator.SetTrigger("Attack");
                }
            }
        }

        void SetAnimationToWalk()
        {
            if(_myAnimator != null)
            {
                if(_myAnimator.enabled)
                {
                    _myAnimator.SetFloat("Forward", _forwardAmount, 0.2f, Time.deltaTime);
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
}
