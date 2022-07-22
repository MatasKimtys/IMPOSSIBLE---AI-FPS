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


public class Bogging : MonoBehaviour
{
    public Image backgroundImageObject;
    float x = 0;
    float y = 0;
    float z = 0;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = backgroundImageObject.GetComponent<RectTransform>();
        Invoke("rotate1", 1);

    }

    // Update is called once per frame
    void Update()
    {   
        
    }


    void rotate1()
    {
        rectTransform.Rotate(3/2 * Time.deltaTime, 0, 3 / 2 * Time.deltaTime);
        Invoke("rotate2", 1/2);
    }
    void rotate2()
    {
        rectTransform.Rotate(3 / 2 * Time.deltaTime, 0, -3 / 2 * Time.deltaTime);
        Invoke("rotate3", 1 / 2);

    }
    void rotate3()
    {
        rectTransform.Rotate(-3 / 2 * Time.deltaTime, 0, -3 / 2 * Time.deltaTime);
        Invoke("rotate4", 1 / 2);
    }
    void rotate4()
    {
        rectTransform.Rotate(-3 / 2 * Time.deltaTime, 0, 3 / 2 * Time.deltaTime);
        Invoke("rotate1", 1 / 2);
    }
}
