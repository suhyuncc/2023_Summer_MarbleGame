using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneManager : MonoBehaviour
{
    public void RoomMake()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void RoomIn()
    {
        SceneManager.LoadScene("GameScene");
    }
}
