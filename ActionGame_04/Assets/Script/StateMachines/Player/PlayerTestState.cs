using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTestState : PlayerBaseState
{

    [SerializeField] private float timer = 5.0f;



    public PlayerTestState(PlayerStateMachine testMachine)
                                       : base(testMachine)
    { }


    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;
        Debug.Log(timer);

        if(timer <= 0.0f)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }

}
