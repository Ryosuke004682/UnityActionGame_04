using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerState : PlayerBaseState
{

    //滑らかに値を遷移させたいので、線形補完する変数を定義しておく
    private float f_idleSpeed   =  0.0f;
    private float f_walkSpeed   =  2.0f;
    private float f_runSpeed    =  5.0f;
    private float f_fierceSpeed = 10.0f;
    private float f_smoothTime  =  0.1f;

    private float f_timer;

    //処理を軽くするために、Hash値に変換して定数化させとく
    private readonly int FREELOOKSPEED_HASH 
                   = Animator.StringToHash("FreeLookSpeed");

    private readonly int FREELOOK_BLENDTREE_HASH
                   = Animator.StringToHash("FreeLookBlendTree");



    public PlayerState(PlayerStateMachine testMachine)
                                   : base(testMachine){ }


    public override void Enter()
    {
        stateMachine.InputRender.e_TargetEvent += OnTarget ;

        stateMachine.Animator.Play(FREELOOK_BLENDTREE_HASH);
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();


        Move(movement * stateMachine.MovementSpeed , deltaTime);
        

        if (stateMachine.InputRender.v2_MovementValue == Vector2.zero)
        {
            //TODO : SetFloatのダンピングの時間をLerp関数を使って滑らかに表現したい。
            //(マジックナンバーを撲滅したい)
            stateMachine.Animator.SetFloat(FREELOOKSPEED_HASH, f_idleSpeed, 0.1f , deltaTime);
            return;
        }

        f_smoothTime         = Mathf.Lerp(f_smoothTime , 1.0f , 0.7f);
        var currentWalkSpeed = Mathf.Lerp(f_idleSpeed  , f_walkSpeed , f_smoothTime);

        stateMachine.Animator.SetFloat(FREELOOKSPEED_HASH, f_runSpeed, 0.1f , deltaTime);

        FaceMovementDirection(movement , deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputRender.e_TargetEvent -= OnTarget;
    }

    private void OnTarget()
    {
        if(!stateMachine.Target.SelectTarget())
        {
            return;
        }

        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }


    //プレイヤーの移動処理
    //カメラの相対移動
    private Vector3 CalculateMovement()
    {
        var forward = stateMachine.MainCameraTransform.forward;
        var right   = stateMachine.MainCameraTransform.right  ;

        forward.y = 0;
        right  .y = 0;

        forward.Normalize();
        right  .Normalize();

        return forward * stateMachine.InputRender.v2_MovementValue.y +
               right   * stateMachine.InputRender.v2_MovementValue.x  ;
    }


    private void FaceMovementDirection(Vector3 movement , float deltaTime)
    {
        //滑らかな回転をさせたいのでQuaternion.Lerpを使う

        stateMachine.transform.rotation = Quaternion.Lerp
                            (stateMachine.transform.rotation,
                            Quaternion.LookRotation(movement),
                            deltaTime * stateMachine.RotationDampSpeed);

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
