using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public int velocity;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.position = new Vector2(rigidbody.position.x + velocity * Time.deltaTime, rigidbody.position.y);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidbody.position = new Vector2(rigidbody.position.x + velocity * Time.deltaTime, rigidbody.position.y);
        }
        
        
    }
}
