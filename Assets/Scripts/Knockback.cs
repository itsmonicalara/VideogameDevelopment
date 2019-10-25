using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float myThrust;
    public float knockTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("Player")){
            Rigidbody2D hit = col.GetComponent<Rigidbody2D>();
            if(hit != null){
                hit.isKinematic = false;
                Vector2 difference = (hit.transform.position - transform.position);
                difference = difference.normalized * myThrust;
                hit.AddForce(difference,ForceMode2D.Impulse);
                hit.isKinematic = true;
                StartCoroutine(KnockCo(hit));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}
