using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move : MonoBehaviour {

    // Use this for initialization
    Animator anim;
    NavMeshAgent navMesh;
    float hitdist = 0.0f;
    Plane playerPlane;
    Ray ray;
    public Vector3 targetPoint;
    void Start () {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        playerPlane = new Plane(Vector3.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        anim.SetBool("isRunning", navMesh.hasPath);

        if (Input.GetMouseButton(0))
        {


            playerPlane.Raycast(ray, out hitdist);
            targetPoint = ray.GetPoint(hitdist);
            navMesh.SetDestination(targetPoint);





        }
    }
}
