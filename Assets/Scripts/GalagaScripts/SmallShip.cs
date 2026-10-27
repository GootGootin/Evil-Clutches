using UnityEngine;

public class SmallShip : MonoBehaviour
{
    private GameObject player;
    public GameObject explosion;
    public float speed = 3f;
    public float maxDegrees = 15f;
    public GameObject bullet;
    public float bulletTimer = 0, bulletWait = 1;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = -(player.transform.position - transform.position);
        transform.rotation = Quaternion.Euler(Mathf.Rad2Deg * transform.rotation.x,
                                              Mathf.Rad2Deg * transform.rotation.y,
                                              Mathf.Clamp(Mathf.Rad2Deg * transform.rotation.z, -maxDegrees, maxDegrees));
        transform.Translate(-transform.up * speed * Time.deltaTime);

        // bullets from BulletShip
        bulletTimer += Time.deltaTime;
        if (bulletTimer > bulletWait)
        {
            bulletTimer = 0;
            Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
        }

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                Destroy(collision.gameObject);

            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);
        }
    }
}
