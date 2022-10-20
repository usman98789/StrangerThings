using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameRed : MonoBehaviour
{
    [SerializeField] GameObject canvasdemo;
    [SerializeField] GameObject canvasClues;
    [SerializeField] GameObject canvasLose;
    [SerializeField] GameObject canvasWin;

    [SerializeField] GameObject paper1;
    [SerializeField] GameObject paper2;
    [SerializeField] GameObject paper3;
    [SerializeField] GameObject paper4;

    [SerializeField] AudioSource ceil;
    [SerializeField] AudioSource demo1;
    [SerializeField] AudioSource demo2;
    [SerializeField] AudioSource clock;

    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (paper1.activeInHierarchy || paper2.activeInHierarchy || paper3.activeInHierarchy || paper4.activeInHierarchy)
        {
            canvasClues.SetActive(true);
        }
        else
        {
            int chance = Random.Range(0, 100);
            if (chance <= 50)
            {
                canvasLose.SetActive(true);
            }
            else
            {
                canvasWin.SetActive(true);
            }
        }

        HandleAudio();
        Time.timeScale = 0;
    }

    public void HandleAudio()
    {
        ceil.Stop();
        demo1.Stop();
        demo2.Stop();
        clock.Stop();
        audioSrc.Play();
    }

    private void Update()
    {
        if (canvasClues.activeInHierarchy || canvasLose.activeInHierarchy || canvasWin.activeInHierarchy || canvasdemo.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
