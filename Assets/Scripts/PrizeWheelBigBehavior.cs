using UnityEngine;

public class PrizeWheelBigBehavior : MonoBehaviour
{
    //represents an additional slowing force that is applied to the angularVelocity every frame.
    public float additionalFriction = .01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int pushForce = Random.Range(25, 100);
        //On start, add a random amount of rotational force to the Prize Wheel to make it spin
        this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = pushForce;
        Debug.Log("Spun with a force of " +  pushForce);
    }

    // Update is called once per frame
    void Update()
    {
        //update and abstract angularVelocity every frame
        float currentAngluarVelocity = this.gameObject.GetComponent<Rigidbody2D>().angularVelocity;
        //every frame, reduce angularVelocity by the additionalFriction to encourage a faster slowdown
        this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = currentAngluarVelocity - additionalFriction;
        //then, if the reduction would have made angular Velocity negative, clamp it to 0 instead
        if (this.gameObject.GetComponent<Rigidbody2D>().angularVelocity < 0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }
}
