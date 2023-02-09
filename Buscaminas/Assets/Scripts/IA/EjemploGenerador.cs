using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;

public class EjemploGenerador : MonoBehaviour
{
    [SerializeField] private GameObject celda;
    [SerializeField] private int width, height;
    [SerializeField] private GameObject[][] map;
    [SerializeField] private int bombsNum;

    public static EjemploGenerador gen;

    // Start is called before the first frame update
    void Start()
    {
        //iniciamos variable gen
        gen = this;
        Debug.Log(gen);

        //Inicializamos el mapa
        map = new GameObject[width][];

        for(int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }

        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(celda, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<CellManager>().X = i;
                map[i][j].GetComponent<CellManager>().Y = j;
            }
        }

        Camera.main.transform.position = new Vector3 ((float) width/2 -0.5f, (float) height/2 - 0.5f, -10);

        //Colocamos la bomba en el mapa
        for(int i = 0; i < bombsNum; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<CellManager>().IsBomb)
            {
                map[x][y].GetComponent<CellManager>().IsBomb = true;
            }
            else
            {
                i--;
            }
        }
    }

    public int GetCloseBombs(int x, int y)
    {
        int contador = 0;
        if(x > 0 && y < (height - 1) && map[x - 1][y + 1].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (y < (height - 1) && map[x][y + 1].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (x < (width - 1) && y < (height - 1) && map[x + 1][y + 1].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (x > 0 && map[x - 1][y].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (x < (width - 1) && map[x + 1][y].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (y > 0 && map[x][y - 1].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        if (x < (width - 1) && y > 0 && map[x + 1][y - 1].GetComponent<CellManager>().IsBomb)
        {
            contador++;
        }

        Debug.Log(contador);
        return contador;
    }
}
