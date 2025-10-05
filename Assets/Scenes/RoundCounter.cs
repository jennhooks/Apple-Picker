using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]

    public int round = 1;
    private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        round = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (round < 0)
            uiText.text = "Game Over";
        else
            uiText.text = "Round " + round.ToString("#");
    }
}
