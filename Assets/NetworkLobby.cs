using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkLobby : MonoBehaviourPunCallbacks
{
    public Color playerColor;
    public GameObject playerObject;
    private List<GameObject> playerList;
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    private void UpdatePlayers()
    {
        playerList.Clear();
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            
        }
    }
}

