using UnityEngine;

public class PlayerAIm : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            lookAtMouse();
        }
    }

    void lookAtMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0);

        Vector3 dir = mouseWorldPosition - transform.position;

        float angle = Vector2.SignedAngle(Vector2.right, dir);
        //Debug.Log($"angle: {angle}, mouseworld: {mouseWorldPosition}, pos: {transform.position}");
        if (angle < 0)
        {
            angle = 360f - Mathf.Abs(angle);
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }


}
