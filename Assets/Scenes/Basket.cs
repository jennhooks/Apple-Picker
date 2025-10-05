using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        // Find ScoreCounter.
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get ScoreCounter script.
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) 
        {
            // Get current position of mouse cursor.
            Vector3 mousePos2D = Input.mousePosition;

            mousePos2D.z = -Camera.main.transform.position.z;

            // Convert from 2D into 3D 
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            // Move the x position of the Basket to the x position of the mouse.
            Vector3 pos = this.transform.position;
            pos.x = mousePos3D.x;
            this.transform.position = pos;
        }
    }

    void OnCollisionEnter(Collision coll) 
    {
        // Find what hit the basket.
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
