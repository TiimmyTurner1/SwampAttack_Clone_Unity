using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedPanel : MonoBehaviour
{    
    public void ActivatePanel()
    {
        gameObject.SetActive(true);
    }

    public void RestartButtonClick()
    {        
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
    }
}
