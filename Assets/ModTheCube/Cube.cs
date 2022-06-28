using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 rotationSpeed = new Vector3(100, 50, 100);
    public float xMoveSpeed = 1.0f;
    public int xMoveRange = 10;
    public float yMoveSpeed = 1.0f;
    public int yMoveRange = 10;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        InvokeRepeating("ChangeSize", 0.0f, 5.0f);
        InvokeRepeating("ChangeColor", 0.0f, 3.0f);
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);


    }

    void LateUpdate()
    {
        moveInXAxis();

    }

    void ChangeSize()
    {
        float[] randoms = { Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f) };

        transform.localScale = new Vector3(3.0f * randoms[0], 3.0f * randoms[1], 3.0f * randoms[2]);
    }

    void ChangeColor()
    {
        float[] randoms = { Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0.1f, 1.0f) };
        Material material = Renderer.material;
        material.color = new Color(1.0f * randoms[0], 1.0f * randoms[1], 1.0f * randoms[2], 1.0f * randoms[3]);
    }

    void moveInXAxis()
    {
        if (transform.position.x > xMoveRange)
        {
            transform.position = new Vector3(xMoveRange, transform.position.y, transform.position.z);
            xMoveSpeed = -xMoveSpeed;
        }
        else if (transform.position.x < -xMoveRange)
        {
            transform.position = new Vector3(-xMoveRange, transform.position.y, transform.position.z);
            xMoveSpeed = -xMoveSpeed;
        }


        transform.Translate(1.0f * Time.deltaTime * xMoveSpeed, 0.0f, 0.0f, Space.World);
    }

}
