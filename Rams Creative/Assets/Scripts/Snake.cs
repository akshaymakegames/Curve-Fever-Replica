
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 100;

    [Space]
    [Header("Inputs")]
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] [Range(0.8f, 5f)] float joystickSenstivity=1;
    public string inputAxis = "Horizontal";
    [Space]
    [SerializeField] bool invertedControls = false;///Added since player 2 will play on upside down screen

    float horizontal = 0f;
    // Update is called once per frame
    void Update()
    {
        horizontal=Input.GetAxisRaw(inputAxis);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up*speed*Time.fixedDeltaTime,Space.Self);

        transform.Rotate(Vector3.forward * -horizontal *rotationSpeed*Time.fixedDeltaTime);
        if (joystick != null)
        { transform.Rotate(Vector3.forward *(invertedControls?-1:1) *-joystick.Horizontal*joystickSenstivity * rotationSpeed * Time.fixedDeltaTime); }


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "killsPlayer")
        {
            //////stop dead player
            speed = 0;
            rotationSpeed = 0;

            ///////a fast way to get which player won not recommended if making a full game
            if(transform.parent.name!="Player 1")
                GameObject.FindObjectOfType<GameManager>().EndGame(true);
            else if(transform.parent.name!="Player 2")
                GameObject.FindObjectOfType<GameManager>().EndGame(false);
        }
    }
}
