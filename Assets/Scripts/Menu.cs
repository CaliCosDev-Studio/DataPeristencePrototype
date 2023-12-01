using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_Text input;
    [SerializeField] GameObject usernameError;
    [SerializeField] TMP_Text bestPlayer;

    string username;

    public void StartGame()
    {
        username = input.text;
        username = username.Trim();

        if (username.Length > 1)
        {
            Manager.instance.username = username;
            SceneManager.LoadScene(1);
        }
        else
        {
            usernameError.SetActive(true);
        }
    }

    public void ShowBestPlayer(string username, int bestScore)
    {
        bestPlayer.gameObject.SetActive(true);
        bestPlayer.text = "BEST PLAYER: " + username + "\nSCORE: " + bestScore;
    }

    public void DeleteBestScore()
    {
        Manager.instance.DeleteSaveFile();
        SceneManager.LoadScene(0);
    }
}
