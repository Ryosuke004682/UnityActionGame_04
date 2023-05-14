using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion , float deltaTime)
    {
        stateMachine.Controller.Move
            ((motion + stateMachine.ForceReceiver.Movement)* deltaTime);
    }

    protected void FaceTarget()
    {
        if(stateMachine.Target.CurrentTarget == null)
        {
            return;
        }

        Vector3 lookPos = stateMachine.Target.CurrentTarget.transform.position 
                                             - stateMachine.transform.position;
        lookPos.y = 0.0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);

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
