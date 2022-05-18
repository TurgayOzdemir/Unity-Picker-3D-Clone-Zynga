using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject pauseRestartButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject pauseExitButton;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject ESCPanel;
    [SerializeField] private GameObject gameControl;
    [SerializeField] private GameObject[] collisionTrigger = new GameObject[3];


    private PlayerControls _playerControls;
    private Button _restartButton;
    private Button _pauseRestartButton;
    private Button _exitButton;
    private Button _pauseExitButton;
    private Button _continueButton;
    private RegenerateLevels _regenerateLevels;
    private LevelControl _levelControl;
    private ScoreControl[] _scoreControl = new ScoreControl[3];

    private bool _ESCInput;

    private void Awake()
    {
        
        _continueButton = continueButton.GetComponent<Button>();
        _playerControls = character.GetComponent<PlayerControls>();
        _restartButton = restartButton.GetComponent<Button>();
        _pauseRestartButton = pauseRestartButton.GetComponent<Button>();
        _exitButton = exitButton.GetComponent<Button>();
        _pauseExitButton = pauseExitButton.GetComponent<Button>();
        _regenerateLevels = gameControl.GetComponent<RegenerateLevels>();
        _levelControl = gameControl.GetComponent<LevelControl>();
        _restartButton = restartButton.GetComponent<Button>();

        for (int i = 0; i < collisionTrigger.Length; i++)
        {
            _scoreControl[i] = collisionTrigger[i].GetComponent<ScoreControl>();
        }
        
    }

    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
        _pauseRestartButton.onClick.AddListener(Restart);
        _exitButton.onClick.AddListener(Exit);
        _pauseExitButton.onClick.AddListener(Exit);
        _continueButton.onClick.AddListener(ContinueButton);
    }

    private void Update()
    {
        if (_ESCInput)
        {

            ESCPanel.SetActive(true);
            _ESCInput = false;
            Time.timeScale = 0f;

        }
        
    }

    void Restart()
    {
        Time.timeScale = 1f;
        _levelControl.SetAllScore(0,true);
        _levelControl.SetSubLevel(1);
        gameoverPanel.SetActive(false);
        ESCPanel.SetActive(false);
        _playerControls.setVerticalSpeed(1.5f);
        _regenerateLevels.RestartGame();

        for (int i = 0; i < collisionTrigger.Length; i++)
        {
            _scoreControl[i].Restart();
        }

    }

    void Exit()
    {
        Application.Quit();
    }

    void ContinueButton()
    {
        ESCPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetESCInput(bool newESCInput)
    {
        _ESCInput = newESCInput;
    }
}
