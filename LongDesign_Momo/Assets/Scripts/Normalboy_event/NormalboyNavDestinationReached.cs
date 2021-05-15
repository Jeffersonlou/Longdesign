using UnityEngine;
using UnityEngine.AI;

namespace Normalboy_event
{
    public class NormalboyNavDestinationReached : MonoBehaviour
    {
        private NormalboyMaster _normalboyMaster;
        private NavMeshAgent _myNavMeshAgent;
        private float _checkRate;
        private float _nextCheck;

        void OnEnable() 
        {
            SetinitialRefrence();
        }


        void OnDisable()
        {
        
        }

        void Update() 
        {
            if(Time.time > _nextCheck)
            {
                _nextCheck = Time.time + _checkRate;
                CheckifReachedDestination();
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
        }

        void CheckifReachedDestination()
        {
            if(_normalboyMaster.isOnRoute)
            {
                if(_myNavMeshAgent.remainingDistance <= _myNavMeshAgent.stoppingDistance)
                {
                    _normalboyMaster.isOnRoute = false;
                    _normalboyMaster.CallEventNormalboyReachedTarget();
                }

            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }
    }
}
