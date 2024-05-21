using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{

    [SerializeField] private Canvas _canvas;
    [SerializeField] private CinemachineVirtualCamera defaultCam;
    [SerializeField] private CinemachineVirtualCamera custsceneCam;
    
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFirstScene()
    {
        GetComponent<PlayerController>().enabled = false;
        _canvas.gameObject.SetActive(true);
        
        defaultCam.Priority = 0;
        custsceneCam.Priority = 1;
    }

    public void OnFirstCutSceneEnd()
    {
        GetComponent<PlayerController>().enabled = true;
        _canvas.gameObject.SetActive(false);
        defaultCam.Priority = 1;
        custsceneCam.Priority = 0;
    }
}
