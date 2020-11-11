using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavAgentController : MonoBehaviour
{
    public Transform _target;
    NavMeshAgent _navAgent;
    // Start is called before the first frame update
    void Start()
    {
        _navAgent = GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
