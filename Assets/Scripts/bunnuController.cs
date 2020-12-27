using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnuController : MonoBehaviour
{
    public GameController _gameController;

    public float forcaPulo;
    private Rigidbody2D playerRb;

    public Transform groundedCheck;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundedCheck.position, 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded ==  true)
        {
            playerRb.AddForce(new Vector2(0, forcaPulo));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Coletavel":
                _gameController.pontuar(2);
                Destroy(col.gameObject);
            break;

            case "Obstaculo":
                _gameController.mudarCena("gameOver");
            break;
        }
    }
}
