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


    �C�x���g�֐� �E�Eon�`�`�`()

    */


}
