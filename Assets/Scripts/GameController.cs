using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameClearText;
    public GameObject gameOverText;
    public GameObject ball;
    public GameObject retryButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0){
            gameClearText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }

        if(ball.GetComponent<Ball>().isDead == true)
        {
            gameOverText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }
    }

    public void Retry()
    {
        // シーンを読み込み直す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
