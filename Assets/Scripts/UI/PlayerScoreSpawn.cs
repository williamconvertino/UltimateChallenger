//using System;
//using System.Collections;
//using TMPro;
//using UnityEditor.VersionControl;
//using UnityEngine;

//public class PlayerScoreSpawn : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public GameObject playerScore;

//    public void SpawnNewPlayerScore(int numPlayers)
//    {
//        Vector3 spawnPosition = new Vector3(0, 0, 0);

//        Vector3 spawnPositionDown = transform.position + Vector3.down * Random.Range(distanceMin, distanceMax);
//        Vector3 spawnPositionUp = transform.position + Vector3.up * Random.Range(distanceMin, distanceMax);
//        spawnPositionDown.z = 0;
//        spawnPositionDown.y = Random.Range(-5, -8);
//        spawnPositionUp.z = 0;
//        spawnPositionUp.y = Random.Range(4, 8);
//        Instantiate(playerScore, spawnPositionDown, Quaternion.identity);
//    }

//}
