using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;

public class HostAndJoin : MonoBehaviourPunCallbacks
{
    public InputField hostField;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(hostField.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(hostField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
