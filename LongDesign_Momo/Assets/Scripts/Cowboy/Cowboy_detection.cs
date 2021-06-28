using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy_detection : MonoBehaviour
{
    private Cowboy_master cowboyMaster;
    private Transform myTransform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextCheck;
    public float detectRadius = 10;
    private RaycastHit hit;

    // Start is called before the first frame update
    void OnEnable() 
    {
        SetinitialRefrence();
    }

    void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CarryoutDetection();
    }

    void SetinitialRefrence()
    {
        cowboyMaster = GetComponent<Cowboy_master>();
        myTransform = transform;

        if(head == null)
        {
            head = myTransform;
        }

        checkRate = Random.Range(0.8f,1.2f);
    }

    void CarryoutDetection()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            Collider[] colliders = Physics.OverlapSphere(myTransform.position,detectRadius,playerLayer);

            if(colliders.Length > 0)
            {
                foreach(Collider potentialTargetCollider in colliders)
                {
                    if(potentialTargetCollider.CompareTag("NormalBoy"))
                    {
                        if(CanPotentialTargetBeSeen(potentialTargetCollider.transform))
                        {
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            cowboyMaster.CallEventCowboyLostTarget();
        }
        

    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if(Physics.Linecast(head.position,potentialTarget.position,out hit,sightLayer))
        {
            if(hit.transform == potentialTarget)
            {
                cowboyMaster.CallEventCowboySetNavTarget(potentialTarget);
                return true;
            }
            else
            {
                cowboyMaster.CallEventCowboyLostTarget();
                return false;
            }
        }
        else
        {
            cowboyMaster.CallEventCowboyLostTarget();
            return false;
        }
    }


    void DisableThis()
    {
        this.enabled = false;
    }

}
