using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    Animator anim;
    NavMeshAgent navMesh;
    float hitdist = 0.0f;
    Plane playerPlane;
    Ray ray;
    RaycastHit rayHit;
    public Vector3 targetPoint;
    List<Attack> attackSequence;
    public GameObject mouseTarget;
    public float attackTimer = 1;
    void Start () {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        mouseTarget = new GameObject();
        attackSequence = new List<Attack>();
        attackSequence.Add(new playerBasicAttack());
        attackSequence.Add(new playerBasicAttack());
        attackSequence.Add(new playerBasicAttack());
    }
	
	// Update is called once per frame
	void Update () {
        playerPlane = new Plane(Vector3.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        anim.SetBool("isRunning", navMesh.hasPath);
        playerPlane.Raycast(ray, out hitdist);
        targetPoint = ray.GetPoint(hitdist);
        Physics.Raycast(ray,out rayHit, 1000);

        attackTimer -= Time.deltaTime;

        anim.SetBool("isAttacking", false);

        if(mouseTarget.tag=="Enemy")
        {
            
            if ((mouseTarget.transform.position - transform.position).sqrMagnitude > 2f)
            {
                navMesh.SetDestination(mouseTarget.transform.position);
            }
            else
            {
                navMesh.SetDestination(transform.position);
            }
        }

        if (Input.GetMouseButton(0))
        {

            Physics.Raycast(ray, out rayHit, 1000);

            if (rayHit.collider != null)
            {
                mouseTarget = rayHit.collider.gameObject;
            }

                navMesh.SetDestination(targetPoint);

        }
 
        if(!navMesh.hasPath && mouseTarget.tag == "Enemy")
        {
            navMesh.updateRotation = false;
            Vector3 lookPos = mouseTarget.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,0.05f);

            //if((mouseTarget.transform.position- transform.position).sqrMagnitude > 1.1f)
            //{
            //    navMesh.SetDestination(mouseTarget.transform.position);
            //    return;
            //}
            //else
            //{
            //    navMesh.SetDestination(transform.position);
            //}

            if (attackTimer <= 0)
            {
                Attack();
            }
        }
        else
        {
            navMesh.updateRotation = true;
        }
    }

    void Attack()
    {
        print(5f);
        anim.SetBool("isAttacking", true);
        attackTimer = 1.5f;

    }
}
