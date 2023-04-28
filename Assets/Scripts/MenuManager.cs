using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public TMP_InputField nickname;
   public GameObject[] check;
   public string nameScene;

    public void SetLevel(string level)//texto del botón
    {
        nameScene = level;
    }

    public void SetCheck(int count)
    {
        for (int i= 0; i < check.Length; i++) {
            check[i].SetActive(false);
        }
        check[count].SetActive(true);
    }

    public void Enter(){//Se verifica si el InputField tiene texto para dar acceso a la otra escena
        if(nickname.text != ""){
            PlayerPrefs.SetString("nickname",nickname.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene(nameScene);
        }else{
            Debug.Log("Ingrese un nombre válido");
        }
   }
}
