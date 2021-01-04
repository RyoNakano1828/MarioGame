using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject goalObject;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            goalObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
