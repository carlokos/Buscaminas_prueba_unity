using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private int x, y;
    [SerializeField] private bool isBomb;

    public bool IsBomb { get => isBomb; set => isBomb = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    private void OnMouseDown()
    {
        if (isBomb)
        {
            Debug.Log("pITO DURO PERON QUE MUY DURO");
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                EjemploGenerador.gen.GetCloseBombs(x, y).ToString();
        }
    }
}
