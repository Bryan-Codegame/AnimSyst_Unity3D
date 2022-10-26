using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDash : MonoBehaviour
{
    private PlayerController _playerController;

    public float dashSpeed;

    public float dashTime;
    // Start is called before the first frame update

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Dash());
            Debug.Log("Press A");
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        
        Debug.Log(Time.time);
        Debug.Log(startTime + dashTime);
        _playerController._controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
        /*while (Time.time < (startTime + dashTime))
        {
            _playerController._controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
        }*/
        yield return null;
    }
}
