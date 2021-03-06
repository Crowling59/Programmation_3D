using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CorpsMove : MonoBehaviour
{

    [SerializeField] Transform _destination;

    private NavMeshAgent _navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        /*if (_navMeshAgent == null)
        {
            Debug.LogError("error");
        }
        else
        {
            SetDestination();
        }*/
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    private void Update()
    {
        if (_navMeshAgent == null)
        {
            Debug.LogError("error");
        }
        else
        {
            SetDestination();
        }
    }
}
