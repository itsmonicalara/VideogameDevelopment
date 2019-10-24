using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mySpeed;
    private Rigidbody2D myRigidBody;
    private Vector3 myChange;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myChange = Vector3.zero;
        myChange.x = Input.GetAxisRaw("Horizontal");
        myChange.y = Input.GetAxisRaw("Vertical");
        UpdateAnimation();
    }

    void MovePlayer(){
        myRigidBody.MovePosition(transform.position + myChange * mySpeed * Time.deltaTime);
    }

    void UpdateAnimation(){
        if(myChange != Vector3.zero){
            MovePlayer();
            myAnimator.SetFloat("moveX",myChange.x);
            myAnimator.SetFloat("moveY",myChange.y);
            myAnimator.SetBool("moving",true);
        }else{
            myAnimator.SetBool("moving",false);
        }
    }

}
