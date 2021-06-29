using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh_move : MonoBehaviour
{
    public GameObject[] Goal;
    public GameObject Touch;
    NavMeshAgent agent;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        int d = Random.Range(0,Goal.Length);
        agent.SetDestination(Goal[d].transform.position);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("enter"))
        {
            Debug.Log("enter pressed");
            agent.SetAreaCost(3,1);
            agent.SetDestination(Touch.transform.position);
        }

        if(agent.remainingDistance < 0.5)
        {
            int d = Random.Range(0,Goal.Length);
            agent.SetAreaCost(3,10);
            agent.SetDestination(Goal[d].transform.position);
        }
        else if(agent.hasPath)
        {
            Vector3 toTarget = agent.steeringTarget - this.transform.position;
            float turnAngle = Vector3.Angle(this.transform.forward,toTarget);
            agent.acceleration = turnAngle * agent.speed / 10f;
        }

        

    }
}
