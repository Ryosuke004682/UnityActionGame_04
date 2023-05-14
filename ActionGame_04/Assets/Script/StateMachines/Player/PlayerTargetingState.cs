using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ロックオンと、ロックオン解除の実装
public class PlayerTargetingState : PlayerBaseState
{

    private readonly int TARGETING_BLENDTREE_HASH
                   = Animator.StringToHash("TargetingBlendTree");

    public PlayerTargetingState(PlayerStateMachine stateMachine) 
                                            : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.InputRender.e_CancelTargetEvent += OnTargetCancel;
        stateMachine.Animator   .Play(TARGETING_BLENDTREE_HASH);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.Target.CurrentTarget == null)
        {
            stateMachine.SwitchState(new PlayerState(stateMachine));
            return;
        }

        Vector3 movement = CalculateMovement();
        
        //ロックオン中の移動スピードの設定
        Move   (movement * stateMachine.TargetingMovementSpeed , deltaTime);

        FaceTarget();
    }

    public override void Exit()
    {
        stateMachine.InputRender.e_CancelTargetEvent -= OnTargetCancel;
    }

    private void OnTargetCancel()
    {
        stateMachine.Target.Cancel();

        stateMachine.SwitchState(new PlayerState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3();

        movement += stateMachine.transform.right   * stateMachine.InputRender.v2_MovementValue.x;
        movement += stateMachine.transform.forward * stateMachine.InputRender.v2_MovementValue.y;

        return movement;
    }

}
