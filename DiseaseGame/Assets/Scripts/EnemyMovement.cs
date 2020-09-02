using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D enemyBody;
    Vector3 currentPosition;
    List<GameObject> redCells = new List<GameObject>();
    //GameObject[] redCells; //cells that bacteria are targeting
    GameObject currentTarget;

    NavMeshAgent2D agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();

        currentPosition = transform.position;
        //redCells = GameObject.FindGameObjectsWithTag("Target").ToList(); ; //gets all remaining red cells when spawned
        FindTarget();
        Debug.Log("yea");
    }

    void FindTarget()
    {
        //add check if list empty here!!!!
        redCells = GameObject.FindGameObjectsWithTag("Target").ToList(); ; //gets all remaining red cells when spawned

        float closestDistance = Mathf.Infinity;  //sets closest distance to infinity so any other value will override it

        foreach(GameObject redCell in redCells)  //goes through and finds closest red cell
        {
            float distance = Vector3.Distance(redCell.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentTarget = redCell;
                
            }
        }
        redCells.Remove(currentTarget); //removes current target from list of possible targets
        agent.destination = currentTarget.transform.position;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Target")
        {
            Destroy(other.gameObject);
            FindTarget();
            //tell other cells to find new targets as well
        }
    }
    void Update()
    {
        if (!agent.pathPending)
            FindTarget();
    }
}
