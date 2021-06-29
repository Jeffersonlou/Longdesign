using UnityEngine;
using UnityEngine.AI;

namespace Normalboy_event
{
    public class NormalboyNavwander : MonoBehaviour
    {
        private NormalboyMaster _normalboyMaster;
        private NavMeshAgent _myNavMeshAgent;
        private float _checkRate;
        private float _nextCheck;
        private float _wanderRange = 10;
        private Transform _myTransform;
        private NavMeshHit _navHit;
        private Vector3 _wanderTarget;

        void OnEnable() 
        {
            SetinitialRefrence();
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.time > _nextCheck)
            {
                _nextCheck = Time.time + _checkRate;
                CheckIfIShouldwander();  
            }
              
        }

        void SetinitialRefrence()
        {
            _normalboyMaster = GetComponent<NormalboyMaster>();
            if(GetComponent<NavMeshAgent>() != null)
            {
                _myNavMeshAgent = GetComponent<NavMeshAgent>();
            }
            _checkRate = Random.Range(0.3f,0.4f);
            _myTransform = transform; 
        }

        void CheckIfIShouldwander()
        {
            if(_normalboyMaster.myTarget == null && !_normalboyMaster.isOnRoute && !_normalboyMaster.isNavPaused)
            {
                if(RandomWanderTarget(_myTransform.position,_wanderRange,out _wanderTarget))
                {
                    _myNavMeshAgent.SetDestination(_wanderTarget);
                    //Debug.Log(wanderTarget);
                    _normalboyMaster.isOnRoute = true;
                    _normalboyMaster.CallEventNormalboyWander();
                }
            }

        }

        bool RandomWanderTarget(Vector3 center,float range,out Vector3 result)
        {
            Vector3 randompoint = center + Random.insideUnitSphere * _wanderRange;
            if(NavMesh.SamplePosition(randompoint,out _navHit,1.0f,NavMesh.AllAreas))
            {
                result = _navHit.position;
                return true;
            }
            else
            {
                result = center;
                return false;
            }

        }

        void DisableThis()
        {
            this.enabled = false;
        }

    }
}
