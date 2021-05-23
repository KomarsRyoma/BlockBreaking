using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int basicScore = 10;
    int combo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score : " + score;
    }

    public void AddScore()
    {
        combo++;
        score += combo * basicScore;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}
