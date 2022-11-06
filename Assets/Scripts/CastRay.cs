using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CastRay : MonoBehaviour
{
    private float gap;
    private float rayDistance;
    RaycastHit hit;

    [SerializeField] public GameObject prefabObj;
    private TouchScreenKeyboard keyboard;
    bool FirstOpenTextEditer = true;

    void Start()
    {
        gap = 0.1f;
        rayDistance = 1000f;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            string name = hit.collider.gameObject.name; // 衝突した相手オブジェクトの名前を取得
            Debug.Log(name); 
            //Debug.Log(hit.collider.gameObject.transform.position);
            //Debug.Log(hit.point);
            //Debug.Log(hit.normal);


        }
    }

    public void Attach() {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            //GameObject obj = Instantiate(prefabObj, hit.point, this.transform.rotation);
            //GameObject obj = Instantiate(prefabObj, hit.point, Quaternion.Euler(hit.normal));
            GameObject obj = Instantiate(prefabObj, hit.point + (hit.normal * gap), Quaternion.LookRotation(-hit.normal));
            TextMeshPro txtMesh = obj.GetComponent<TextMeshPro>();
            txtMesh.text = keyboard.text;
        }
    }

    public void EditMessage()
    {
        if (FirstOpenTextEditer) { 
            this.keyboard = TouchScreenKeyboard.Open("HelloPlateau", TouchScreenKeyboardType.Default);
            FirstOpenTextEditer = false;
        }
        else { this.keyboard = TouchScreenKeyboard.Open(keyboard.text, TouchScreenKeyboardType.Default); }
    }
}
