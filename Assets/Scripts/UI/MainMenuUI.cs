using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake() {
        playButton.onClick.AddListener( () => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
        quitButton.onClick.AddListener( () => {
            Application.Quit();
            Debug.Log("Application Quit!");
        }); 
    }

}
