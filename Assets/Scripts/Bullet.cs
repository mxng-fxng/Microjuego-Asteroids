using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxlifeTime = 3f;
    public Vector3 targetVector;

    // public GameObject shooter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, maxlifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
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
