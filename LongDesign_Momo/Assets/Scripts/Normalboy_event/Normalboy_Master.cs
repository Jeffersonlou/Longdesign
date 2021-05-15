using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normalboy_Master : MonoBehaviour
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
        if(EventNormalboySetRunawayNavTarget != null)
        {
            EventNormalboySetRunawayNavTarget(tragTransform);
        }
        myTarget = tragTransform;
    }

    public void CallEventNormalboyDie()
    {
        if(EventNormalboyDie != null)
        {
            EventNormalboyDie();
        }
    }

    public void CallEventNormalboyWander()
    {
        if(EventNormalboyWander != null)
        {
            EventNormalboyWander();
        }
    }

    public void CallEventNormalboyAttack()
    {
        if(EventNormalboyAttack != null)
        {
            EventNormalboyAttack();
        }
    }

    public void CallEventNormalboyReachedTarget()
    {
        if(EventNormalboyReachedTarget != null)
        {
            EventNormalboyReachedTarget();
        }
    }

    public void CallEventNormalboyFlee()
    {
        if(EventNormalboyFlee != null)
        {
            EventNormalboyFlee();
        }
    }
    
    public void CallEventNormalboyLostTarget()
    {
        if(EventNormalboyLostTarget != null)
        {
            EventNormalboyLostTarget();
        }
    }
}

