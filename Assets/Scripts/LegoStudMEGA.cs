using UnityEngine;

public class LegoStudMEGA : MonoBehaviour
{
    public int studValue = 20;
    private Transform player;
    public AudioClip collectSound;
    public float attractionSpeed = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < 2.0f) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, attractionSpeed * Time.deltaTime);
            }
        }
    }


    public void AttractToPlayer(Transform target)
    {
        player = target;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            ScoreManager.instance.AddScore(studValue);
            Destroy(gameObject);
        }
    }
}
