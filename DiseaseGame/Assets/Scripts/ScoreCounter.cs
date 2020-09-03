using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text text;
    void Start()
    {
        text.text = ("Score: 0" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(int score)
    {
        text.text = ("Score: " + score);
    }
}
