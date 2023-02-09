using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntuaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtTime;
    private int score = 0;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void addScore()
    {
        score++;
    }

    public void showScore() 
    {
        gameObject.SetActive(true);
        int finalTime = (int) timer;
        txtScore.text = "Number of tiles discover: " + score;
        txtTime.text = "Your time: " + finalTime;
    }

    public void Restart()
    {
        
    }
}
