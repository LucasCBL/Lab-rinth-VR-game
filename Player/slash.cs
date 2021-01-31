using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ataque cuerpo a cuerpo
public class slash : MonoBehaviour
{

    public Animator anim;
    private int attack = Animator.StringToHash("attack");
    private int cut = Animator.StringToHash("sword animation");
    public BoxCollider attack_area ;
    public LayerMask m_LayerMask;
    public float timeBetweenAttacks = 2f;
    bool alreadyAttacked = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger(attack);
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        print(stateInfo);
        if(Input.GetButtonDown("Fire1") && !alreadyAttacked) {
            alreadyAttacked = true;
            print(stateInfo);
            print(cut);
            anim.SetTrigger(attack);
            Collider[] hits =  Physics.OverlapBox(attack_area.transform.position + attack_area.center, attack_area.size / 2, Camera.main.transform.rotation);
            foreach(Collider obj in hits) {
                print(obj);
                health obj_health = obj.gameObject.GetComponent<health>();
                if(obj_health) {
                    obj_health.receive_damage(2);
                }
                break_door door = obj.gameObject.GetComponent<break_door>();
                if(door) {
                    door.play_break();
                }
            }
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attack_area.transform.position + attack_area.center, attack_area.size);
    }
    void ResetAttack() {
        alreadyAttacked = false;
    }
}
