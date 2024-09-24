using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame / EnemyRocket")]
public class EnemyRocket : Rocket
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        Destroy(this.gameObject);
    }
}
