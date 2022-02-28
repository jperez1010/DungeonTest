using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,0,0);
    private Vector3 zero = new Vector3(0, 0, 0);

    void Start()
    {
        if (player)
        {
            offset = transform.position - player.transform.position;
        }
    }

    void LateUpdate()
    {
        if (player)
        {
            if (offset.Equals(zero))
            {
                offset = transform.position - player.transform.position;
            }
            transform.position = player.transform.position + offset;
        }
    }
}