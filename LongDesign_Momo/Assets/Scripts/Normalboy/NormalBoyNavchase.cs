using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Normalboy_event
{
    public class NormalBoyNavchase : MonoBehaviour
    {
        private NormalboyMaster _normalboyMaster;
        private NavMeshAgent _myNavMeshAgent;
        private float _checkRate;
        private float _nextCheck;

        private void OnEnable()
        {
            SetinitialRefrence();
        }

        // Update is called once per frame
        private void Update()
        {
            if(Time.time > _nextCheck)
            {
                _nextCheck = Time.time + _checkRate;
                TryToChaseTarget();
            }
        
        }

        void SetinitialRefrence()
        {
            _normalboyMaster = GetComponent<NormalboyMaster>();
            if(GetComponent<NavMeshAgent>() != null)
            {
                _myNavMeshAgent = GetComponent<NavMeshAgent>();
            }
            _checkRate = Random.Range(0.1f,0.2f);
        }

        private void TryToChaseTarget()
        {
            if(_normalboyMaster.myTarget != null && _myNavMeshAgent != null && !_normalboyMaster.isNavPaused)
            {
                var position = transform.position;
                _myNavMeshAgent.SetDestination(position);

                if(_myNavMeshAgent.remainingDistance > _myNavMeshAgent.stoppingDistance)
                {
                    _normalboyMaster.CallEventNormalboyChase();
                    _normalboyMaster.isOnRoute = true;
                }
            }
        }

        private void DisableThis()
        {
            if(_myNavMeshAgent != null)
            {
                _myNavMeshAgent.enabled = false;
            }

            this.enabled = false;
        }

    }
}
