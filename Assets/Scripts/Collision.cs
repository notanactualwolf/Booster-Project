using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Movement movement;
    private void Start()
    {
        movement = FindObjectOfType<Movement>();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("You hit the Start panel");
                break;
            case "Finish":
                Debug.Log("You hit the Finish panel");
                break;
            case "Friendly":
                Debug.Log("You took some Fuel for the road");
                Destroy(collision.gameObject);
                break;
            default:
                LoadLevel(collision);
                break;
        }
    }

    private void LoadLevel(UnityEngine.Collision collision)
    {
        Debug.Log("You hit the " + collision.gameObject.name + ", dipshit");
        movement.dies();
        StartCoroutine(reloadLevel());
    }

    IEnumerator reloadLevel()
    {
        int currentLevel = GameManager.getLevelIndex();
        yield return new WaitForSecondsRealtime(4);
        GameManager.loadLevel(currentLevel);
    }
}
