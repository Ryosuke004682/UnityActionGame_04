using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
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
