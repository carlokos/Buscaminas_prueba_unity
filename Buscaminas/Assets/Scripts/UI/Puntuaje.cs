using Palmmedia.ReportGenerator.Core.Common;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntuaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TMP_InputField txtWidth, txtHeight, txtNumBombs;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private TextMeshProUGUI txtError;
    [SerializeField] private TextMeshProUGUI txtShowScore;
    private int score = 0;
    private bool gameover;
    private int tilesWithoutBombs;

    public static Puntuaje CanvasManager;

    public bool Gameover { get => gameover; set => gameover = value; }

    // Start is called before the first frame update
    void Start()
    {
        CanvasManager = this;
        gameover = false;
        activePanel(panels[0]);   
    }
    public void addScore()
    {
        score++;
    }

    private void Update()
    {
        txtShowScore.text = score.ToString();
    }

    private void activePanel(GameObject panel)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panel.SetActive(true);
    }

    //método que se encarga de mostrar el resultado del jugador
    public void showScore() 
    {
        activePanel(panels[1]);
        txtScore.text = "Number of tiles discover: " + score;
    }

    //métoodos que usaremos en los botones en la UI
    public void StartGame()
    {
        tilesWithoutBombs = (txtWidth.text.ParseLargeInteger() * txtHeight.text.ParseLargeInteger()) - txtNumBombs.text.ParseLargeInteger();
        if(tilesWithoutBombs > txtNumBombs.text.ParseLargeInteger())
        {
            if(txtNumBombs.text.ParseLargeInteger() > 0)
            {
                panels[0].SetActive(false);
                activePanel(panels[2]);
                EjemploGenerador.gen.Width = txtWidth.text.ParseLargeInteger();
                EjemploGenerador.gen.Height = txtHeight.text.ParseLargeInteger();
                EjemploGenerador.gen.BombsNum = txtNumBombs.text.ParseLargeInteger();
                EjemploGenerador.gen.generarMapa();
            }
            else
            {
                errorPanel.SetActive(true);
                txtError.text = "You don't have any bombs, please check your bombs";
            }
        }
        else
        {
            errorPanel.SetActive(true);
            txtError.text = "You can't play with the current dimentions, returning to default";
        }
    }

    public void acceptError()
    {
        errorPanel.SetActive(false);
    }

    public void Retry()
    {
        score = 0;
        activePanel(panels[2]);
        EjemploGenerador.gen.borrarMapa();
        gameover = false;
        EjemploGenerador.gen.generarMapa();
    }

    public void RestartWithDifferentOptions()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
