using System;
using UnityEngine;
using UnityEngine.InputSystem;


/*�v���C���[�̓��͂Ɋւ��鎖�ɂ��ď����Ă鏊�B*/
public class InputReader : MonoBehaviour,Controls.IPlayerActions
{
    public event Action e_JumpEvent;
    public event Action e_OnDodge  ;




    private      Controls controls;


    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    //Player�����S�����Ƃ��ɏ����Ƃ���
    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    //Player���W�����v����Ƃ���
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) { return; }

        e_JumpEvent?.Invoke();
    }

    //Player���������Ƃ���
    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed) { return; }

        e_OnDodge?.Invoke();
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
