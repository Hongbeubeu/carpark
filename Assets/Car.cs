using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    LEFT,
    RIGHT,
    FORWARD,
    NONE
}

public class Car : MonoBehaviour
{
    const int toplane1 = 210;
    const int toplane2 = 200;
    Direction direction;
    [SerializeField] int velocity = 50;
    List<Vector2> path = new List<Vector2>();
    public List<Vector3> curve = new List<Vector3>();
    Vector3 tempPos, destination;
    int randomIndex, id;
    float distance, totalTime, currentTime;
    public GameObject from;
    public GameObject to;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        direction = Direction.FORWARD;
        path.Add(new Vector2(300, 300));
        path.Add(new Vector2(300, 0));
        path.Add(new Vector2(0, 300));
        path.Add(new Vector2(-300, 300));
        path.Add(new Vector3(300, -300));
        tempPos = transform.localPosition;
        randomIndex = Random.Range(0, 4);
        Vector2 sub = new Vector2(path[randomIndex].x - tempPos.x, path[randomIndex].y - tempPos.y);
        distance = Mathf.Abs(toplane1 - tempPos.y);
        totalTime = distance / velocity;
        destination = new Vector3(tempPos.x, toplane1);
        Vector3 directionn = destination.normalized;
    }

    // Update is called once per frame
    void Update()
    {

        if (direction != Direction.NONE)
        {
            currentTime += Time.deltaTime;
            if (currentTime > totalTime)
            {
                direction = Direction.LEFT;

                return;
            }
            Vector3 newPos = tempPos + Time.deltaTime * Vector3.up * velocity;
            transform.localPosition = Vector3.Lerp(tempPos, destination, currentTime / totalTime > 1 ? 1 : currentTime / totalTime);
            transform.localRotation = Quaternion.Lerp(from.transform.localRotation, to.transform.localRotation, currentTime / totalTime > 1 ? 1 : currentTime / totalTime);
        }
    }
}
