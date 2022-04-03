using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public GameObject pickup;
    public int pickupCount;
    public float xRange, zRange, yRange;

    public static int score = 0;
    private int oldScore = 0;

    void Start()
    {
        for(int i = 0; i < pickupCount; i++)
        {
            float x = Random.Range(-xRange, xRange);
            float z = Random.Range(-zRange, zRange);
            float y = Random.Range(0.1f, yRange);

            Vector3 position = new Vector3(x, y, z);
            Instantiate(pickup, position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score != oldScore)
        {
            Debug.Log(score.ToString());
        }

        oldScore = score;  
    }
}
