using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : NhoxMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
        this.LoadSpawner();
        this.LoadDamageReceive();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null)
        {
            return;
        }

        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null)
        {
            return;
        }

        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": Load Spawner", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null)
        {
            return;
        }

        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": Load Despawn", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObject != null)
        {
            return;
        }

        string resPath = "ShootableObject/"+this.GetObjectTypeString()+"/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": Load JunkSO", gameObject);
    }

    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null)
        {
            return;
        }

        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": Load ObjShooting", gameObject);
    }

    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
        Debug.LogWarning(transform.name + ": LoadObjMovement", gameObject);
    }

    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjLookAtTarget", gameObject);
    }

    protected virtual void LoadDamageReceive()
    {
        if (this.damageReceiver != null)
        {
            return;
        }

        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": Load DamageReceiver", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
