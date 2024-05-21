using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public Canvas levelsCanvas;

    public void ShowLevelCanvas()
    {
        GameObject.Find("StartCanvas").gameObject.SetActive(false);
        levelsCanvas.gameObject.SetActive(true);
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
    
    public void StartLevel2()
    {
        SceneManager.LoadScene("Scenes/Level2");
    } 
    
    public void StartLevel3()
    {
        SceneManager.LoadScene("Scenes/Level3");
    }
    
    public void StartLevel4()
    {
        SceneManager.LoadScene("Scenes/Level4");
    }
    
    public void StartLevel5()
    {
        SceneManager.LoadScene("Scenes/Level5");
    }
    
}
