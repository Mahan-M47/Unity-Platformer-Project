using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    private int score = 0;

    public GameObject menuUI;
    public GameObject scoreUI;
    private Text scoreText;

    public GameObject pickup;
    public int pickupCount;
    public float xRange, zRange, yRange;

    private List<GameObject> generatedPickups;

    void Awake()
    {
        generatedPickups = new List<GameObject>();
        scoreText = scoreUI.GetComponent<Text>();
        scoreUI.SetActive(true);

        SetupGame();
    }

    private void SetupGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        score = 0;
        scoreText.text = $"Score: {score}";

        foreach (GameObject item in generatedPickups)
        {
            Destroy(item);
        }

        generatedPickups.Clear();

        for (int i = 0; i < pickupCount; i++)
        {
            float x = Random.Range(-xRange, xRange);
            float z = Random.Range(-zRange, zRange);
            float y = Random.Range(0.3f, yRange);

            Vector3 position = new Vector3(x, y, z);
            generatedPickups.Add(Instantiate(pickup, position, Quaternion.identity));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) {
                PauseGame();
            }
            else {
                UnpauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        menuUI.SetActive(true);
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        menuUI.SetActive(false);
    }

    public void Score()
    {
        score++;
        AudioManager.PlayPickupSound();
        scoreText.text = $"Score: {score}";

        if (score == pickupCount)
        {
            scoreText.text = "YOU WON!";
            AudioManager.PlayWinSound();
            PauseGame();
        }
    }

    public void PlayAgainButtonClickHandler()
    {
        UnpauseGame();
        SetupGame();
    }

    public void MainMenuButtonClickHandler()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
