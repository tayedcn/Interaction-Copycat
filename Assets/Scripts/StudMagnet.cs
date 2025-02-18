using UnityEngine;

public class StudMagnet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stud"))
        {
            LegoStud stud = other.GetComponent<LegoStud>();
            if (stud != null)
            {
                stud.AttractToPlayer(transform);
            }
        }
    }
}
