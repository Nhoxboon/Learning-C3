using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    //[SerializeField] protected bool isReloaded = false;

   private void Update()
    {
        this.IsShooting();
        //this.IsReloaded();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if(!isShooting)
        {
            return;
        }

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay)
        {
            return;
        }
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        //Transform newBullet = Instantiate(this.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null)
        {
            return;
        }
        newBullet.gameObject.SetActive(true);

        //Tranh loi bullet cung tac dong voi Ship(ShipShooting, BulletImpact, BulletCtrl)
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }

    
   /* protected virtual bool IsReloaded()
    {
        this.isReloaded = shootTimer >= shootDelay;
        if (this.shootTimer < shootDelay) this.shootTimer += Time.deltaTime;
        return this.isReloaded;
    }*/
}
