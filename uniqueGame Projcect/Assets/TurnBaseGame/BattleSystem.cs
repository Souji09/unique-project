using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState
{
    Start,
    PlayerTurn,
    waiting,
    EnemyTurn,
    Won,
    Lost
}
public class BattleSystem : MonoBehaviour
{
    public BattleState State;
    
    public GameObject EnemyPrefab;
    public GameObject PlayerPrefab;

    public BattleHUD EnemyHUD;
    public BattleHUD PlayerHUD;

    public Transform EnemyBattleStattion;
    public Transform playerBattleStattion;

    public Text DialogText;

    Unit PlayerUnit;
    Unit EnemyUnit;
    public Button AttackButton;
    public Button healingButton;

    public void Start()
    {
        

        State = BattleState.Start;
        StartCoroutine(BattleSetup());
        AttackButton.onClick.AddListener(OnAttackButton);
        healingButton.onClick.AddListener(OnHealingButton);
    }
    public  IEnumerator BattleSetup()
    {
        GameObject EnemyGO = Instantiate(EnemyPrefab, EnemyBattleStattion);    
        EnemyUnit = EnemyGO.GetComponent<Unit>();

        GameObject PlayerGO = Instantiate(PlayerPrefab, playerBattleStattion);
        PlayerUnit = PlayerGO.GetComponent<Unit>();

        DialogText.text = "Strange Creature " + EnemyUnit.Unitname + " Approaches";
        EnemyHUD.SetHUD(EnemyUnit);
        PlayerHUD.SetHUD(PlayerUnit);
        yield return new WaitForSeconds(0.5f);
        PlayerTurn();
        State = BattleState.PlayerTurn;
    }
    public IEnumerator PlayerAttack()
    {
        State = BattleState.waiting;
        switchTurnButton();
        bool isDead = EnemyUnit.takeDame(PlayerUnit.Dame);
        EnemyHUD.SetHP(EnemyUnit.currentHP);
        switchTurnButton();
        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            State = BattleState.Won;
            Endbattle();
        }
        else
        {
            State = BattleState.EnemyTurn;
            switchTurnButton();
            StartCoroutine(EnemyTurn());
            
        }
    }
    public IEnumerator EnemyTurn()
    {
       
        DialogText.text = EnemyUnit.Unitname + " Attacks";       
        bool isDead = PlayerUnit.takeDame(EnemyUnit.Dame);
        PlayerHUD.SetHP(PlayerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            State = BattleState.Lost;
        }
        else
        {
            State = BattleState.PlayerTurn;
            switchTurnButton();
            PlayerTurn();
        }
    }
    public IEnumerator Playerheal()
    {
        PlayerUnit.heal(20);
        PlayerHUD.SetHP(PlayerUnit.currentHP);
        DialogText.text = "You feal better now";
        yield return new WaitForSeconds(1f);        
            State = BattleState.EnemyTurn;
            switchTurnButton();
            StartCoroutine(EnemyTurn());
    }
    public void Endbattle ()
    {
        if(State == BattleState.Won)
        {
            DialogText.text = "You Won the battle";
        }
        else if(State == BattleState.Lost)
        {
            DialogText.text = "You Lost the battle";
        }
    }
        
    public void PlayerTurn()
    {
        DialogText.text = "Your Turn,Choose an action:";
    }
    public void OnAttackButton()
    {
        if(State !=  BattleState.PlayerTurn)
        {
            return;
        }
        DialogText.text = PlayerUnit.Unitname + " Attack " + EnemyUnit.Unitname;
        StartCoroutine(PlayerAttack());
    }
    public void OnHealingButton()
    {
        if (State != BattleState.PlayerTurn)
        {
            return;
        }
        
        StartCoroutine(Playerheal());
    }
    public void switchTurnButton()
    {
        if(State == BattleState.PlayerTurn)
        {
            AttackButton.interactable = true;
            healingButton.interactable = true;
        }
        else
        {
            AttackButton.interactable = false;
            healingButton.interactable = false;
        }
    }
        
}
