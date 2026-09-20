using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public float speed = 5;

    public bool goingUp = true;

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        
        if(transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }

        if (transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}
