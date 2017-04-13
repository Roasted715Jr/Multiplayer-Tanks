using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public Transform redStart;
    public Transform blueStart;
    public GameObject tankRed;
    public GameObject tankBlue;
    public GameObject tank;

	// Use this for initialization
	void Start () {
        //Instantiate(tankRed, redStart);
        //Instantiate(tankBlue, blueStart);

        tankRed = Instantiate(tank, redStart);
        tankBlue = Instantiate(tank, blueStart);
        tankRed.GetComponent<PlayerController>().color = "Red";
        tankBlue.GetComponent<PlayerController>().color = "Blue";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
