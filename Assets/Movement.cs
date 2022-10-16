using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float x_min = -10f, x_max = 10f, y_min = -5f, y_max = 5f;
    SpriteRenderer m_SpriteRenderer;
     public GameObject dvd;
    Vector2 direction;
    float speed_x,speed_y;
    float angle_x, angle_y;
    int speed = 1;
    float scale_x, scale_y;


    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        x_min = -8f;
        x_max = 8f;
        y_min = -5f;
        y_max = 5f;
        angle_x = Random.Range(0, 360);
        angle_y = Random.Range(0, 360);
        dvd = GameObject.Find("dvd");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        direction = new Vector2(angle_x,angle_y);
        speed_x = speed * Mathf.Cos(angle_x) * Time.deltaTime;
        speed_y = speed * Mathf.Sin(angle_y) * Time.deltaTime;
        scale_x = dvd.transform.localScale.x;
        scale_y  = dvd.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed_x, speed_y,0);
        if (transform.position.x >= (x_max - 2*scale_x) || transform.position.x <= (x_min +2 * scale_x))
        {
            speed_x *= -1;
            ColourChange();

        }


        if (transform.position.y >= (y_max - 6 *scale_y) || transform.position.y <= (y_min + 6 *scale_y))
        {
            speed_y *= -1;
            
            ColourChange();
        }
       

        

    }

    void ColourChange()
    {
        m_SpriteRenderer.color = Random.ColorHSV();
    }
}
