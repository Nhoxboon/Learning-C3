using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbtract, IObjAppearObserver
{
    [Header("Without Shoot")]

    [SerializeField] protected ObjAppearing objAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();  //Observer Pattern(ShootableObjectAbtract, ObjAppearWithoutShoot, ObjAppearing)
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }

    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null)
        {
            return;
        }

        this.objAppearing = GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": Load ObjAppearing", gameObject);
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.ShootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.ShootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
    }
}
