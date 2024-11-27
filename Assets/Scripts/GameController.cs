using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private List<GameObject> _cans; // Lista de elementos de objetivos
    private int _score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        _cans = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cans"));

        //Podemos buscar el TextMeshProUGUI ó añadirlo desde el inspector
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void TargetHit(GameObject go)
    {
        Debug.Log("Score: " + _score);
        if (_cans.Contains(go))
        {
            _score += 10;
            _cans.Remove(go);
            Debug.Log("Score " + _score);
            scoreText.text = "Score " + _score.ToString("000");
        }
    }


}
