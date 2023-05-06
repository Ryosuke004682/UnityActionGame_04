using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputRender 
    { get; private set; }

    [field: SerializeField] public CharacterController Controller
    { get; private set; }

    [field: SerializeField] public Animator Animator
    { get; private set; }

    [field: SerializeField] public float MovementSpeed
    { get; private set; }

    [field: SerializeField] public float RotationDampSpeed
    { get; private set; }


    public Transform MainCameraTransform { get; private set; }


    private void Start()
    {
        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerState(this));
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
