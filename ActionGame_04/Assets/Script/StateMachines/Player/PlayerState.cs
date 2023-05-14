using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerState : PlayerBaseState
{

    //���炩�ɒl��J�ڂ��������̂ŁA���`�⊮����ϐ����`���Ă���
    private float f_idleSpeed   =  0.0f;
    private float f_walkSpeed   =  2.0f;
    private float f_runSpeed    =  5.0f;
    private float f_fierceSpeed = 10.0f;
    private float f_smoothTime  =  0.1f;

    private float f_timer;

    //�������y�����邽�߂ɁAHash�l�ɕϊ����Ē萔�������Ƃ�
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
            //TODO : SetFloat�̃_���s���O�̎��Ԃ�Lerp�֐����g���Ċ��炩�ɕ\���������B
            //(�}�W�b�N�i���o�[��o�ł�����)
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


    //�v���C���[�̈ړ�����
    //�J�����̑��Έړ�
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
        //���炩�ȉ�]�����������̂�Quaternion.Lerp���g��

        stateMachine.transform.rotation = Quaternion.Lerp
                            (stateMachine.transform.rotation,
                            Quaternion.LookRotation(movement),
                            deltaTime * stateMachine.RotationDampSpeed);

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
