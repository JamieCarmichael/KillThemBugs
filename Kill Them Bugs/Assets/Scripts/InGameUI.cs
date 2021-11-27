using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script will display the various items on the In Game UI.
/// </summary>
public class InGameUI : MonoBehaviour
{
    [Tooltip("This is the Text Mesh Pro text field that contains the remaining ammunition in the magazine.")]
    [SerializeField] TextMeshProUGUI currentMagazineText;
    [Tooltip("This is the Text Mesh Pro text field that contains the total ammunition that is not in the magazine.")]
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [Tooltip("This is the image that represents the player health.")]
    [SerializeField] Image healthImage;

    public void SetAmmo(int currentMag, int currentAmmo)
    {
        currentMagazineText.SetText(currentMag.ToString());
        currentAmmoText.SetText(currentAmmo.ToString());
    }

    public void SetHealthImage(float currentHealth, float maxHealth)
    {
        healthImage.fillAmount = currentHealth / maxHealth;
    }
}
