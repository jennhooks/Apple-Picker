using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    public void StartGame()
    {
        Debug.LogWarning("Button clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
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

        // If there are no Baskets left, restart.
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
