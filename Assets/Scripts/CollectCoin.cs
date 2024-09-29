using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int score = 0;
    public PlayerController playerController;
    public int maxScore;
    public Animator playerAnim;
    public GameObject player;
    public GameObject endPanel;
    private void Start()
    {
        playerAnim = player.GetComponentInChildren<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            ScoreUp();

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;

            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);

            endPanel.SetActive(true);

            if (score >= maxScore)
            {
                playerAnim.SetBool("win", true);
            }
            else
            {
                playerAnim.SetBool("lose", true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ScoreUp()
    {
        score++;
        coinText.text = "Score: " + score; 
    }
}
