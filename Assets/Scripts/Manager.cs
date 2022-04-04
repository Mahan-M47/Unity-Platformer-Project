using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private int score = 0;

    public GameObject playAgainButton;
    public GameObject scoreUI;
    private Text scoreText;
    

    public GameObject pickup;
    public int pickupCount;
    public float xRange, zRange, yRange;

    void Start()
    {
        scoreText = scoreUI.GetComponent<Text>();
        scoreUI.SetActive(true);

        SetupGame();
    }

    private void SetupGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        score = 0;
        scoreText.text = $"Score: {score}";
        
        for (int i = 0; i < pickupCount; i++)
        {
            float x = Random.Range(-xRange, xRange);
            float z = Random.Range(-zRange, zRange);
            float y = Random.Range(0.3f, yRange);

            Vector3 position = new Vector3(x, y, z);
            Instantiate(pickup, position, Quaternion.identity);
        }
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

            playAgainButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PlayAgainButtonClickHandler()
    {
        playAgainButton.SetActive(false);
        SetupGame();
    }
}
