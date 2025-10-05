using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public int round = 1;
    public GameObject canvas;
    RoundCounter roundCounter;
    GameObject tree;
    public GameObject restartButtonPrefab;
    AppleTree tr;

    public void StartGame()
    {
        Debug.LogWarning("Button clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        tree = GameObject.Find("AppleTree");
        canvas = GameObject.Find("Canvas");
        tr = tree.GetComponent<AppleTree>();
        GameObject roundGO = GameObject.Find("RoundCounter");
        roundCounter = roundGO.GetComponent<RoundCounter>();

        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            // Create new basket GameObject.
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            // Setup the position to use for the transform.
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            // Update object's position.
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed() 
    {
        // Destroy all apples.
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Destroy a basket
        // Get last Basket's index
        int basketIndex = basketList.Count -1;
        // Get reference to the object
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the object
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        round += 1;
        roundCounter.round = round;

        // If there are no Baskets left, restart.
        if (basketList.Count == 0)
        {
            GameOver();
        }
    }

    void GameOver() 
    {
        tr.moving = false;
        // Destroy all apples.
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }


        GameObject tRestartGO = Instantiate<GameObject>(restartButtonPrefab, canvas.transform);
        //Vector3 pos = Vector3.zero;
        //tRestartGO.transform.position = pos;
    }
}
