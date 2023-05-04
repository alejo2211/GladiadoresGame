using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    public CharacterController characterController;
    public PlayerMovement playerMovement;
    public PhotonView photonview;
    public MeshRenderer mesh;
    public GameObject myCamera;
    // Start is called before the first frame update
    void Start()
    {
        if(photonview.IsMine)//Verifica si soy el cliente local
        {
            characterController.enabled = true;
            playerMovement.enabled = true;
            myCamera.SetActive(true);
            mesh.material.color = Color.green;
        }else
        {
            mesh.material.color = Color.red;
        }
    }

 
}
