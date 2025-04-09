using UnityEngine;

public class AttackState : IenemyState
{

    EnemyAI myEnemy;
    float actualTimeBetweenShoots = 0;
    public Vector3 enemyPosition;
    public Quaternion enemyRotation;
    public Transform enemytransform;
    public GameObject ball;
    public float offset_y = 0;


    public AttackState(EnemyAI enemy)
    {
        myEnemy = enemy;
        ball = (GameObject)Resources.Load("Ball", typeof(GameObject));

    }

    public void UpdateState()
    {
        myEnemy.enemyColor.SetColor("_Color", Color.red);
        actualTimeBetweenShoots += Time.deltaTime;
        if(actualTimeBetweenShoots > 5)
        {
            GoToAlertState();
        }
    }

    public void GoToAttackState() { }

    public void GoToPatrolState() { }

    public void GoToAlertState() {
        myEnemy.currentState = myEnemy.alertState;
    }

    public void OnTriggerEnter(Collider col)
    {
        Shoot(col);
    }


    public void OnTriggerStay(Collider col)
    {
        Shoot(col);
    }

    public void OnTriggerExit(Collider col) {
        GoToAlertState();
    }

    public void Shoot(Collider col)
    {
        if (actualTimeBetweenShoots > myEnemy.timeBetweenShoots)
        {
            actualTimeBetweenShoots = 0;
            Vector3 lookDirection = col.transform.position - myEnemy.transform.position;
            myEnemy.transform.rotation = Quaternion.FromToRotation(Vector3.forward, lookDirection);
            RaycastHit rayHit = new RaycastHit();
            Ray ray = new Ray(myEnemy.transform.position, col.transform.position - myEnemy.transform.position);
            if (Physics.Raycast(ray, out rayHit, 20f))
            {
                if (rayHit.transform.tag == "Player")
                {
                    enemyPosition = myEnemy.transform.position;
                    enemyRotation = col.transform.rotation;
                    enemytransform = col.transform;

                    Vector3 spawnPosition = myEnemy.transform.position + myEnemy.transform.forward * 1.5f; 
                    GameObject go = GameObject.Instantiate(ball, spawnPosition, enemyRotation);
                    go.GetComponent<Rigidbody>().linearVelocity = myEnemy.transform.forward * 20;
                }
            }
        }
    }

}
