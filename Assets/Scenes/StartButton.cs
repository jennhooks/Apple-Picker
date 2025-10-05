using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button button;
    public GameObject tree;

    AppleTree tr;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        tr = tree.GetComponent<AppleTree>();
    }

    void StartGame()
    {
        GameObject[] basketArray = GameObject.FindGameObjectsWithTag("Basket");
        foreach (GameObject tempGO in basketArray)
        {
            Basket bk = tempGO.GetComponent<Basket>();
            bk.moving = true;
        }

        tr.moving = true;

        Destroy(this.gameObject);
    }
}
