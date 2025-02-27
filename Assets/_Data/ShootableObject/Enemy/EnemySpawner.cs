using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null)
        {
            Debug.LogError("ONLY 1 instances of EnemySpawner exist");
        }
        EnemySpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);

        return newEnemy;
    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHPBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHPBar.gameObject.SetActive(true);
    }
}
