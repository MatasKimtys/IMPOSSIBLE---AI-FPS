using System.Collections;
using System.Data;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Timers;
using System.Windows;
using System.Threading;
using System.IO;
using UnityEditor;
using MySql.Data;
using MySql.Data.MySqlClient;


//using MySqlConnector;

public class LoginMenu : MonoBehaviour
{
    public Button login;
    public InputField UsernameField;
    public InputField PasswordField;

    MySqlConnection connection = new MySqlConnection();
    string connectionString = "SERVER=dragon.kent.ac.uk;DATABASE=mk750;User ID=mk750;Password=wa*rexa;CharSet=utf8;pooling=false";

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //highScore.text = "" + GameManager.highScore;
        login.onClick.AddListener(() => LogIn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LogIn()
    {
        login.GetComponentInChildren<Text>().text = "Attempting login";
        if (UsernameField.text.ToString() != "" && PasswordField.text.ToString() != "")
        {
            Invoke("ConnectToDatabase", 1);
        }
        else
        {
            EmptyFields();
            Invoke("BackToNormal", 1);
        }
    }

    public void ConnectToDatabase()
    {
        bool exists = false;
        bool badLogin = false;
        int countOutput = 0;
        string usernameOutput = "";
        string passwordOutput = "";
        connection.ConnectionString = connectionString;
        using (connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            connection.Open();
            login.GetComponentInChildren<Text>().text = "Opened";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Username, Password FROM PlayerCredentials;"; // WHERE Username= '" + UsernameField.text + "'
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countOutput++;
                        usernameOutput = reader.GetString(0); // reader.GetInt32(0).ToString()  + reader.GetString(2)
                        passwordOutput = reader.GetString(1);
                        if (UsernameField.text == usernameOutput && PasswordField.text == passwordOutput)
                        {
                            Debug.Log("User match");
                            exists = true;
                            badLogin = false;
                            SceneManager.LoadScene("Main Menu");
                            reader.Close();
                            break;
                        }
                        else if (UsernameField.text == usernameOutput && PasswordField.text != passwordOutput)
                        {
                            badLogin = true;
                            login.GetComponentInChildren<Text>().text = "Incorrect Password";
                            Invoke("BackToNormal", 1);
                            break;
                        }
                        else
                        {
                            exists = false;
                            badLogin = false;
                        }
                    }
                    reader.Close();
                }
                Debug.Log(countOutput);
            }
            connection.Close();
        }
        if (exists == false && badLogin == false && UsernameField.text != usernameOutput)
        {
            countOutput++;
            using (connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO PlayerCredentials(PlayerNo, Username, Password) VALUES(" + countOutput + ",'" + UsernameField.text + "','" + PasswordField.text + "')";
                cmd.ExecuteNonQuery();
                Invoke("UserCreated", 2);
                Invoke("", 2);
                SceneManager.LoadScene("Main Menu");
            }
            connection.Close();
        }
    }

    public void EmptyFields()
    {
        login.GetComponentInChildren<Text>().text = "Can't be empty";
    }

    public void UserCreated()
    {
        login.GetComponentInChildren<Text>().text = "User Created";
    }

    public void BackToNormal()
    {
        login.GetComponentInChildren<Text>().text = "Login";
    }

    public void IncorrectPassword()
    {
        login.GetComponentInChildren<Text>().text = "Invalid Password";
    }
}
