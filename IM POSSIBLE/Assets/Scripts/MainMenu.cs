using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Button play, quit;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        highScore.text = "" + GameManager.highScore;
        quit.onClick.AddListener(() => Application.Quit());
        play.onClick.AddListener(() => SceneManager.LoadScene("First Level"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
