using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private float zStart;
    public float cameraDist, smoothTime;

    private Transform player;
    private Vector3 target, mousePos, refVel, shakeOffset;

    void Start()
    {
        zStart = transform.position.z;
    }

    void Update()
    {
        UpdatePlayerPos();

        mousePos = CaptureMousePos();
        target = UpdateTargetPos();

        UpdateCameraPos();
    }

    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());

        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;

        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized;
        }
        return ret;
    }

    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = mousePos * cameraDist;
        Vector3 ret = player.position + mouseOffset;
        ret += shakeOffset;
        ret.z = zStart;
        return ret;
    }

    void UpdateCameraPos()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime); 
        transform.position = tempPos; 
    }

    void UpdatePlayerPos()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }
}
