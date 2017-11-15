using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController: MonoBehaviour
{
    public GameObject player;
    Vector3 newPlayerPosition;
    float time = 0;
    float distance = 100; // 飛ばす&表示するRayの長さ
    float duration = 3;   // 表示期間（秒）


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            time = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                newPlayerPosition = hit.point;
            }
        }
        time += Time.deltaTime * 0.1f;
        player.transform.position = Vector3.Lerp(player.transform.position, newPlayerPosition, time);
    }
}