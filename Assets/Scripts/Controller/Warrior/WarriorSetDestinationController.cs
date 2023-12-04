using System.Collections;
using System.Collections.Generic;
using ProjectDawn.Navigation.Hybrid;
using UnityEngine;

public class WarriorSetDestinationController : MonoBehaviour
{
    
    [SerializeField]private AgentAuthoring _agentAuthoring;
    private Transform _target;

    public void InitData(float speed, Transform destination)
    {
        _target = destination;
        GetComponent<AgentAuthoring>().SetDestination(_target.position);
        _agentAuthoring.Speed = speed;
    }

    public void StopMoving()
    {
        _agentAuthoring.Stop();
    }
}