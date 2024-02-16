using UnityEngine;

namespace Dependencies
{
    public class SceneDependenciesContainer : Dependency
    {
        //[SerializeField] private RaceStateTracker raceStateTracker;
        //[SerializeField] private CarInputControl carInputControl;
        //[SerializeField] private TrackpointCircuit trackpointCircuit;
        //[SerializeField] private Car car;
        //[SerializeField] private CarCameraController carCameraController;
        //[SerializeField] private RaceTimeTracker raceTimeTracker;
        //[SerializeField] private RaceResultTime raceResultTime;
        //[SerializeField] private RaceResultController raceResultController; 

        protected override void BindAll(MonoBehaviour monoBehaviourInScene)
        {
            //Bind<RaceStateTracker>(raceStateTracker, monoBehaviourInScene);

        }

        private void Awake()
        {
            FindAllObjectsToBind();
        }
    }
}