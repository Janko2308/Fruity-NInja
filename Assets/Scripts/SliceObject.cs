using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public Material crossSectionMaterial;
    public float cutForce = 2000;
    private XRGrabInteractable grabInteractable; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            Slice(hit.transform.gameObject);
        }
        
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity); 
        planeNormal.Normalize();
        

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            //GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            GameObject lowerHull = hull.CreateLowerHull(target, target.GetComponent<MeshRenderer>().material);
            SetupSlicedComponent(lowerHull);
            //GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            GameObject upperHull = hull.CreateUpperHull(target, target.GetComponent<MeshRenderer>().material);
            SetupSlicedComponent(upperHull);

            Destroy(target);
            /*
            GameObject lowerHull = hull.CreateLowerHull(targer);
            GameObject upperHull = hull.CreateUpperHull(targer)t;
            */

            // AddHullComponents(lowerHull);
            // AddHullComponents(upperHull);

            // GameObject.Destroy(targert);
        }
    }
    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
        slicedObject.layer = LayerMask.NameToLayer("sliceableLayer");
        slicedObject.AddComponent<XRGrabInteractable>();
        slicedObject.AddComponent<DestroyIfBelowY>();
        
    }
}
