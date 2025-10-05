using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tGO = this.gameObject;
        button = tGO.GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
