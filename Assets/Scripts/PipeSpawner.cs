using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float spawnTime = 1;
    public float timer = 0;
    public GameObject pipes;
    public float height;


    void Start()
    {
        GameObject newPipes = Instantiate(pipes);
        newPipes.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }


    void Update()
    {
        if (timer > spawnTime)
        {
            GameObject newPipes = Instantiate(pipes);
            newPipes.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newPipes, 10);
            timer = 0;
        }

        timer += Time.deltaTime;
        
    }
}
