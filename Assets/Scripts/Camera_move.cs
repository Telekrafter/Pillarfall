using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    [Header("Настройки движения")]
    public float camera_speed = 10.0f;
    public Vector2 X_border = new Vector2(-20f, 20f);
    public Vector2 Z_border = new Vector2(-20f, 20f);
    private float horizontal;
    private float vertical;

    [Header("Настройки скролла")]
    public float camera_scroll_speed = 10f;
    public float border_distance = 1f;

    [Header("Настройки приближения")]
    public float zoom_force = 2f;
    public float max_zoom = 0f;
    public float min_zoom = 6f;
    

    void Update()
    {
        WASD_move();
        Scroll_move();
        Zoom();
    }
    void WASD_move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float move_X = horizontal * camera_speed * Time.deltaTime;
        float move_Z = vertical * camera_speed * Time.deltaTime;

        Vector3 new_pos = transform.position +  new Vector3(move_X, 0, move_Z);

        new_pos.x = Mathf.Clamp(new_pos.x, X_border.x, X_border.y);
        new_pos.z = Mathf.Clamp(new_pos.z, Z_border.x, Z_border.y);
        transform.position = new_pos;
    }
    void Scroll_move()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        Vector3 new_pos = transform.position;

        if (mouseX < border_distance)
        {
            new_pos.x -= camera_scroll_speed * Time.deltaTime;

        }
        if (mouseY < border_distance)
        {
            new_pos.z -= camera_scroll_speed * Time.deltaTime;

        }
        if (mouseX > Screen.width - border_distance)
        {
            new_pos.x += camera_scroll_speed * Time.deltaTime;

        }
        if (mouseY > Screen.height - border_distance)
        {
            new_pos.z += camera_scroll_speed * Time.deltaTime;

        }
        transform.position = new_pos;

    }
    void Zoom()
    {
        float Mouse_ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 new_pos = transform.position + zoom_force * transform.forward * Mouse_ScrollWheel;
        new_pos.y = Mathf.Clamp(new_pos.y, max_zoom, min_zoom);
        transform.position = new_pos;

    }
}
