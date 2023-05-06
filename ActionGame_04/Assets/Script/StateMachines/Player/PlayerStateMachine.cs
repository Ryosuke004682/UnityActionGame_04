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
