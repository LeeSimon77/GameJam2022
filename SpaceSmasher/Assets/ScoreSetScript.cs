using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetScript : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "" + GameScoreScript.GameScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
