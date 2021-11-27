using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details:This script is placed on an ammo pick up and adds ammo to the players stockpile.
/// </summary>
public class AmmoPickUp : MonoBehaviour
{
    [Tooltip("This is the gun that the ammo is added to.")]
    [SerializeField] GunName gunName;
    [Tooltip("This is the amount of ammo added.")]
    [SerializeField] int amountOfAmmo = 10;

    public enum GunName
    {
        pistol,assultRifle,grenadeLauncher
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<GunManager>(out GunManager gunManager))
        {
            switch (gunName)
            {
                case GunName.pistol:
                    gunManager.increaseAmmo(amountOfAmmo, 0);
                    break;
                case GunName.assultRifle:
                    gunManager.increaseAmmo(amountOfAmmo, 1);
                    break;
                case GunName.grenadeLauncher:
                    gunManager.increaseAmmo(amountOfAmmo, 2);
                    break;
                default:
                    break;
            }
            Destroy(this.transform.parent.gameObject);
        }
    }
}
