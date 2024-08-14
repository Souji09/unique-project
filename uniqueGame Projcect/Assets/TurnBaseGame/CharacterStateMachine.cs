using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStateMachine : MonoBehaviour
{
    public BaseCharacterStatus character;
    public enum TurnState
    {
        PROCESSING,
        START,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }
    public TurnState currState;
    public Slider HP_Bar;
    public Slider Action_Bar;
    private float coolDown = 0f;
    private float Max_coolDown = 4f;
    private void Start()
    {
        currState= TurnState.PROCESSING;
    }
    private void Update()
    {
        UpdateBar();
        switch(currState)
        {
            case (TurnState.PROCESSING):
                break;
            case (TurnState.START):
                break;
            case (TurnState.WAITING):
                break;
            case (TurnState.SELECTING):
                break;
            case (TurnState.ACTION):
                break;
            case (TurnState.DEAD):
                break;

        }
    }
    public void UpdateBar()
    {
        coolDown = coolDown + Time.deltaTime;
        float CalAction_Bar = coolDown / Max_coolDown;
        Action_Bar.value = CalAction_Bar;
        if(coolDown == Max_coolDown)
        {
           currState = TurnState.ACTION;
        }
        if(character != null)
        {
            float CAl_HPBar = character.curr_HP / character.Max_HP;
            HP_Bar.value = CAl_HPBar;
        }
        
    }
}
