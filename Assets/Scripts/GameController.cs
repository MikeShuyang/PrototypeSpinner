using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button resetButton;
    // Start is called before the first frame update
    void Start()
    {
        resetButton.onClick.AddListener(ResetGame);
    }

    void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
