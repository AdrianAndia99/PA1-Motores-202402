using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangingScene(string name)
    {
        Debug.Log("asd");
        SceneManager.LoadScene(name);
    }
}