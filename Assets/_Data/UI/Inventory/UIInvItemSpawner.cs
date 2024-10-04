using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;

    public static string normalItem = "UIInvItem";

    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl InventoryCtrl => inventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if(UIInvItemSpawner.instance != null)
        {
            Debug.LogError("Only 1 UIInvItemsSpawner allow to exist!");
        }

        UIInvItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();

        if (this.holder != null) return;
        this.holder = this.inventoryCtrl.Content;
        Debug.Log(transform.name + ": Load Holder", gameObject);
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null)
        {
            return;
        }
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": Load UIInventoryCtrl", gameObject);
    }

}
