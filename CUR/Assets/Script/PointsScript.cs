using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    public Text pontoUI;// Arrastar da hierarquia Pontos para a variavel publica
                         // Pontos da Main Camera
    public Text recordeUI;// Arrastar da hierarquia Recorde para a variavel publica
                          // Recorde da Main Camera
    public int pontos = 0;
    void Update()
    {
        pontoUI.text = "PONTOS: " + pontos;

        if (pontos > PlayerPrefs.GetInt("Recorde"))
        {
            PlayerPrefs.SetInt("Recorde", pontos);
        }
        recordeUI.text = "RECORDE: " + PlayerPrefs.GetInt("Recorde");
    }
}