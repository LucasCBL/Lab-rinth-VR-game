
using UnityEngine;
using UnityEngine.AI;
// enemigo de combate a distancia
public class remoteEnemy : MonoBehaviour
{
   // agente navmesh
    public NavMeshAgent agent;
    // posicion del jugador
    public Transform player;
    // parametros de animacion
    private int move = Animator.StringToHash("moving");
    private int attack = Animator.StringToHash("attacking");
    public Animator anim;

    // layer del jugador
    public LayerMask  whatIsPlayer;
    // collider
    public CapsuleCollider capsule;


    // punto a moverse
    public Vector3 walkPoint;
    bool walkPointSet;


    // tiempo entre ataques
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // proyectil
    public GameObject projectile;


    // rangos del enemigo
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        capsule = gameObject.GetComponent<CapsuleCollider>();
        walkPoint = transform.position;
    }

    private void Update()
    {
        // chequea al jugador
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        // anim.ResetTrigger(attack);
        // toma distintas acciones dependiendo de si el jugaador esta en rango o no
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    // patrullar
    private void Patroling()
    {

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // llegamos al punto objetivo
        if (distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
            // anim.ResetTrigger(move);
        } else { 
            anim.SetTrigger(move);
        }
    }

    //perseguir al jugador
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        walkPointSet = true;
    }

    private void AttackPlayer()
    {
        //inmobilizar al enemigo
        agent.SetDestination(transform.position);
        Vector3 targetPosition = new Vector3( player.position.x, player.position.y, player.position.z ) ;
        transform.LookAt(targetPosition);
        
        if (!alreadyAttacked)
        {
            anim.SetTrigger(attack);
            // instanciamos el proyectil
            Rigidbody rb = Instantiate(projectile, transform.position + (capsule.center / 1.5f) + transform.forward * 2, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.transform.position += ;
            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);
  

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    //resetear el timer del ataque
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    // gizmos para mostrar las areas en la escena cuando se selecciona
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
