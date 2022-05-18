using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    private PlayerControls _player;
    private RegenerateLevels _regenerate;


    [SerializeField] private GameObject charcater;
    [SerializeField] private GameObject gameControl;



    IEnumerator wait(int second)
    {
        float tempSpeed = _player.getVerticalSpeed();
        _player.setVerticalSpeed(0);
        yield return new WaitForSeconds(second);
        _player.setVerticalSpeed(tempSpeed);
    }

    private void Awake()
    {
        _player = charcater.GetComponent<PlayerControls>();
        _regenerate = gameControl.GetComponent<RegenerateLevels>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

           
            StartCoroutine(wait(2));
            

        }

        if (gameObject.CompareTag("Respawn"))
        {
            _regenerate.RestartGame();
        }
    }

    public void WaitStop()
    {
        StopAllCoroutines();
    }
}
