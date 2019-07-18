using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private void Awake()
    {
        SceneController.Instance.LoadScene("GameScene");
    }
}
