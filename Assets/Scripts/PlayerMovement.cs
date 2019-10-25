using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mySpeed;
    private Rigidbody2D myRigidBody;
    private Vector3 myChange;
    private Animator myAnimator;
    public GameObject arrowPrefab;

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
        if(Input.GetButtonDown("attack")){
            StartCoroutine(AttackCo());
        }
        ShootArrows();
        UpdateAnimation();   
    }

    private IEnumerator AttackCo(){
        myAnimator.SetBool("attacking",true);
        yield return null;
        myAnimator.SetBool("attacking",false);
        yield return new WaitForSeconds(.3f);
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

    void ShootArrows(){
        Vector2 shootingDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        shootingDirection.Normalize();
        if(Input.GetKeyDown("space")){
            GameObject arrow = Instantiate(arrowPrefab,transform.position,Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 5.0f;
            arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y,shootingDirection.x)*Mathf.Rad2Deg);
            Destroy(arrow,2.0f);
        }
    }

}
