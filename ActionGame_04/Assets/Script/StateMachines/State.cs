using UnityEngine;

public abstract class State
{
    /*Playerのステートを管理*/
    public abstract void Enter();

    public abstract void Tick(float deltaTime);

    public abstract void Exit();
}
