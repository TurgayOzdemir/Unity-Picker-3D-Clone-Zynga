using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject gameControl;

    [SerializeField] private GameObject blueCharacter;
    [SerializeField] private GameObject orangeCharacter;

    [SerializeField] private GameObject loadGame;
    [SerializeField] private GameObject exitGame;

    private CharacterAttributes _characterAttributes;
    private LevelControl _gameControl;

    private Button _blueCharacter;
    private Button _orangeCharacter;

    private Button _loadGame;
    private Button _exitGame;

    private void Awake()
    {
        _characterAttributes = character.GetComponent<CharacterAttributes>();
        _gameControl = gameControl.GetComponent<LevelControl>();

        _blueCharacter = blueCharacter.GetComponent<Button>();
        _orangeCharacter = orangeCharacter.GetComponent<Button>();

        _loadGame = loadGame.GetComponent<Button>();
        _exitGame = exitGame.GetComponent<Button>();
    }

    private void Start()
    {
        _blueCharacter.onClick.AddListener(blueCharButton);
        _orangeCharacter.onClick.AddListener(orangeCharButton);
        _loadGame.onClick.AddListener(loadGameButton);
        _exitGame.onClick.AddListener(exitGameButton);

        Time.timeScale = 0f;
    }

    void blueCharButton()
    {
        _characterAttributes.setCharacterSelection(true);
        Time.timeScale = 1f;
        _gameControl.SetLevel(1);
        gameObject.SetActive(false);

    }

    void orangeCharButton()
    {
        _characterAttributes.setCharacterSelection(false);
        Time.timeScale = 1f;
        _gameControl.SetLevel(1);
        gameObject.SetActive(false);

    }

    void loadGameButton()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    void exitGameButton()
    {
        Application.Quit();
    }

}
