using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateMachine : MonoBehaviour
{
    public BaseEnemy enemy;
    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }
    public TurnState CurrentState;
    private float Curr_coolDown = 0f;
    private float Max_CoolDown = 5f;

    void Start()
    {
        CurrentState = TurnState.PROCESSING;
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeProgesBar();

        switch (CurrentState)
        {
            case (TurnState.PROCESSING):

                break;

            case (TurnState.ADDTOLIST):
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
    void UpgradeProgesBar()
    {

        Curr_coolDown = Curr_coolDown + Time.deltaTime;

        if (Curr_coolDown >= Max_CoolDown)
        {
            CurrentState = TurnState.ADDTOLIST;
            Debug.Log(CurrentState.ToString());
        }
    }
}
