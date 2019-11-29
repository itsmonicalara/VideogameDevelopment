using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    public AudioSource battleBegins;
    public AudioSource battleEnds;
    public AudioSource enemySound;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

        battleBegins.Play();

		dialogueText.text = "Una " + enemyUnit.unitName + " se acerca...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(1.5f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "El ataque fue exitoso!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " atacó!";

        enemySound.Play();

        yield return new WaitForSeconds(0.5f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
        battleBegins.Stop();
        battleEnds.Play();
		if(state == BattleState.WON)
		{
			dialogueText.text = "Haz ganado la batalla Manuelito :)";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "Te han derrotado Manuelito :(";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Escoge que hacer: ";
	}

	IEnumerator PlayerHeal()
	{
        if(playerUnit.currentHP == playerUnit.maxHP)
        {
            dialogueText.text = "Tu salud esta al máximo perro!";
            yield return new WaitForSeconds(2f);
            PlayerTurn();
        }
        else {
            playerUnit.Heal(5);
            playerHUD.SetHP(playerUnit.currentHP);
            dialogueText.text = "Te comiste unos taquitos!";

            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
		
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
