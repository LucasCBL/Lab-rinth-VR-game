
using UnityEngine;
using UnityEngine.AI;
// enemigo de combate cuerpo a cuerpo
public class closeUpEnemy : MonoBehaviour
{
    // agente navmesh
    public NavMeshAgent agent;
    // posicion del jugador
    public Transform player;
    // parametros de animacion
    private int move = Animator.StringToHash("moving");
    private int attack = Animator.StringToHash("attacking");
    public Animator anim;

    // area de ataque
    public BoxCollider attack_area;
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
        
        // llegar al punto objetivo
        if (distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
            anim.ResetTrigger(move);
        } else {
            anim.SetTrigger(move);
        }
    }

    //perseguir al jugador
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetTrigger(move);
        anim.ResetTrigger(attack);
        walkPointSet = true;
    }
    // funcion atacar, cuando el jugador esta en rango
    private void AttackPlayer()
    {
        //inmobilizamos al enemigo
        agent.SetDestination(transform.position);
        Vector3 targetPosition = new Vector3( player.position.x, transform.position.y, player.position.z ) ;
        transform.LookAt(targetPosition);
        // verificamos si estamos en cooldown
        if (!alreadyAttacked)
        {
            anim.SetTrigger(attack);
            alreadyAttacked = true;
            // comprobamos todos los colliders en rango a ver si alguno es el jugador
            Collider[] hits =  Physics.OverlapBox(attack_area.transform.position + attack_area.center, attack_area.size / 2, Camera.main.transform.rotation);
            foreach(Collider obj in hits) {
                print(obj);
                playerHealth obj_health = obj.gameObject.GetComponent<playerHealth>();
                if(obj_health) {
                    obj_health.receive_damage(2);
                }
  
            }

            alreadyAttacked = true;
            // cooldown
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    //resetear el timer del ataque
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    // gizmo de area de ataque, siempre se ve
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attack_area.transform.position + attack_area.center, attack_area.size);
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
