using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 8f;//setting speed of bullet
    public float lifeTime = 2f;//To remove the bullets from the scene
    private float duration;
   
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = duration;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
