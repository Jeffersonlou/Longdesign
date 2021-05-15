﻿using UnityEngine;
using UnityEngine.AI;

namespace Normalboy_event
{
    public class NormalboyNavflee : MonoBehaviour
    {
        private NormalboyMaster _normalboyMaster;
        private NavMeshAgent _myNavMeshAgent;
        private float _checkRate;
        private float _nextCheck;

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
                TryToFleeFormTarget();
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

        void TryToFleeFormTarget()
        {
            if(_normalboyMaster.myTarget != null && _myNavMeshAgent != null && !_normalboyMaster.isNavPaused)
            {
                Vector3 dirToTarget = transform.position - _normalboyMaster.myTarget.position;
                Vector3 fleeTarget = transform.position + dirToTarget;
                _myNavMeshAgent.SetDestination(fleeTarget);

                if(_myNavMeshAgent.remainingDistance > _myNavMeshAgent.stoppingDistance)
                {
                    _normalboyMaster.CallEventNormalboyFlee();
                    _normalboyMaster.isOnRoute = true;
                }
            }
        }

        void DisableThis()
        {
            if(_myNavMeshAgent != null)
            {
                _myNavMeshAgent.enabled = false;
            }

            this.enabled = false;
        }
    }
}
