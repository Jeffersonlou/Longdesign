using UnityEngine;
using UnityEngine.UI;

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

        public Text NormalBoyStateText;

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
            NormalBoyStateText.text = "Wandering";
        }

        public void CallEventNormalboyAttack()
        {
            EventNormalboyAttack?.Invoke();
            NormalBoyStateText.text = "Attacking";
        }

        public void CallEventNormalboyReachedTarget()
        {
            EventNormalboyReachedTarget?.Invoke();
            NormalBoyStateText.text = "Reached Target";
        }

        public void CallEventNormalboyFlee()
        {
            EventNormalboyFlee?.Invoke();
            NormalBoyStateText.text = "Flee";
        }
    
        public void CallEventNormalboyLostTarget()
        {
            EventNormalboyLostTarget?.Invoke();
            NormalBoyStateText.text = "Lost Target";
        }
    }
}

