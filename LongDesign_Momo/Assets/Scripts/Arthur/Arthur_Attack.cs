using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arthur_Attack : MonoBehaviour
{
    private Arthur_Master _arthurmaster;
    private NavMeshAgent _myNavMeshAgent;
    private float _checkRate;
    private float _nextCheck;
    
    public float speed = 10f;
    public float time = 2.0f;
    public float timeDuration = 2.0f;
    
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    
    
    // Start is called before the first frame update
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
            TrytoshootTarget();
        }
        
    }

    void SetinitialRefrence()
    {
        _arthurmaster = GetComponent<Arthur_Master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            _myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        _checkRate = Random.Range(0.1f,0.2f);
    }

    public void TrytoshootTarget()
    {
        if (_arthurmaster.myTarget != null && _myNavMeshAgent != null)
            if (_myNavMeshAgent.remainingDistance < 2)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
                bulletPrefab.transform.LookAt(_arthurmaster.myTarget.transform.position);
            }

        if(gGlobal.fShoot == true)
        {
            _arthurmaster.CallEventArthurWander();
        } 
    }
}
