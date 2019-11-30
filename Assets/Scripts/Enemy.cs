using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    // Start is called before the first frame update

    // public float DamageForceThreshold = 1f;
    // public float DamageForceScale = 5f;

    // public int CurrentHealth { get; private set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void isDead(){
    //     if(health == 0){
    //         Destroy(gameObject);
    //     }
    // }


    private void OnCollisionEnter2D (Collision2D other) {
        Debug.Log("Collision con la flecha");
        Debug.Log("The enemy health is: " + health);

        if(other.gameObject.name == "Arrow(Clone)") {
        StartCoroutine("FeedbackDamage");
        health = health - 20;
            if(health == 0) {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}
