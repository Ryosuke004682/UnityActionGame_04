using System;
using UnityEngine;
using UnityEngine.InputSystem;


/*プレイヤーの入力に関する事について書いてる所。*/
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

    //Playerが死亡したときに消すところ
    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    //Playerがジャンプするところ
    public void OnJump(InputAction.CallbackContext context)
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


    /*
     命名規則

     定数は、　　　スネークケース で定義する。
     変数は、　　　キャメルケース で定義する。

     プロパティは、パスカルケース で定義する。
     メソッド名は、パスカルケース で定義する。
     クラス名は、　パスカルケース で定義する。
     

     フィールドで定義された変数は下記の規則にしたがって変数名を付けること。
     event・・・・・・e_～～～
     int・・・・・・・i_～～～
     float・・・・・・f_～～～
     bool ・・・・・・b_～～～
     const・・・・・・全て大文字(単語間はアンダースコアで繋ぐ)


     イベント関数 ・・on～～～()
     
     */

}
