using UnityEngine;
using UnityEngine.UI;

public class ObjectSlider : MonoBehaviour
{
    private int currentIndex = 0;

    public bool isCubeSelected = true;

    // For Cube Pattern

    public Slider cubeSlider;

    public GameObject[] cubesToChange;

    // For Cube Pattern

    public Slider cuboidSlider;

    public GameObject[] cuboidsToChange;

    //For Exploder

    public Animation anim;
    
    public Slider animationSlider;    

    public AnimationClip[] cubeAnimationClips;

    private string cubeAnimationName;

    public Slider cuboidAnimationSlider;

    public AnimationClip[] cuboidAnimationClips;

    private string cuboidAnimationName;

    void Start()
    {
        ResetCubeSlider();

        UpdateSelectedObject();

        PlayCubeAnimations();
    }

    private void Update()
    {
        
    }

    private void ResetCubeSlider()
    {
        cubeSlider.minValue = 0;

        cubeSlider.maxValue = cubesToChange.Length;

        cubeSlider.value = currentIndex;
    }

    public void OnSliderValueChanged()
    {
        currentIndex = (int)cubeSlider.value;

        currentIndex = Mathf.Clamp(currentIndex, 0, cubesToChange.Length - 1);

        UpdateSelectedObject();
    }

    private void UpdateSelectedObject()
    {
        for (int i = 0; i < cubesToChange.Length; i++)
        {
            cubesToChange[i].SetActive(i == currentIndex);

            anim.clip = cubeAnimationClips[currentIndex];

            cubeAnimationName = anim.clip.name;

            PlayCubeAnimations();
        }
    }

    private void PlayCubeAnimations()
    {
        anim.Play(cubeAnimationName);

        anim[cubeAnimationName].speed = 0;
    }

    public void AnimateOnSliderValue()
    {
        anim[cubeAnimationName].normalizedTime = animationSlider.value;
    }

    // For Cuboid

    private void ResetCuboidSlider()
    {
        cuboidSlider.minValue = 0;

        cuboidSlider.maxValue = cuboidsToChange.Length;

        cuboidSlider.value = currentIndex;
    }

    public void OnCuboidSliderValueChanged()
    {
        currentIndex = (int)cuboidSlider.value;

        currentIndex = Mathf.Clamp(currentIndex, 0, cuboidsToChange.Length - 1);

        UpdateCuboidSelectedObject();
    }

    private void UpdateCuboidSelectedObject()
    {
        for (int i = 0; i < cuboidsToChange.Length; i++)
        {
            cuboidsToChange[i].SetActive(i == currentIndex);

            anim.clip = cuboidAnimationClips[currentIndex];

            cuboidAnimationName = anim.clip.name;

            PlayCuboidAnimations();
        }
    }

    private void PlayCuboidAnimations()
    {
        anim.Play(cuboidAnimationName);

        anim[cuboidAnimationName].speed = 0;
    }

    public void AnimateOnCuboidSliderValue()
    {
        anim[cuboidAnimationName].normalizedTime = cuboidAnimationSlider.value;
    }

    public void ActivateCube()
    {
        isCubeSelected = true;

        ChangeShape();
    }

    public void ActivateCuboid()
    {
        isCubeSelected = false;

        ChangeShape();
    }

    private void ChangeShape()
    {

        currentIndex = 0;

        if (isCubeSelected)
        {
            ResetCubeSlider();

            UpdateSelectedObject();

            PlayCubeAnimations();

            cubesToChange[currentIndex].SetActive(true); // Activate the current cube

            cuboidsToChange[currentIndex].SetActive(false);
        }
        else
        {
            ResetCuboidSlider();

            UpdateCuboidSelectedObject();

            PlayCuboidAnimations();

            cubesToChange[currentIndex].SetActive(false); // Deactivate the current cube

            cuboidsToChange[currentIndex].SetActive(true);
        }

        
    }
}


