using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : NhoxMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => this.model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject { get => shootableObject; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null)
        {
            return;
        }

        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null)
        {
            return;
        }

        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        /*Debug.Log(transform.name + ": Load JunkDespawn", gameObject);*/
    }

    protected virtual void LoadJunkSO()
    {
        if (this.shootableObject != null)
        {
            return;
        }

        string resPath = "ShootableObject/Junk/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": Load JunkSO", gameObject);
    }
}
