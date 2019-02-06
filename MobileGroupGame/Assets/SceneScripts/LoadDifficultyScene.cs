using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDifficultyScene : MonoBehaviour
{
  
    public void Difficulty()
    {
        SceneManager.LoadScene("DifficultyScene");
    }
}
