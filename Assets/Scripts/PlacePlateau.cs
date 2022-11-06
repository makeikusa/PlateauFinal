using Google.XR.ARCoreExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacePlateau : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] ARAnchorManager _arAnchorManager;

    [SerializeField] double mLatitude = 34.23500000;
    //[SerializeField] double mLatitude = 30.23500000;
    [SerializeField] double mLongitude = 132.56250000;
    [SerializeField] double mAltitude = 33.1560;
    [SerializeField] Quaternion quaternion;
    [SerializeField] double heading;

    private void Place(GameObject targetObj, GeospatialPose pose)
    {
        //Debug.Log($"{pose.Altitude}");
        var quaternion = Quaternion.AngleAxis(180f - (float)pose.Heading, Vector3.up);
        var anchor = _arAnchorManager.AddAnchor(pose.Latitude, pose.Longitude, pose.Altitude, quaternion);
        //Debug.Log($"{anchor.transform.rotation}");
        //targetObj.transform.SetPositionAndRotation( anchor.transform.position, anchor.transform.rotation);
        var InstanceObj = Instantiate(_gameObject, anchor.transform);
    }

    public void PlaceCityModel()
    {
        Place(_gameObject, new GeospatialPose
        {
            Latitude = mLatitude,
            Longitude = mLongitude,
            Altitude = mAltitude,
            Heading = heading
        }) ;
    }

    public void IncreaseAltitude()
    {
        mAltitude += 5;
    }
    public void DecreaseAltitude()
    {
        mAltitude -= 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
