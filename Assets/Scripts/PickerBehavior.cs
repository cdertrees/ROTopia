using UnityEngine;

public class PickerBehavior : MonoBehaviour
{
    //ref to the PrizeWheel
    GameObject prizeWheel;
    //ref to the Collider that last entered the Picker.
    Collider2D lastEnteredCollider;
    //publicly available container for whatever slice ends up being Picked
    public GameObject pickedSlice;
    //control boolean to prevent spam picking
    bool slicePicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //assign ref
        prizeWheel = GameObject.Find("PrizeWheel");
    }

    // Update is called once per frame
    void Update()
    {
      //every frame, check to see if the Prize Wheel has stopped moving
      if (prizeWheel.GetComponent<Rigidbody2D>().angularVelocity == 0 && slicePicked == false)
        {
            //if it has, then the last entered slice is Picked through its Collider
            pickedSlice = lastEnteredCollider.gameObject;
            //flip slicePicked to prevent spam
            slicePicked = true;
            Debug.Log("The wheel landed on " + pickedSlice.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //every time a Collider enters, we store it as the lastEnteredCollider
        lastEnteredCollider = other;

    }
}
