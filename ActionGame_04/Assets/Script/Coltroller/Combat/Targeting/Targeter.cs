using Cinemachine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//�����蔻����g���Ĕ�����ɓ����Ă�G���i�[����B
//����̃X�N���v�g�������Ă���G�����m�̑ΏۂƂ���B

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;

    public List<TargetingSystem> targets = new List<TargetingSystem>();

    public TargetingSystem CurrentTarget { get; private set; }

    //�����蔻��̌����ɓ����Ă��Ă��A����̃X�N���v�g�������Ă���G��������List�ɒǉ�����B
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<TargetingSystem>(out TargetingSystem target))
        {
            return;
        }

        targets.Add(target);
        target.OnDestroyed += RemoveTarget;
    }

    //�����蔻��͈̔͊O�܂��͓G�����S���ċ��Ȃ��Ȃ�΁AList����r������B
    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<TargetingSystem>(out TargetingSystem target))
        {
            return;
        }

        RemoveTarget(target);
    }

    //���݂̔z��Ɋi�[����Ă�^�[�Q�b�g���擾����Ƃ���B
    public bool SelectTarget()
    {
        if (targets.Count == 0) { return false; }

        CurrentTarget = targets[0];
        cineTargetGroup.AddMember(CurrentTarget.transform , 1.0f , 2.0f);

        return true;
    }

    //�z��Ɋi�[���ꂽ�w�肳�ꂽ�v�f���폜
    public void Cancel()
    {
        if (CurrentTarget == null) { return; }

        cineTargetGroup.RemoveMember(CurrentTarget.transform);

        CurrentTarget = null;
    }

    //
    private void RemoveTarget(TargetingSystem targetingSystem)
    {
        if(CurrentTarget == targetingSystem)
        {
            cineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        targetingSystem.OnDestroyed -= RemoveTarget;
        targets.Remove(targetingSystem);
    }


}
