using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTestState : PlayerBaseState
{

    private float f_timer;

    public PlayerTestState(PlayerStateMachine testMachine)
                                       : base(testMachine)
    { }


    public override void Enter()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.Controller.Move(movement * stateMachine.MovementSpeed * deltaTime);

        if (stateMachine.InputRender.v2_MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat("FreeLookSpeed", 0.0f , 0.1f , deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat("FreeLookSpeed", 2.0f , 0.1f , deltaTime);

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }

    public override void Exit()
    {
        
    }

    //プレイヤーの移動処理
    //カメラの相対移動
    private Vector3 CalculateMovement()
    {
        var forward = stateMachine.MainCameraTransform.forward;
        var right   = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right  .y = 0;

        forward.Normalize();
        right  .Normalize();

        return forward * stateMachine.InputRender.v2_MovementValue.y +
               right   * stateMachine.InputRender.v2_MovementValue.x  ;
    }

    /*
    命名規則

    定数は、　　　スネークケース で定義する。
    変数は、　　　キャメルケース で定義する。

    プロパティは、パスカルケース で定義する。
    メソッド名は、パスカルケース で定義する。
    クラス名は、　パスカルケース で定義する。


    フィールドで定義された変数は下記の規則にしたがって変数名を付けること。
    event・・・・・・e_～～～
    int・・・・・・・i_～～～
    float・・・・・・f_～～～
    bool ・・・・・・b_～～～
    const・・・・・・全て大文字(単語間はアンダースコアで繋ぐ)

    ローカルは特に規定は無し。


    イベント関数 ・・on～～～()

    */


}
