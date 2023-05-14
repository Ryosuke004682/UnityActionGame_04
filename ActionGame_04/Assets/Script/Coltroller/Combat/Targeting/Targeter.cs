using Cinemachine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//当たり判定を使って判定内に入ってる敵を格納する。
//特定のスクリプトを持っている敵が検知の対象とする。

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;

    public List<TargetingSystem> targets = new List<TargetingSystem>();

    public TargetingSystem CurrentTarget { get; private set; }

    //当たり判定の圏内に入っていてかつ、特定のスクリプトを持っている敵だったらListに追加する。
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<TargetingSystem>(out TargetingSystem target))
        {
            return;
        }

        targets.Add(target);
        target.OnDestroyed += RemoveTarget;
    }

    //当たり判定の範囲外または敵が死亡して居なくなれば、Listから排除する。
    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<TargetingSystem>(out TargetingSystem target))
        {
            return;
        }

        RemoveTarget(target);
    }

    //現在の配列に格納されてるターゲットを取得するところ。
    public bool SelectTarget()
    {
        if (targets.Count == 0) { return false; }

        CurrentTarget = targets[0];
        cineTargetGroup.AddMember(CurrentTarget.transform , 1.0f , 2.0f);

        return true;
    }

    //配列に格納された指定された要素を削除
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
