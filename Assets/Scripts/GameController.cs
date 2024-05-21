using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject victoryDialog;
    [SerializeField] private GameObject gameOverDialog;
    [SerializeField] private Text pointsText;
    
    
    private CutsceneManager manager;
    private float points = 0f;
    
    
    
    void Start()
    {
        manager = GetComponent<CutsceneManager>();
        manager.PlayFirstScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFirstCutSceneEnd()
    {
        manager.OnFirstCutSceneEnd();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        GetComponent<SpriteRenderer>().enabled = false;
        gameOverDialog.SetActive(true);
    }

    public void OnLevelFinished()
    {
        Time.timeScale = 0f;
        victoryDialog.gameObject.SetActive(true);
    }

    public void AddPoint(float added)
    {
        points += added;
        UpdatePointText();
    }

    private void UpdatePointText()
    {
        pointsText.text = "Очки: " + points;
    }
}
