using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneNavigator : MonoBehaviour
{

    [SerializeField] public GameObject player;
    private GameController _gameController;
        
    // Start is called before the first frame update
    void Start()
    {
        _gameController = player.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimationEnd()
    {
        _gameController.OnFirstCutSceneEnd();
    }
}
