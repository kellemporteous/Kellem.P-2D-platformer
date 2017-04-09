using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;
    public EnemyState enemyState;

    public int minDistance;

    public enum EnemyState
    {
        Idle,
        Attack
    }

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyLogic();
        EnemyBehaviour();
    }

   

    void EnemyLogic()
    {
        RaycastHit hit;

            if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, minDistance))
        {
            //Hit player?
            if (hit.transform.tag == "Player")
            {
                //STATE TRANSITION: ATTACK
                enemyState = EnemyState.Attack;
            }
            //STATE TRANSITION: IDLE
            else
            {
                enemyState = EnemyState.Idle;
            }


        }
    }

    void EnemyBehaviour()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                //Idle
                break;

            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    void Attack()
    {
        agent.SetDestination(target.transform.position);
    }
}