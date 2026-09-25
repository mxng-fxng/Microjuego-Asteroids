using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 16f;
    public float maxlifeTime = 3f;
    public Vector3 targetVector;

    private Collider myCollider;
    // public GameObject shooter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }
    public void Init(float playerVel, Collider playerCollider)
    {
        myCollider = GetComponent<Collider>();
        Destroy(gameObject, maxlifeTime);
        speed += playerVel;
        Physics.IgnoreCollision(playerCollider, myCollider, true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), myCollider, true);
            Debug.Log("He colisionado con un jugaor");
        }
        else
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Score();
            Destroy(gameObject);
        }

    }

    private void Score()
    {
        Player.SCORE++;
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        GameObject ui = GameObject.Find("UI_SCOREBOARD");

        ui.GetComponent<Text>().text = "SCORE: " + Player.SCORE;
    }
}
