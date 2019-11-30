using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbolito : Enemy
{
    public Transform myTarget;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Color startColor;
    public Color FeedbackColor;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindWithTag("Player").transform;
        startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        // Debug.Log("The enemy health is: " + health);
    }

    void CheckDistance(){
        if(Vector3.Distance(myTarget.position,transform.position)<= chaseRadius &&
         Vector3.Distance(myTarget.position,transform.position)>attackRadius){
            transform.position = Vector3.MoveTowards(transform.position,myTarget.position,
            moveSpeed * Time.deltaTime);
        }
    }


    IEnumerator FeedbackDamage() {
        gameObject.GetComponent<SpriteRenderer>().color = FeedbackColor;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().color = startColor;
    }
}
