using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hub: MonoBehaviour
{
    public void MoveToScene(string Game)
    {
        SceneManager.LoadScene(Game);
    }
}
