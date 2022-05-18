using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelControl : MonoBehaviour
{
    
    private int _level;
    private int _subLevel = 1;

    private int _allScore=0;


    [SerializeField] private GameObject currentLevel;
    [SerializeField] private GameObject nextLevel;

    [SerializeField] private GameObject subImage1;
    [SerializeField] private GameObject subImage2;
    [SerializeField] private GameObject subImage3;

    [SerializeField] private GameObject score;


    private TextMeshProUGUI _currentLevel;
    private TextMeshProUGUI _nextLevel;

    private Image _subImage1;
    private Image _subImage2;
    private Image _subImage3;

    private Color _colorGreen;
    private Color _colorWhite;

    private TextMeshProUGUI _score;

    public int GetLevel()
    {
        return _level;
    }

    public void SetLevel(int newLevel)
    {
        _level = newLevel;
    }

    public int GetSubLevel()
    {
        return _subLevel;
    }

    public void SetSubLevel(int newLevel)
    {
        _subLevel = newLevel;
    }

    private void Awake()
    {
        _currentLevel = currentLevel.GetComponent<TextMeshProUGUI>();
        _nextLevel = nextLevel.GetComponent<TextMeshProUGUI>();

        _subImage1 = subImage1.GetComponent<Image>();
        _subImage2 = subImage2.GetComponent<Image>();
        _subImage3 = subImage3.GetComponent<Image>();

        _colorGreen = new Color32(202,255,191,255);
        _colorWhite = new Color32(255,252,255,255);

        _score = score.GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("levelSave"))
        {
            _level = PlayerPrefs.GetInt("levelSave");
        }
        else
        {
            _level = 1;
        }

    }

    private void Update()
    {
        if (_subLevel > 3)
        {
            _level++;
            _subLevel = 1;

 
        }

        PlayerPrefs.SetInt("levelSave", _level);
        
        PlayerPrefs.Save();

        _currentLevel.text = _level.ToString();
        _nextLevel.text = (_level+1).ToString();

        switch (_subLevel)
        {
            case 1:
                _subImage2.color = _colorWhite;
                _subImage3.color = _colorWhite;
                break;
            case 2:
                _subImage2.color = _colorGreen;
                _subImage3.color = _colorWhite;
                break;
            case 3:
                _subImage2.color = _colorGreen;
                _subImage3.color = _colorGreen;
                break;
            default:
                break;
        }

        _score.text = "Score<br>" + _allScore.ToString();
        
    }
    public void SetAllScore(int newAllScore ,bool resetScore=false)
    {
        if (!resetScore)
        {
            _allScore += newAllScore;
        }
        else
        {
            _allScore=0;
        }
        
    }

}
