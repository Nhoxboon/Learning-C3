using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : NhoxMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null)
        {
            Debug.LogError("Only 1 instance of PlayerCtrl is allowed");
        }

        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + " LoadPlayerPickup", gameObject);
    }
}
