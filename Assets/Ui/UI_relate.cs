using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_relate : MonoBehaviour
{
    public GameObject Staff;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void Click_Start()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Click_exit()
    {
        Application.Quit();
    }

    public void Click_staff()
    {
        Staff.SetActive(true);
    }

    public void Back_staff()
    {
        Staff.SetActive(false);
    }

}
