using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script contains a method that will spawn bullets for a gun.
/// </summary>
public class Gun : MonoBehaviour
{
    [Tooltip("This is the bullet that is created.")]
    [SerializeField] GameObject bulletCreated;
    [Tooltip("This is the loaction that the bullet spawns at. This should be an object at the end of the barrel.")]
    [SerializeField] Transform bulletSpawnLocation;
    [Tooltip("This is an object that will be the bullets parent. This needs to be a stationary object not attacked to the player. It is just to keep the hierarchy clean.")]
    [SerializeField] Transform bulletParent;
    [Tooltip("This is the time between bullets being able to fire.")]
    [SerializeField] float rateOfFire = 0.25f;
    [Tooltip("This is the distance checked for something to aim at. It corrects the bullets aim so the bullets hit the crosshair.")]
    [SerializeField] float maxAimDistance = 100.0f;
    [Tooltip("This is the layer mask for checking what objects can be hit. Should be made to everything.")]
    [SerializeField] LayerMask layerToHit;
    [Tooltip("If this is true the gun will continue to fire if the fire button is held down.")]
    [SerializeField] bool isFullAuto;
    [Tooltip("This the the size of a magazine. It represents the maximum number of shots before having to reload.")]
    [SerializeField] int maxAmmoInMagazine = 20;
    [Tooltip("This is the maximum amount of ammunition that can be carried not including the ammunition in the magzine.")]
    [SerializeField] int maxAmmoToCarry = 100;
    [Tooltip("This the amount of ammunition not in the magazine that the player starts with for this gun.")]
    [SerializeField] int startingAmmo = 70;
    [Tooltip("This is the animator for this weapon. This should be on the weapon.")]
    [SerializeField] Animator thisAnimator;
    [Tooltip("This is the name of the bool that trigger the shooting animation.")]
    [SerializeField] string animationShoot = "Shoot";
    [Tooltip("This is the name of the bool that triggers the reloading animation.")]
    [SerializeField] string animationReload = "Reload";
    [Tooltip("This is the In Game UI script. It should be on the UI script holder. There should only be one in the scene.")]
    [SerializeField] InGameUI inGameUI;

    [SerializeField] AudioSource shootingSound;
    [SerializeField] AudioSource reloadingSound;

    private int currentAmmoInMagazine;
    private int currentAmmoToCarry = 100;
    private bool reloading = false;


    private float timeToFire;

    public int MaxAmmoInMagazine
    {
        get { return maxAmmoInMagazine;}
    }
    public int MaxAmmoToCarry
    {
        get { return maxAmmoToCarry; }
    }
    public int CurrentAmmoInMagazine
    {
        get { return currentAmmoInMagazine; }
        set 
        { 
            currentAmmoInMagazine = value;
            SetUI();
        }
    }
    public int CurrentAmmoToCarry
    {
        get { return currentAmmoToCarry; }
        set 
        {
            currentAmmoToCarry = value;
            currentAmmoToCarry = Mathf.Clamp(currentAmmoToCarry, 0, maxAmmoToCarry);
            SetUI();
        }
    }
    public bool IsFullAuto
    {
        get { return isFullAuto; }
        set { isFullAuto = value; }
    }

    private void Start()
    {
        currentAmmoToCarry = startingAmmo;
        currentAmmoInMagazine = maxAmmoInMagazine;
        SetUI();
    }

    private void OnEnable()
    {
        reloading = false;
        SetUI();
    }

    public void ShootGun()
    {
        if (Time.time > timeToFire && !reloading)
        {
            if (currentAmmoInMagazine == 0)
            {
                StartCoroutine(Reload());
            }
            else
            {
                shootingSound.Play();

                thisAnimator.SetBool(animationShoot, true);
                CurrentAmmoInMagazine--;
                timeToFire = Time.time + rateOfFire;
                RaycastHit hit;
                Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxAimDistance, layerToHit, QueryTriggerInteraction.Ignore);


                if (hit.point != Vector3.zero)
                {
                    bulletSpawnLocation.transform.LookAt(hit.point);
                }
                else
                {
                    bulletSpawnLocation.transform.LookAt(bulletSpawnLocation.position + Camera.main.transform.forward * maxAimDistance);
                }
                GameObject newBullet = Instantiate(bulletCreated, bulletSpawnLocation.position, bulletSpawnLocation.transform.rotation, bulletParent);


                //GameObject newBullet = Instantiate(bulletCreated, bulletSpawnLocation);
                //newBullet.transform.parent = bulletParent;
                //if (hit.point != Vector3.zero)
                //{
                //    newBullet.transform.LookAt(hit.point);
                //    newBullet.transform.forward = hit.point - bulletSpawnLocation.transform.position;
                //}
                //else
                //{
                //    newBullet.transform.LookAt(bulletSpawnLocation.position + Camera.main.transform.forward * maxAimDistance);
                //}
            }
        }
    }

    public IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForEndOfFrame();
        reloadingSound.Play();
        if (currentAmmoToCarry == -1)
        {
            CurrentAmmoInMagazine = maxAmmoInMagazine;
        }
        else if (currentAmmoToCarry == 0)
        {
        }
        else
        {
            int reloadedBullets = maxAmmoInMagazine - currentAmmoInMagazine;
            if (reloadedBullets > currentAmmoToCarry)
            {
                CurrentAmmoInMagazine += currentAmmoToCarry;
                CurrentAmmoToCarry = 0;
            }
            else
            {
                CurrentAmmoInMagazine = maxAmmoInMagazine;
                CurrentAmmoToCarry -= reloadedBullets;
            }
        }
        thisAnimator.SetBool(animationReload, true);
    }

    public void StopReloading()
    {
        thisAnimator.SetBool(animationReload, false);
        reloading = false;
    }
    public void StopShooting()
    {
        thisAnimator.SetBool(animationShoot, false);
        reloading = false;
    }

    public void SetUI()
    {
        if (this.gameObject.activeInHierarchy)
        {
            inGameUI.SetAmmo(currentAmmoInMagazine, currentAmmoToCarry);
        }
    }
    public void ResetAmmo()
    {
        currentAmmoInMagazine = maxAmmoInMagazine;
        currentAmmoToCarry = startingAmmo;
    }
}
