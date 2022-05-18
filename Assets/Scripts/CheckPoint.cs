using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject CollisionTrigger;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject characterLeftPropeller;
    [SerializeField] private GameObject characterRightPropeller;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject GameControl;
    [SerializeField] private GameObject helicopter;
    [SerializeField] private GameObject gameoverPanel;

    private ScoreControl scoreControl;
    private PlayerControls playerControls;
    private PlatformMovement platformMovement;
    private LevelControl levelControl;
    private Helicopter _helicopter;
    private RegenerateLevels regenerate;


    private bool onoff = false;

    IEnumerator level(int second)
    {
        
        yield return new WaitForSeconds(second);
        if (scoreControl.GetScore() > levelControl.GetSubLevel() * 7)
        {
            platformMovement.SetIsSuccessful(true);
            yield return new WaitForSeconds(1);
            regenerate.SetItemFalse(levelControl.GetSubLevel());
            playerControls.setVerticalSpeed(1.5f);
            levelControl.SetAllScore(scoreControl.GetScore());
            scoreControl.SetScore(0);
            levelControl.SetSubLevel(levelControl.GetSubLevel()+1);
            if (levelControl.GetSubLevel() == 3)
            {
                
                _helicopter.StartDropBall();
            }
            yield return null;
        }
        else
        {
            gameoverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        

    }
    private void Awake()
    {
        scoreControl= CollisionTrigger.GetComponent<ScoreControl>();
        playerControls= character.GetComponent<PlayerControls>();
        platformMovement= platform.GetComponent<PlatformMovement>();
        levelControl = GameControl.GetComponent<LevelControl>();
        _helicopter = helicopter.GetComponent<Helicopter>();
        regenerate = GameControl.GetComponent<RegenerateLevels>();


    }

    private void Start()
    {


    }

    private void Update()
    {
        if (onoff)
        {
            StartCoroutine(level(5));
            onoff = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Player"))
        {

            
            playerControls.setVerticalSpeed(0);
            onoff = true;
            
            characterLeftPropeller.SetActive(false);
            characterRightPropeller.SetActive(false);
            

        }
    }


    public void LevelControlOff()
    {
        StopAllCoroutines();
    }

}
