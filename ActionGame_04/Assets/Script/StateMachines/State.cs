using UnityEngine;

public abstract class State
{
    /*Player�̃X�e�[�g���Ǘ�*/
    public abstract void Enter();

    public abstract void Tick(float deltaTime);

    public abstract void Exit();
}
