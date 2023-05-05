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

    //�v���C���[�̈ړ�����
    //�J�����̑��Έړ�
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
    �����K��

    �萔�́A�@�@�@�X�l�[�N�P�[�X �Œ�`����B
    �ϐ��́A�@�@�@�L�������P�[�X �Œ�`����B

    �v���p�e�B�́A�p�X�J���P�[�X �Œ�`����B
    ���\�b�h���́A�p�X�J���P�[�X �Œ�`����B
    �N���X���́A�@�p�X�J���P�[�X �Œ�`����B


    �t�B�[���h�Œ�`���ꂽ�ϐ��͉��L�̋K���ɂ��������ĕϐ�����t���邱�ƁB
    event�E�E�E�E�E�Ee_�`�`�`
    int�E�E�E�E�E�E�Ei_�`�`�`
    float�E�E�E�E�E�Ef_�`�`�`
    bool �E�E�E�E�E�Eb_�`�`�`
    const�E�E�E�E�E�E�S�đ啶��(�P��Ԃ̓A���_�[�X�R�A�Ōq��)

    ���[�J���͓��ɋK��͖����B


    �C�x���g�֐� �E�Eon�`�`�`()

    */


}
