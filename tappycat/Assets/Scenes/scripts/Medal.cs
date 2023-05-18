using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int gameScore = GameManager.gameScore;

        if (gameScore > 0 && gameScore <= 5)
        {
            img.sprite = metalMedal;
        }
        else if (gameScore > 1 && gameScore <= 15)
        {
            img.sprite = bronzeMedal;
        }
        else if (gameScore > 2 && gameScore <= 25)
        {
            img.sprite = silverMedal;
        }
        else if (gameScore > 25)
        {
            img.sprite = goldMedal;
        }
    }
}
