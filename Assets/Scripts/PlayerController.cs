using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    // Referenced https://answers.unity.com/questions/1100879/push-object-in-opposite-direction-of-collision.html
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        } else if (other.CompareTag("Moving Pick Up")) {
            Vector3 force = transform.position - other.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * 600);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 13)
        {
            winText.text = "You Win!";
        }
    }
}