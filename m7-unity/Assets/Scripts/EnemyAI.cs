using UnityEngine;
using UnityEngine.AI;
using TMPro;
using NUnit.Framework.Interfaces;

public class EnemyAI : MonoBehaviour
{
    //Crea e inicializa las variables de estados, la luz asociada al enemigo, la vida del enemigo,
    //la cadencia de disparo, el daño que hace el enemigo, las coordendas de disparo,
    //el objeto skull para cuando el enemigo muere, una variable booleana isDead que controla si
    //el enemigo está vivo o no, y los waypoints en forma de array que marcan el camino del estado Patrol.
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AlertState alertState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public RunState runState;
    [HideInInspector] public IenemyState currentState;

    [HideInInspector] public NavMeshAgent navMeshAgent;

    //public float life = 100;
    public float timeBetweenShoots = 1.0f;
    public Transform target; // Referencia al jugador


    public int health = 30;
    //public float damageForce = 10f;
    public float rotationTime = 3.0f;
    //public float shootHeight = 0.5f;
    public TextMeshProUGUI enemyName;
    public Transform[] waypoints;
    public Material enemyColor { get; set; }

    // Inicializa los diferentes estados e indica que ha de ignorar el Raycast para que no hagan agujeros las balas
    // en el collider de detección
    void Start()
    {
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        attackState = new AttackState(this);
        runState = new RunState(this);

        currentState = patrolState;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyColor = GetComponent<Renderer>().material;
        enemyName.text = "Javi";
    }

    // Comprueba constantemente el cambio de estado y si el enemigo está vivo o no
    void Update()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }

        currentState.UpdateState();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else if (health <= 10)
        {
            currentState = runState; // Cambia a modo huida
        }
    }



    //Comprueban las colisiones de los colliders. Dependiendo de ellos, el enemigo pasa a un estado u otro del motor de estados.
    void OnTriggerEnter(Collider col)
    {
        currentState.OnTriggerEnter(col);
    }
    void OnTriggerStay(Collider col)
    {
        currentState.OnTriggerStay(col);
    }
    void OnTriggerExit(Collider col)
    {
        currentState.OnTriggerExit(col);
    }
}
