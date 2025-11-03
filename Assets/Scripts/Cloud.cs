using UnityEngine;

public class Cloud : MonoBehaviour
{
    public bool goingLeft;
    [SerializeField] [Range(0, 0.3f)] private float speedMin, speedMax;
    [SerializeField] private float leftBound, rightBound; 
    private float _x;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetCloud();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animate();
    }

    void ResetCloud()
    {
        // choose random speed to move at
        _x = Random.Range(speedMin, speedMax);
        //find out direction
        _x = goingLeft ? _x : -_x;

        var newX = transform.position;
        // find the new x pos, move slightly more towards the center to avoid hitting the bounds again & getting trapped in a loop
        newX.x = goingLeft ? leftBound + 1 : rightBound - 1;
        transform.position = newX;

    }
    
    void Animate()
    {
        var xpos = transform.position.x;
        //if out of bounds
        if (xpos <= leftBound || xpos >= rightBound)
        {
            print("hgay");
            ResetCloud();
        }
        else
        {
            //move according to previous calculations
            transform.position += new Vector3(_x, 0, 0);
        }
       
    }
    
}
