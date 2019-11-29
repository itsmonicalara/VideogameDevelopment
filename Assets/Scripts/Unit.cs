using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	public int unitLevel;

	public int damage;

	public int maxHP;
	public int currentHP;

	public AnimationCurve myCurve;

	private bool dirRight = true;
    public float speed = 2.0f;


	void Start(){
	}
	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

	void Update(){
		transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);	
			AnimPlayer();			
	}

	void AnimPlayer(){
		if (dirRight)
             transform.Translate (Vector2.right * speed * Time.deltaTime);
         else
             transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
         if(transform.position.x >= 4.0f) {
             dirRight = false;
         }
         
         if(transform.position.x <= -4) {
             dirRight = true;
         }
	}

}
