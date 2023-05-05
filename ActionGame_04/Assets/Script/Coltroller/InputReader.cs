using System;
using UnityEngine;
using UnityEngine.InputSystem;


/*�v���C���[�̓��͂Ɋւ��鎖�ɂ��ď����Ă鏊�B*/
public class InputReader : MonoBehaviour,PlayerInputAction.IPlayerActions
{
    public       Vector2 v2_MovementValue { get; private set; }


    public event Action e_JumpEvent;
    public event Action e_OnDodge  ;


    private      PlayerInputAction playerInput;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerInput = new PlayerInputAction();
        playerInput.Player.SetCallbacks(this);

        playerInput.Player.Enable();
    }

    //Player�����S�����Ƃ��ɏ����Ƃ���
    private void OnDestroy()
    {
        playerInput.Player.Disable();
    }

    //Player���W�����v����Ƃ���
    public void OnJump (InputAction.CallbackContext context)
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

    //Player���ړ�����Ƃ���
    public void OnMove (InputAction.CallbackContext context)
    {
        v2_MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext constext)
    {

    }


    /*
     �����K��

     �萔�́A�@�@�@�X�l�[�N�P�[�X �Œ�`����B
     �ϐ��́A�@�@�@�L�������P�[�X �Œ�`����B
     �v���p�e�B�́A�p�X�J���P�[�X �Œ�`����B
     ���\�b�h���́A�p�X�J���P�[�X �Œ�`����B
     �N���X���́A�@�p�X�J���P�[�X �Œ�`����B
     

     �t�B�[���h�Œ�`���ꂽ�ϐ��͉��L�̋K���ɂ��������ĕϐ�����t���邱�ƁB

     event�E�E�E�E�E�E e_�`�`�`
     int�E�E�E�E�E�E�E i_�`�`�`
     float�E�E�E�E�E�E f_�`�`�`
     bool �E�E�E�E�E�E b_�`�`�`
     Vector2�E�E�E�E�Ev2_�`�`�`
     Vector3�E�E�E�E�Ev3_�`�`�`
     const�E�E�E�E�E�E�S�đ啶��(�P��Ԃ̓A���_�[�X�R�A�Ōq��)

     �C�x���g�֐� �E�Eon�`�`�`()
     
     */

}
