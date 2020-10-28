using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public Camera cam;

    private Vector3 startPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = (Input.mousePosition);
            startPos.z = -10;
            startPos = cam.ScreenToWorldPoint(startPos);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPos = (Input.mousePosition);
            newPos.z = -10;
            newPos = cam.ScreenToWorldPoint(newPos);
            float posX = newPos.x - startPos.x;
            float posY = newPos.y - startPos.y;
            if (posX < 0 && transform.position.x > 12) posX = 0;
            if (posY < 0 && transform.position.y > 3) posY = 0;
            if (posX > 0 && transform.position.x < -20) posX = 0;
            if (posY > 0 && transform.position.y < -12) posY = 0;
            transform.position = new Vector3(transform.position.x - posX, transform.position.y - posY, transform.position.z);
        }


    }
}
