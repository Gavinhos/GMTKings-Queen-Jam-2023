using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeGraphics : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OpenGameplayScene);
    }

    private void OpenGameplayScene()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
