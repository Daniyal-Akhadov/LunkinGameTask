using UnityEngine;

public class AIBotRepairing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var pillar = other.GetComponent<Pillar>();

        if (pillar != null)
        {
            Fix(pillar);
        }
    }

    public void Fix(Pillar pillar)
    {
        pillar.SetState(State.Fixed);
        pillar.SetColor(Color.gray);
    }
}
