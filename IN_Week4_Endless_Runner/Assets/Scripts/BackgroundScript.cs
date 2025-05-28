using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    private Vector3 startPos;
    private float backgroundWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        backgroundWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - backgroundWidth)
        {
            transform.position = startPos;
        }
    }
}
