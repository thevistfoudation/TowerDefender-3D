using System.Collections;
using System.Collections.Generic;
using ProjectDawn.Navigation.Hybrid;
using UnityEngine;

public class WarriorSetDestinationController : MonoBehaviour
{
    
    [SerializeField]private AgentAuthoring _agentAuthoring;

    public void InitData(float speed, Transform destination)
    {
        GetComponent<AgentAuthoring>().SetDestination(destination.position);
        _agentAuthoring.Speed = speed;
    }

    public void StopMoving()
    {
        _agentAuthoring.Stop();
    }
}