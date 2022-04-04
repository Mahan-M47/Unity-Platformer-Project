using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private int score = 0;
    public GameObject scoreUI;
    private Text scoreText;

    public GameObject pickup;
    public int pickupCount;
    public float xRange, zRange, yRange;

    void Start()
    {
        scoreText = scoreUI.GetComponent<Text>();
        scoreText.text = $"Score: {score}";
        scoreUI.SetActive(true);

        for (int i = 0; i < pickupCount; i++)
        {
            float x = Random.Range(-xRange, xRange);
            float z = Random.Range(-zRange, zRange);
            float y = Random.Range(0.1f, yRange);

            Vector3 position = new Vector3(x, y, z);
            Instantiate(pickup, position, Quaternion.identity);
        }
        
    }

    public void Score()
    {
        score++;
        AudioManager.PlayPickupSound();
        scoreText.text = $"Score: {score}";
    }
}
