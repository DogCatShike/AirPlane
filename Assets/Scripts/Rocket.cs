using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame / Rocket")]
public class Rocket : MonoBehaviour
{
    public float m_speed = 10;
    public float m_power = 1.0f;

    private void OnBecameInvisible()
    {
        if(this.enabled)
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
            return;
        Destroy(this.gameObject);
    }
}
