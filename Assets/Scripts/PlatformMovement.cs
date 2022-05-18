using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Transform highPosition;
    [SerializeField] private Transform lowPosition;
    [SerializeField] private GameObject leftBarrier;
    [SerializeField] private GameObject rightBarrier;


    private bool _isSuccessful = false;
    private bool _restart = false;

    private void Update()
    {
        if (_isSuccessful == true)
        {
            transform.DOMoveY(highPosition.position.y, 1);
            leftBarrier.gameObject.transform.DORotate(new Vector3(0,0,90),1);
            rightBarrier.gameObject.transform.DORotate(new Vector3(0, 0, -90), 1);
            _isSuccessful = false;
        }

        if (_restart)
        {
            transform.DOMoveY(lowPosition.position.y, 1);
            leftBarrier.gameObject.transform.DORotate(new Vector3(0, 0, 0), 1);
            rightBarrier.gameObject.transform.DORotate(new Vector3(0, 0, 0), 1);
            _restart = false;
        }
    }

    public void SetIsSuccessful(bool NewIsSuccesful) { _isSuccessful = NewIsSuccesful; }
    public void SetRestart(bool NewRestart) { _restart = NewRestart; }

}
