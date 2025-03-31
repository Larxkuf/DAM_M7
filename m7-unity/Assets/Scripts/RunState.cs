using UnityEngine;
using UnityEngine.AI;

public class RunState : IenemyState
{
    EnemyAI myEnemy;
    private float runDistance = 10f; // Distancia a la que intentará huir

    public RunState(EnemyAI enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {

        myEnemy.enemyColor.SetColor("_Color", Color.blue);

       
        if (myEnemy.navMeshAgent.isStopped)
        {
            myEnemy.navMeshAgent.isStopped = false;
        }

        // Configurar velocidad
        myEnemy.navMeshAgent.speed = 3f;
        myEnemy.navMeshAgent.acceleration = 8f;

        Vector3 runDirection = myEnemy.transform.position +
                              (myEnemy.transform.position - myEnemy.target.position).normalized * runDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(runDirection, out hit, 10f, NavMesh.AllAreas))
        {
            Debug.Log(" [RunState] Huyendo a: " + hit.position);
            myEnemy.navMeshAgent.SetDestination(hit.position);
        }
    }

    public void GoToAttackState() { }
    public void GoToAlertState() { }
    public void GoToPatrolState() { }

    public void OnTriggerEnter(Collider col) { }
    public void OnTriggerStay(Collider col) { }
    public void OnTriggerExit(Collider col) { }
}
