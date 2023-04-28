using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public string sceneNameToChange;
    private GameObject spawnerPlayerPrefrab;

    void Start()
    {
        ConnectedToServer();
    }

    void ConnectedToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Arena", roomOptions, TypedLobby.Default);//Se usa para sincronizar los jugadores en la sala

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined on room.");
        base.OnJoinedRoom();
        switch (SceneManager.GetActiveScene().name)
        {
            case "roma"://Verifica el nombre de la escena de juego
                GameObject[] spawns = GameObject.FindGameObjectsWithTag("spawn");
                int ran = UnityEngine.Random.Range(0, spawns.Length);
                Vector3 posToSet = spawns[ran].transform.position;//posición inicial del jugador
                spawnerPlayerPrefrab = PhotonNetwork.Instantiate("Player", posToSet, transform.rotation);//verifica el objeto jugador
                break;
        }

    }
   /* public override void OnMasterClientSwitched(Player newMasterClient)
    {
        sceneNameToChange = "Menu";
        ChangeRoom();
    }*/

    public void ChangeRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        Debug.Log("Left room");
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnerPlayerPrefrab);
        PhotonNetwork.Disconnect();
        ChangeScene();
    }
    void ChangeScene()
    {
        PhotonNetwork.LoadLevel(sceneNameToChange);
    }
}
