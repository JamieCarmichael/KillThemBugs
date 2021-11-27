using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] CheckPoint[] checkPoints;
    [SerializeField] GameObject player;
    int currentRespawnPoint;

    private void Awake()
    {
        currentRespawnPoint = PlayerPrefs.GetInt("LastCheckpoint", 0);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = checkPoints[currentRespawnPoint].transform.position;
        player.transform.rotation = checkPoints[currentRespawnPoint].transform.rotation;
        player.GetComponent<PlayerStats>().ResetHealth();
        player.GetComponent<GunManager>().ResetAllGuns();
        player.GetComponent<CharacterController>().enabled = true;

        DisableCheckpoints();
    }

    public void SetCheckPoint(CheckPoint RP)
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (RP == checkPoints[i])
            {
                PlayerPrefs.SetInt("LastCheckpoint", i);
            }
        }
    }
    private void DisableCheckpoints()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (i < currentRespawnPoint)
            {
                checkPoints[i].gameObject.SetActive(false);
            }

        }
    }
}
