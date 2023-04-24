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
        stateMachine.InputRender.e_JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        f_timer += deltaTime;
        Debug.Log(f_timer);
    }

    public override void Exit()
    {
        stateMachine.InputRender.e_JumpEvent -= OnJump;
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
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
