using UnityEngine;

public class Arthur_Detection : MonoBehaviour
{
    private Arthur_Master _arthurMaster;
    private Transform _myTransform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float _checkRate;
    private float _nextCheck;
    private float _detectRadius = 80;
    private RaycastHit _hit;

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
        _arthurMaster = GetComponent<Arthur_Master>();
        _myTransform = transform;

        if(head == null)
        {
            head = _myTransform;
        }

        _checkRate = Random.Range(0.8f,1.2f);
    }

    void CarryoutDetection()
    {
        if(Time.time > _nextCheck)
        {
            _nextCheck = Time.time + _checkRate;
            Collider[] colliders = Physics.OverlapSphere(_myTransform.position,_detectRadius,playerLayer);

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
            _arthurMaster.CallEventArthurLostTarget();
        }
    

    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if(Physics.Linecast(head.position,potentialTarget.position,out _hit,sightLayer))
        {
            if(_hit.transform == potentialTarget)
            {
                _arthurMaster.CallEventArthurSetNavTarget(potentialTarget);
                return true;
            }
            else
            {
                _arthurMaster.CallEventArthurLostTarget();
                return false;
            }
        }
        else
        {
            _arthurMaster.CallEventArthurLostTarget();
            return false;
        }
    }


    void DisableThis()
    {
        this.enabled = false;
    }

}

