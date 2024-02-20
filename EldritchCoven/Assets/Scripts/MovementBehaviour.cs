using FMODUnity;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private float timeMoving;
    private StepsPlayer stepsPlayer;

    [SerializeField] private Transform stairHighRay;
    [SerializeField] private Transform stairLowRay;
    [SerializeField] private StudioEventEmitter stepsEmitter;
    [SerializeField] private float speed;
    [SerializeField] float stepsEmissionRatio;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stepsPlayer = GetComponent<StepsPlayer>();
    }

    private void Update()
    {
        if (timeMoving >= stepsEmissionRatio)
        {
            timeMoving = 0;
            stepsEmitter.Play();
            stepsPlayer.MaterialCheck(); // No funciona antes del Play(). Too bad
        }
    }

    public void MoveRB(Vector3 direction)
    {
        Vector3 playerVelocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);

        rb.velocity = transform.TransformDirection(playerVelocity);
        timeMoving += Time.deltaTime;
    }

    public void StopRB()
    {
        timeMoving = 0;
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
    }
}
