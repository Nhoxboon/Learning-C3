using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : NhoxMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomLimit = 9f;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if(this.spawnerCtrl != null)
        {
            return;
        }
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ": Load SpawnerCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {

        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if(this.RandomReachLimit())
        {
            return;
        }
        
        this.randomTimer += Time.fixedDeltaTime;
        if(this.randomTimer < this.randomDelay)
        {
            return;
        }
        this.randomTimer = 0;

        Transform ranPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnerCtrl.Spawner.RandomPrefab();
        Transform obj = this.spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnerCtrl.Spawner.SpawnerCount;
        return currentJunk >= this.randomLimit;
    }
}
