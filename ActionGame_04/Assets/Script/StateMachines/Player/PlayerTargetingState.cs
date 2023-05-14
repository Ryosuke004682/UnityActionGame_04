using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���b�N�I���ƁA���b�N�I�������̎���
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
        
        //���b�N�I�����̈ړ��X�s�[�h�̐ݒ�
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
