using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GOscoreHandler : MonoBehaviour
{
    public GameObject currentScore;
    private TextMeshProUGUI currentScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScoreText = currentScore.GetComponent<TextMeshProUGUI>();
        currentScoreText.text = PlayerPrefs.GetString("currentScore");
    }

   
}
