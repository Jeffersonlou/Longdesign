using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthur_Master : MonoBehaviour
{
    public Transform myTarget;
    public bool isOnRoute;
    public bool isNavPaused;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventArthurReachedTarget;
    public event GeneralEventHandler EventArthurLostTarget;
    public event GeneralEventHandler EventArthurWander;
    public event GeneralEventHandler EventArthurAttack;
    public event GeneralEventHandler EventArthurDie;
    public event GeneralEventHandler EventArthurChase;

    public delegate void NavTargetEventHandler(Transform targetTransform);
    public event NavTargetEventHandler EventArthurSetNavTarget;

    public void CallEventArthurSetNavTarget(Transform tragTransform)
    {
        EventArthurSetNavTarget?.Invoke(tragTransform);
        myTarget = tragTransform;
    }

    public void CallEventArthurDie()
    {
        EventArthurDie?.Invoke();
    }

    public void CallEventArthurWander()
    {
        EventArthurWander?.Invoke();
    }

    public void CallEventArthurAttack()
    {
        EventArthurAttack?.Invoke();
    }

    public void CallEventArthurReachedTarget()
    {
        EventArthurReachedTarget?.Invoke();
    }

    public void CallEventArthurLostTarget()
    {
        EventArthurLostTarget?.Invoke();
    }

    public void CallEventArthurChase()
    {
        EventArthurChase?.Invoke();
    }
}


