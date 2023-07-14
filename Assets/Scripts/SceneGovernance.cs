using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGovernance : MonoBehaviour
{
    public void loadHub()
    {
        SceneManager.LoadScene(0);
    }

    public void loadChemicalPlant()
    {
        SceneManager.LoadScene(1);
    }

    public void loadWeldingWorkshop()
    {
        SceneManager.LoadScene(2);
    }

    public void quitSimulation()
    {
        Application.Quit();
    }
}
