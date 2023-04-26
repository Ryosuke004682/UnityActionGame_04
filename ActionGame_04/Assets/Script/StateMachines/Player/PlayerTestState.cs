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
        Vector3 movement = new Vector3();

        //プレイヤーの移動処理
        movement.x = stateMachine.InputRender.v2_MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputRender.v2_MovementValue.y;

        stateMachine.Controller.Move(movement * stateMachine.MovementSpeed * deltaTime);

        if (stateMachine.InputRender.v2_MovementValue == Vector2.zero) { return; }

        stateMachine.transform.rotation = Quaternion.LookRotation(new Vector3(-movement.z , movement.y , movement.x));
    }

    public override void Exit()
    {
        
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


    イベント関数 ・・on～～～()

    */


}
