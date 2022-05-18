using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreControl : MonoBehaviour
{

    private int _score = 0;

    [SerializeField] private GameObject scoreTable;
    [SerializeField] private GameObject gameControl;

    private TextMeshProUGUI _scoreTable;
    private LevelControl _levelControl;


    private void Awake()
    {
        _scoreTable = scoreTable.GetComponent<TextMeshProUGUI>();
        _levelControl = gameControl.GetComponent<LevelControl>();
    }

    private void Update()
    {
        _scoreTable.text = _score + "/" + 7*_levelControl.GetSubLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        _score++;
        
    }

    public int GetScore() { return _score; }
    public void SetScore(int newScore) { _score = newScore; }

    public void Restart()
    {
        _score = 0;
    }
}
