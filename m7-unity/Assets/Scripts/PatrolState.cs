using UnityEngine;

public class PatrolState : IenemyState
{
    EnemyAI myEnemy;
    private int nextWayPoint = 0;

    public PatrolState(EnemyAI enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.enemyColor.SetColor("_Color", Color.green);
        Debug.Log(myEnemy.enemyColor);
        myEnemy.navMeshAgent.destination = myEnemy.waypoints[nextWayPoint].position;

        if (!myEnemy.navMeshAgent.pathPending &&
            myEnemy.navMeshAgent.remainingDistance <= myEnemy.navMeshAgent.stoppingDistance &&
            myEnemy.navMeshAgent.velocity.sqrMagnitude == 0)
        { 
            nextWayPoint = (nextWayPoint + 1) % myEnemy.waypoints.Length;
        }
    }

    public void GoToAlertState()
    {
        myEnemy.navMeshAgent.isStopped = true;
        myEnemy.currentState = myEnemy.alertState;
    }

    public void GoToAttackState()
    {
        myEnemy.navMeshAgent.isStopped = true;
        myEnemy.currentState = myEnemy.attackState;
    }

    public void GoToPatrolState()
    {
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GoToAlertState();
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GoToAlertState();
        }
    }

    public void OnTriggerExit(Collider col){}

}
