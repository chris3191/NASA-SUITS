using UnityEngine;

public class BlueButtonCommands : MonoBehaviour
{
    Vector3 originalPosition;

    public GameObject ReferenceObject1;
    public GameObject ReferenceObject2;
    public LineRenderer LineRenderer;


    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
           // var rigidbody = this.gameObject.AddComponent<Rigidbody>();
           // rigidbody.gameObject.SetActive(false);
    }
    void OnHold()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            Vector3 moveTo = gameObject.transform.position;
            //float placementVelocity = 0.06f;
            float dist = Mathf.Abs((gameObject.transform.position - moveTo).magnitude);

            var rigidbody = this.gameObject.AddComponent<Rigidbody>();

            //rigidbody.transform.position = Vector3.Lerp(gameObject.transform.position, moveTo, placementVelocity / dist);
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, moveTo, placementVelocity / dist);
           // rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        //LineRenderer = this.GetComponent<LineRenderer>();
        //LineRenderer.SetPosition(0, ReferenceObject2.transform.position);
        //LineRenderer.SetPosition(1, this.transform.position);
        ReferenceObject1.SetActive(true);
        ReferenceObject2.SetActive(false);
       // LineRenderer.gameObject.SetActive(true);

        
        //            Debug.DrawLine(ReferenceObject1.transform.position,originalPosition,Color.green,10,false); 

        // If the sphere has no Rigidbody component, add one to enable physics.
        /*if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            //rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            //rigidbody.gameObject.SetActive(false);

            Debug.DrawLine(ReferenceObject1.transform.position,originalPosition,Color.green,10,false); 

        }*/
    }



    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
            Destroy(rigidbody);
        }

        // Put the sphere back into its original local position.
        this.transform.localPosition = originalPosition;
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}