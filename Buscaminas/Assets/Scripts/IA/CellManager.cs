using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private int x, y;
    [SerializeField] private bool isBomb;
    [SerializeField] private TextMeshPro num;

    public bool IsBomb { get => isBomb; set => isBomb = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    private void Start()
    {
        num.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (isBomb){
            Debug.Log("pITO DURO PERON QUE MUY DURO");
        }
        else
        {
            num.gameObject.SetActive(true);
            num.text = EjemploGenerador.gen.GetCloseBombs(x, y).ToString();
        }
    }
}
    