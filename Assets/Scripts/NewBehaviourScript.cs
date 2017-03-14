using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
    public Rigidbody rigidbody;
    private int count;

    public Text countText;
    public Text winText;
    //Use this for initialization
    void Start ()
    {
		rigidbody = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cylinder")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        else if(other.gameObject.tag =="Capsule")
        {
            other.gameObject.SetActive(false);
            count += 3;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Twój wynik: " + count.ToString();
        if (count >= 9)
        {
            winText.text = "Wygrałeś!!!";
        }
    }
}
