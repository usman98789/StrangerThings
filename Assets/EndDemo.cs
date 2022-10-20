using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDemo : MonoBehaviour
{
    [SerializeField] GameObject canvasdemo;

    [SerializeField] EndGameRed endGame;

    private void OnTriggerEnter(Collider other)
    {
        canvasdemo.SetActive(true);
        endGame.HandleAudio();
        Time.timeScale = 0;
    }
}
