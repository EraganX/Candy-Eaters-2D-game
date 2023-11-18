using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Player")) {
            GameManager.instance.IncrementScore();
            Destroy(this.gameObject);
        }

        if (target.CompareTag("Boundary"))
        {
            GameManager.instance.DecreaseLife();
            Destroy(this.gameObject);
        }
    }
}
