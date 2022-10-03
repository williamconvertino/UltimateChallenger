using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject sharedObject;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(sharedObject.name, Vector3.zero, Quaternion.identity);
    }

}
