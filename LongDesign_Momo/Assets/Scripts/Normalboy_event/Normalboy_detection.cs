using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normalboy_detection : MonoBehaviour
{
    private Normalboy_Master normalboyMaster;
    private Transform myTransform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextCheck;
    private float detectRadius = 80;
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
        normalboyMaster = GetComponent<Normalboy_Master>();
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
                    if(potentialTargetCollider.CompareTag("Cowboy"))
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
            normalboyMaster.CallEventNormalboyLostTarget();
        }
        

    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if(Physics.Linecast(head.position,potentialTarget.position,out hit,sightLayer))
        {
            if(hit.transform == potentialTarget)
            {
                normalboyMaster.CallEventNormalboySetRunawayNavTarget(potentialTarget);
                return true;
            }
            else
            {
                normalboyMaster.CallEventNormalboyLostTarget();
                return false;
            }
        }
        else
        {
            normalboyMaster.CallEventNormalboyLostTarget();
            return false;
        }
    }


    void DisableThis()
    {
        this.enabled = false;
    }

}
