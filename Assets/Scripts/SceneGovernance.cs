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

    public void loadWeldingWorkshopModuleTwo()
    {
        SceneManager.LoadScene(3);
    }
    
    public void loadWeldingWorkshopModuleThree()
    {
        SceneManager.LoadScene(4);
    }

    public void loadWeldingWorkshopModuleFour()
    {
        SceneManager.LoadScene(5);
    }

    public void loadWeldingWorkshopModuleFive()
    {
        SceneManager.LoadScene(6);
    }

    public void loadWeldingWorkshopModuleSix()
    {
        SceneManager.LoadScene(7);
    }

    public void loadWeldingWorkshopModuleSeven()
    {
        SceneManager.LoadScene(8);
    }

    public void loadWeldingWorkshopModuleEight()
    {
        SceneManager.LoadScene(9);
    }

    public void loadWeldingWorkshopModuleNine()
    {
        SceneManager.LoadScene(10);
    }

    public void loadWeldingWorkshopModuleTen()
    {
        SceneManager.LoadScene(11);
    }

    public void loadWeldingWorkshopAssessmentScene()
    {
        SceneManager.LoadScene(12);
    }

    public void quitSimulation()
    {
        Application.Quit();
    }
}
