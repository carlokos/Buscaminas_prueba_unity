using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CellManager : MonoBehaviour
{
    [SerializeField] private int x, y;
    [SerializeField] private bool isBomb;
    [SerializeField] private SpriteRenderer bandera;
    [SerializeField] private TextMeshPro num;
    private bool marcada;

    public bool IsBomb { get => isBomb; set => isBomb = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    private void Start()
    {
        num.gameObject.SetActive(false);
        bandera.gameObject.SetActive(false);
    }

    /*if (!marcada)
        {
            //colocar bandera
            bandera.gameObject.SetActive(true);
            marcada = true;
            Debug.Log("colocamos bandera");
        }
        else if (marcada){
            bandera.gameObject.SetActive(false);
            marcada = false;
            Debug.Log("quitamos la bandera");
        }*/

    private void OnMouseDown()
    {
        if (!Puntuaje.CanvasManager.Gameover)
        {
            if (!EjemploGenerador.gen.MarkMode && !marcada)
            {
                if (isBomb)
                {
                    Puntuaje.CanvasManager.showScore();
                    Puntuaje.CanvasManager.Gameover = true;
                }
                else
                {
                    num.gameObject.SetActive(true);
                    marcada = true;
                    num.text = EjemploGenerador.gen.GetCloseBombs(x, y).ToString();
                    Puntuaje.CanvasManager.addScore();
                }
            }
            else if(EjemploGenerador.gen.MarkMode)
            {
                if (!marcada)
                {
                    bandera.gameObject.SetActive(true);
                    marcada = true;
                    Debug.Log("colocamos bandera");
                }
                else if(marcada)
                {  
                    bandera.gameObject.SetActive(false);
                    marcada = false;
                    Debug.Log("quitamos la bandera");
                }
            }
        }
    }
}
    