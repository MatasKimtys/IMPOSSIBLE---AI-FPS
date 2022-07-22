using System.Collections;
using System.Data;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Timers;
using System.Windows;
using System.Threading;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;
public class Additions : MonoBehaviour
{
    private int counter = 0;
    public Image backgroundImageObject;
    public Sprite normal, normalGlitched, ripped1, ripped1Glitched, ripped2, ripped2Glitched, ripped3, ripped3Glitched;
    int rndNumber;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeBackground", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBackground()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Login Menu"))
        {
            rndNumber = Random.Range(0, 16);
            switch (rndNumber) 
            {
                case 0:
                    backgroundImageObject.sprite = normal;
                    Invoke("ChangeBackground", 3);
                    break;
                case 1:
                    backgroundImageObject.sprite = normalGlitched;
                    Invoke("ChangeBackground", 10 / 18);
                    break;
                case 2:
                    backgroundImageObject.sprite = ripped1;
                    Invoke("ChangeBackground", 10 / 15);
                    break;
                case 3:
                    backgroundImageObject.sprite = ripped1Glitched;
                    Invoke("ChangeBackground", 10 / 3);
                    break;
                case 4:
                    backgroundImageObject.sprite = ripped2;
                    Invoke("ChangeBackground", 10 / 12);
                    break;
                case 5:
                    backgroundImageObject.sprite = ripped2Glitched;
                    Invoke("ChangeBackground", 10 / 30);
                    break;
                case 6:
                    backgroundImageObject.sprite = ripped3;
                    Invoke("ChangeBackground", 10 / 7);
                    break;
                case 7:
                    backgroundImageObject.sprite = ripped3Glitched;
                    Invoke("ChangeBackground", 10 / 39);
                    break;
                case 8:
                    backgroundImageObject.sprite = normal;
                    Invoke("ChangeBackground", 3);
                    break;
                case 9:
                    backgroundImageObject.sprite = normalGlitched;
                    Invoke("ChangeBackground", 10 / 180);
                    break;
                case 10:
                    backgroundImageObject.sprite = ripped1;
                    Invoke("ChangeBackground", 10 / 150);
                    break;
                case 11:
                    backgroundImageObject.sprite = ripped1Glitched;
                    Invoke("ChangeBackground", 10 / 30);
                    break;
                case 12:
                    backgroundImageObject.sprite = ripped2;
                    Invoke("ChangeBackground", 10 / 48);
                    break;
                case 13:
                    backgroundImageObject.sprite = ripped2Glitched;
                    Invoke("ChangeBackground", 10 / 90);
                    break;
                case 14:
                    backgroundImageObject.sprite = ripped3;
                    Invoke("ChangeBackground", 10 / 70);
                    break;
                case 15:
                    backgroundImageObject.sprite = ripped3Glitched;
                    Invoke("ChangeBackground", 10 / 100);
                    break;
            }
            
        }
    }

}
