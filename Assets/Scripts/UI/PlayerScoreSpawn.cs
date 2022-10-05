using System;
using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerScoreSpawn : MonoBehaviour
{
    public GameObject playerScore;


    public void Start()
    {
        Vector3 spawnPositionOrigin = new Vector3(0, 0, 0);
        Instantiate(playerScore, spawnPositionOrigin, Quaternion.identity);
 
    }

}
