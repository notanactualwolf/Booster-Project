using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static void loadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static int getLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
