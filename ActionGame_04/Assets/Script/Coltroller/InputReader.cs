using System;
using UnityEngine;
using UnityEngine.InputSystem;


/*プレイヤーの入力に関する事について書いてる所。*/
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

    //Playerが死亡したときに消すところ
    private void OnDestroy()
    {
        playerInput.Player.Disable();
    }

    //Playerがジャンプするところ
    public void OnJump (InputAction.CallbackContext context)
    {
        if (context.performed) { return; }

        e_JumpEvent?.Invoke();
    }

    //Playerが回避するところ
    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed) { return; }

        e_OnDodge?.Invoke();
    }

    //Playerが移動するところ
    public void OnMove (InputAction.CallbackContext context)
    {
        v2_MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext constext)
    {

    }


    /*
     命名規則

     定数は、　　　スネークケース で定義する。
     変数は、　　　キャメルケース で定義する。
     プロパティは、パスカルケース で定義する。
     メソッド名は、パスカルケース で定義する。
     クラス名は、　パスカルケース で定義する。
     

     フィールドで定義された変数は下記の規則にしたがって変数名を付けること。

     event・・・・・・ e_～～～
     int・・・・・・・ i_～～～
     float・・・・・・ f_～～～
     bool ・・・・・・ b_～～～
     Vector2・・・・・v2_～～～
     Vector3・・・・・v3_～～～
     const・・・・・・全て大文字(単語間はアンダースコアで繋ぐ)

     イベント関数 ・・on～～～()
     
     */

}
