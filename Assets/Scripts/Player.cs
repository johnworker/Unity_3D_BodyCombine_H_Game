using UnityEngine ;

public class Player : MonoBehaviour {
   [SerializeField] private float moveSpeed ;
   [SerializeField] private float pushForce ;
   [SerializeField] private float cubeMaxPosX ;
   [Space]
   [SerializeField] private TouchSlider touchSlider ;

   //private Cube mainCube ;
   private BodyPart mainBody;

   private bool isPointerDown ;
   private bool canMove ;
   //private Vector3 cubePos ;
   private Vector3 bodyPos;

    private void Awake()
    {
        mainBody = GetComponent<BodyPart>();
    }

    private void Start () {
      SpawnNewBody();
      canMove = true ;

      // Listen to slider events:
      touchSlider.OnPointerDownEvent += OnPointerDown ;
      touchSlider.OnPointerDragEvent += OnPointerDrag ;
      touchSlider.OnPointerUpEvent += OnPointerUp ;
   }

   private void Update () {
      if (isPointerDown)
            mainBody.transform.position = Vector3.Lerp (
            mainBody.transform.position,
            bodyPos,
            moveSpeed * Time.deltaTime
         ) ;
   }

   private void OnPointerDown () {
      isPointerDown = true ;
   }

   private void OnPointerDrag (float xMovement) {
      if (isPointerDown) {
         bodyPos = mainBody.transform.position ;
         bodyPos.x = xMovement * cubeMaxPosX ;
      }
   }

   private void OnPointerUp () {
      if (isPointerDown && canMove) {
         isPointerDown = false ;
         canMove = false ;

         // Push the cube:
         mainBody.bodyPartRigidbody.AddForce (Vector3.back * pushForce, ForceMode.Impulse) ;

         Invoke ("SpawnNewCube", 0.3f) ;
      }
   }

   private void SpawnNewBody () {
      canMove = true ;
      SpawnBody();
   }

   private void SpawnBody() {

      // reset bodyPos variable
      bodyPos = mainBody.transform.position ;
   }

   private void OnDestroy () {
      //remove listeners:
      touchSlider.OnPointerDownEvent -= OnPointerDown ;
      touchSlider.OnPointerDragEvent -= OnPointerDrag ;
      touchSlider.OnPointerUpEvent -= OnPointerUp ;
   }
}
