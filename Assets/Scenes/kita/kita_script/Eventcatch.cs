public class Eventcatch : MonoBehaviour
{
    public Eventcatch Instance { get; private set; }
    public GameObject button;

    public bool isHit;

    void OnTrrigerEnter(Colider collision)
    {
       
       button.SetActive(true);
       isHit = true;
    }
}

