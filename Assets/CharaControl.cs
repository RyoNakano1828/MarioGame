using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaControl : MonoBehaviour
{
    public GameObject mainCamera;
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Animator anim = GetComponent<Animator>();
        if (x != 0)
        {
            //AddForceメソッドを渡すためにVector2型に変換
            Vector2 movement = new Vector2(x, 0);
            int speed = 10;
            rigidbody.AddForce(movement * speed);
            anim.SetBool("Dash", true);
        }
        else
        {
            anim.SetBool("Dash", false);
        }
        if(transform.position.x > mainCamera.transform.position.x - 4)
        {
            Vector3 cameraPos = mainCamera.transform.position;
            cameraPos.x = transform.position.x + 4;
            mainCamera.transform.position = cameraPos;
        }
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
        transform.position = pos;
    }

    public LayerMask groundlayer;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        int jumpForce = 350;

        if (Input.GetKeyDown("space"))
        {
            bool grounded = Physics2D.Linecast(transform.position,
                transform.position - transform.up,
                groundlayer);
            if (grounded)
            {
                rigidbody.AddForce(Vector2.up * jumpForce);
            }
        }
        
    }
}
