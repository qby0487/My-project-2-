using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] Text scoreText ; //計時器  

    int score ;

    float scoreTime ;

    float timer_f;
    int timer_i;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer_f = Time.time;
        timer_i = Mathf.FloorToInt(timer_f);
        Debug.Log(timer_i);
   
        UpdateScoreText();
    }
    void UpdateScoreText()
{
             scoreText.text = "時間:" + timer_i.ToString() ;
}
}
