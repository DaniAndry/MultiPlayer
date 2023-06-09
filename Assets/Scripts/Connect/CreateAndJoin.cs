using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public InputField CreatedInput;
    public InputField JoinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreatedInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
