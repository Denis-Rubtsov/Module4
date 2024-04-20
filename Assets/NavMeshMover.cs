using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _animator;
    public float Distance {  get; private set; }

    public void MoveTo(Vector3 position)
    {
        _agent.isStopped = false;
        _agent.SetDestination(position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }

    public void StopOrStart()
    {
        _agent.isStopped = !_agent.isStopped;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = _agent.remainingDistance;
    }
}
