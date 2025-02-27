using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectAbtract : NhoxMonoBehaviour
{

    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null)
        {
            return;
        }

        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": Load ShootableObjectCtrl", gameObject);
    }

}
