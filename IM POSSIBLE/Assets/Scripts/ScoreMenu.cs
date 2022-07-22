using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ScoreMenu : MonoBehaviour
{
    public Button play, quit;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        score.text = "" + GameManager.round;
        play.onClick.AddListener(() => SceneManager.LoadScene("First Level"));
        quit.onClick.AddListener(() => SceneManager.LoadScene("Login Menu"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
