<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy_master : MonoBehaviour
{
    public Transform myTarget;
    public bool isOnRoute;
    public bool isNavPaused;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventCowboyChase;
    public event GeneralEventHandler EventCowboyReachedTarget;
    public event GeneralEventHandler EventCowboyLostTarget;
    public event GeneralEventHandler EventCowboyWander;
    public event GeneralEventHandler EventCowboyAttack;
    public event GeneralEventHandler EventCowboyDie;

    public delegate void NavTargetEventHandler(Transform targetTransform);
    public event NavTargetEventHandler EventCowboySetNavTarget;

    public void CallEventCowboySetNavTarget(Transform tragTransform)
    {
        if(EventCowboySetNavTarget != null)
        {
            EventCowboySetNavTarget(tragTransform);
        }
        myTarget = tragTransform;
    }

    public void CallEventCowboyDie()
    {
        if(EventCowboyDie != null)
        {
            EventCowboyDie();
        }
    }

    public void CallEventCowboyWander()
    {
        if(EventCowboyWander != null)
        {
            EventCowboyWander();
        }
    }

    public void CallEventCowboyAttack()
    {
        if(EventCowboyAttack != null)
        {
            EventCowboyAttack();
        }
    }

    public void CallEventCowboyReachedTarget()
    {
        if(EventCowboyReachedTarget != null)
        {
            EventCowboyReachedTarget();
        }
    }

    public void CallEventCowboyLostTarget()
    {
        if(EventCowboyLostTarget != null)
        {
            EventCowboyLostTarget();
        }
    }

    public void CallEventCowboyChase()
    {
        if(EventCowboyChase != null)
        {
            EventCowboyChase();
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cowboy_master : MonoBehaviour
{
    public Transform myTarget;
    public bool isOnRoute;
    public bool isNavPaused;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventCowboyChase;
    public event GeneralEventHandler EventCowboyReachedTarget;
    public event GeneralEventHandler EventCowboyLostTarget;
    public event GeneralEventHandler EventCowboyWander;
    public event GeneralEventHandler EventCowboyAttack;
    public event GeneralEventHandler EventCowboyDie;

    public Text CowBoyStateText;

    public delegate void NavTargetEventHandler(Transform targetTransform);
    public event NavTargetEventHandler EventCowboySetNavTarget;

    public void CallEventCowboySetNavTarget(Transform tragTransform)
    {
        if(EventCowboySetNavTarget != null)
        {
            EventCowboySetNavTarget(tragTransform);
        }
        myTarget = tragTransform;
    }

    public void CallEventCowboyDie()
    {
        if(EventCowboyDie != null)
        {
            EventCowboyDie();
            CowBoyStateText.text = "Dead";
        }
    }

    public void CallEventCowboyWander()
    {
        if(EventCowboyWander != null)
        {
            EventCowboyWander();
            CowBoyStateText.text = "Wandering";
        }
    }

    public void CallEventCowboyAttack()
    {
        if(EventCowboyAttack != null)
        {
            EventCowboyAttack();
            CowBoyStateText.text = "Attacking";
        }
    }

    public void CallEventCowboyReachedTarget()
    {
        if(EventCowboyReachedTarget != null)
        {
            EventCowboyReachedTarget();
            CowBoyStateText.text = "Reached Target";
        }
    }

    public void CallEventCowboyLostTarget()
    {
        if(EventCowboyLostTarget != null)
        {
            EventCowboyLostTarget();
            CowBoyStateText.text = "Lost Target";
        }
    }

    public void CallEventCowboyChase()
    {
        if(EventCowboyChase != null)
        {
            EventCowboyChase();
            CowBoyStateText.text = "Chasing";
        }
    }
}
>>>>>>> Stashed changes
