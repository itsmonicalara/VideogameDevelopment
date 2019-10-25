using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbolito : Enemy
{
    public Transform myTarget;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if(Vector3.Distance(myTarget.position,transform.position)<= chaseRadius &&
         Vector3.Distance(myTarget.position,transform.position)>attackRadius){
            transform.position = Vector3.MoveTowards(transform.position,myTarget.position,
            moveSpeed * Time.deltaTime);
        }
    }
}
