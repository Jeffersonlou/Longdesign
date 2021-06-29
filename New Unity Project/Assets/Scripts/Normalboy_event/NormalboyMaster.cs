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

        public Text NormalboyStateText;

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
            Debug.Log("Wander");
            NormalboyStateText.text = "Wandering";
        }

        public void CallEventNormalboyAttack()
        {
            EventNormalboyAttack?.Invoke();
            NormalboyStateText.text = "Attacking";
        }

        public void CallEventNormalboyReachedTarget()
        {
            EventNormalboyReachedTarget?.Invoke();
            NormalboyStateText.text = "Found Target";
        }

        public void CallEventNormalboyFlee()
        {
            EventNormalboyFlee?.Invoke();
            NormalboyStateText.text = "Fleeing";
        }
    
        public void CallEventNormalboyLostTarget()
        {
            EventNormalboyLostTarget?.Invoke();
            NormalboyStateText.text = "Lost Target";

        }
    }
}

