using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrowth : MonoBehaviour
{
    private float[] scales = {0.4774796f, 0.6477489f, 0.8115646f, 0.9682409f};
    [SerializeField] GameObject player;
    public int playerSize;

    // Start is called before the first frame update
    void Start()
    {
        playerSize = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameScoreScript.GameScore >= 10 && GameScoreScript.GameScore <= 20)
        {
            player.transform.localScale = new Vector3(scales[0], scales[0], 0);
            playerSize = 2;
        }
        else if (GameScoreScript.GameScore >= 20 && GameScoreScript.GameScore <= 30)
        {
            player.transform.localScale = new Vector3(scales[1], scales[1], 0);
            playerSize = 3;
        }
        else if (GameScoreScript.GameScore >= 30 && GameScoreScript.GameScore <= 50)
        {
            player.transform.localScale = new Vector3(scales[2], scales[2], 0);
            playerSize = 4;
        }
        else if (GameScoreScript.GameScore >= 50)
        {
            player.transform.localScale = new Vector3(scales[3], scales[3], 0);
            playerSize = 5;
        }

    }
}
