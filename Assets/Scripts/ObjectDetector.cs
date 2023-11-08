using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;
    [SerializeField]
    private TowerData towerData;

    private Camera cam;
    private Ray ray;
    private RaycastHit hit;
    private Transform hitTransform = null; //선택한 오브젝트 임시 저장

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject() == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitTransform = hit.transform;

                if (hit.transform.CompareTag("TILE"))
                {
                    towerSpawner.SpawnTower(hit.transform);
                }
                else if (hit.transform.CompareTag("Tower"))
                {
                    towerData.OnPanel(hit.transform);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(hitTransform == null || hitTransform.CompareTag("Tower") == false)
            {
                towerData.OffPanel();
            }

            hitTransform = null;
        }
    }
}
