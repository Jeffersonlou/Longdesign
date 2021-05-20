using UnityEngine;

namespace Normalboy_event
{
    public class NormalboyMaster : MonoBehaviour
    {
        public Transform myTarget;
        public bool isOnRoute;
        public bool isNavPaused;

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventNormalboyFlee;
        public event GeneralEventHandler EventNormalboyReachedTarget;
        public event GeneralEventHandler EventNormalboyLostTarget;
        public event GeneralEventHandler EventNormalboyWander;
        public event GeneralEventHandler EventNormalboyAttack;
        public event GeneralEventHandler EventNormalboyDie;

        public delegate void NavTargetEventHandler(Transform targetTransform);
        public event NavTargetEventHandler EventNormalboySetRunawayNavTarget;

        public void CallEventNormalboySetRunawayNavTarget(Transform tragTransform)
        {
            EventNormalboySetRunawayNavTarget?.Invoke(tragTransform);
            myTarget = tragTransform;
        }

        public void CallEventNormalboyDie()
        {
            EventNormalboyDie?.Invoke();
        }

        public void CallEventNormalboyWander()
        {
            EventNormalboyWander?.Invoke();
        }

        public void CallEventNormalboyAttack()
        {
            EventNormalboyAttack?.Invoke();
        }

        public void CallEventNormalboyReachedTarget()
        {
            EventNormalboyReachedTarget?.Invoke();
        }

        public void CallEventNormalboyFlee()
        {
            EventNormalboyFlee?.Invoke();
        }
    
        public void CallEventNormalboyLostTarget()
        {
            EventNormalboyLostTarget?.Invoke();
        }
    }
}

