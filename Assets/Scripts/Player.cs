using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float thrustForce = 250f;
    public float rotationSpeed = 240f;
    public GameObject gun, bulletPrefab, camera, pauseMenu;
    public static int SCORE = 0;

    public float widthLimit, heightLimit;

    private Rigidbody _rigid;
    private Collider myCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = GetComponent<Collider>();
        _rigid = GetComponent<Rigidbody>();
        widthLimit = Camera.main.orthographicSize + 2;
        heightLimit = widthLimit * Screen.height / Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 thrustDirection = transform.right;
        _rigid.AddForce(thrust * thrustForce * thrustDirection);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);
    }
    void Update()
    {
        Vector3 nPos = transform.position;

        if (nPos.x > widthLimit)
        {
            Debug.Log("derecha");
            nPos.x = -widthLimit + 1;
        }
        else if (nPos.x < -widthLimit)
        {
            Debug.Log("izquierda");
            nPos.x = widthLimit - 1;
        }
        else if (nPos.y > heightLimit)
        {
            Debug.Log("arriba");
            nPos.y = -heightLimit + 1;
        }
        else if (nPos.y < -heightLimit)
        {
            Debug.Log("abajo");
            nPos.y = heightLimit - 1;
        }

        transform.position = nPos;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Init(_rigid.linearVelocity.magnitude, myCollider);

            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            pauseMenu.GetComponent<PauseUi>().GameOverFunc();
            SCORE = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }

    }
}
