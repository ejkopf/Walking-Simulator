using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SlidePosition : MonoBehaviour
{
    public Text steps;

    public GameObject ily;
    public GameObject unblockme;
    public GameObject roomie;
    public GameObject jay;

    private Vector3 slide1pos;
    private Vector3 slide2pos;
    private Vector3 slide3pos;
    private Vector3 slide4pos;

    private Vector3 initialslide1pos;

    private GameObject[] slides;

    private bool[] done = new bool[1000];

    // Start is called before the first frame update
    void Start()
    {
        slide1pos = unblockme.transform.position;
        slide2pos = roomie.transform.position;
        slide3pos = ily.transform.position;
        slide4pos = jay.transform.position;

        initialslide1pos = unblockme.transform.position;
        Debug.Log(initialslide1pos.z);

        slides = new GameObject[4];
        slides[0] = ily;
        slides[1] = unblockme;
        slides[2] = roomie;
        slides[3] = jay;
    }

    // Update is called once per frame
    void Update()
    {
        int stepCount = 0;
        int.TryParse(steps.text, out stepCount);

        /* Debug.Log(0.8f * stepCount);
        slide1pos = new Vector3(slide1pos.x, slide1pos.y, initialslide1pos.z + (0.8f * stepCount));
        slide2pos = new Vector3(slide2pos.x, slide2pos.y, initialslide1pos.z + (0.8f * stepCount));
        slide3pos = new Vector3(slide3pos.x, slide3pos.y, initialslide1pos.z + (0.8f * stepCount));
        slide4pos = new Vector3(slide4pos.x, slide4pos.y, initialslide1pos.z + (0.8f * stepCount)); */

        if (stepCount >= 25 && stepCount <= 75)
        {
            /* if (!done[25])
            {
                slide1pos = unblockme.transform.position;
                slide2pos = roomie.transform.position;
                slide3pos = ily.transform.position;
                slide4pos = jay.transform.position;

                roomie.transform.position = slide1pos;
                unblockme.transform.position = slide2pos;
                ily.transform.position = slide3pos;
                jay.transform.position = slide4pos;

                done[25] = true;
            }
            if (done[25] && !done[50] && stepCount == 50)
            {
                slide1pos = unblockme.transform.position;
                slide2pos = roomie.transform.position;
                slide3pos = ily.transform.position;
                slide4pos = jay.transform.position;

                roomie.transform.position = slide1pos;
                unblockme.transform.position = slide2pos;
                ily.transform.position = slide3pos;
                jay.transform.position = slide4pos;

                done[50] = true;
            } */
        }
        if (stepCount >= 200 && stepCount < 250)
        {
            if (!done[30])
            {
                if (ily.transform.position.y > roomie.transform.position.y)
                {
                    slide1pos = ily.transform.position;
                    slide2pos = roomie.transform.position;
                }
                else if (ily.transform.position.y < roomie.transform.position.y)
                {
                    slide1pos = roomie.transform.position;
                    slide2pos = ily.transform.position;
                }
                slide3pos = unblockme.transform.position;
                slide4pos = jay.transform.position;
                done[30] = true;

                // ily slide top
                ily.transform.position = slide1pos;
                roomie.transform.position = slide1pos;
                unblockme.transform.position = slide2pos;
                jay.transform.position = slide4pos;
            }
        }
        if ((stepCount >= 75 && stepCount < 200) || stepCount == 100 || stepCount == 125 || stepCount == 150 || stepCount == 175 || stepCount > 250 || stepCount == 340)
        {
            if (!done[57])
            {
                if (ily.transform.position.y > roomie.transform.position.y)
                {
                    slide1pos = ily.transform.position;
                    slide2pos = roomie.transform.position;
                }
                else if (ily.transform.position.y < roomie.transform.position.y)
                {
                    slide1pos = roomie.transform.position;
                    slide2pos = ily.transform.position;
                }
                slide3pos = unblockme.transform.position;
                slide4pos = jay.transform.position;

                jay.transform.position = slide1pos;
                ily.transform.position = slide2pos;
                roomie.transform.position = slide3pos;
                unblockme.transform.position = slide4pos;

                done[57] = true;
            }
        }
        if (stepCount == 76 || stepCount == 101 || stepCount == 126 || stepCount == 151 || stepCount == 176 || stepCount == 251 || stepCount == 341)
        {
            done[57] = false;
        }

        /* if (stepCount == 25 || stepCount == 50)
        {
            // roomie slide top
            if (!done[25])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != roomie) 
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > roomie.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > roomie.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[25] = true;
            }
            if (done[25] && !done[50] && stepCount == 50)
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != roomie)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > roomie.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > roomie.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[50] = true;
            }

            roomie.transform.position = slide1pos;
        }
        if (stepCount == 200)
        {
            // ily slide top
            if (!done[1])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != ily)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > ily.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > ily.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[1] = true;
            }

            ily.transform.position = slide1pos;
        }
        if (stepCount == 75 || stepCount == 100 || stepCount == 125 || stepCount == 150 || stepCount == 175 || stepCount == 250 || stepCount == 340)
        {
            //jay slide top
            if (stepCount == 75 && !done[75])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[75] = true;
            }
            if (stepCount == 100 && !done[100])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[100] = true;
            }
            if (stepCount == 125 && !done[125])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[125] = true;
            }
            if (stepCount == 150 && !done[150])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[150] = true;
            }
            if (stepCount == 175 && !done[175])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[175] = true;
            }
            if (stepCount == 250 && !done[250])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[250] = true;
            }
            if (stepCount == 300 && !done[300])
            {
                foreach (GameObject slide in slides)
                {
                    if (slide.transform.position == slide1pos && slide != jay)
                    {
                        slide.transform.position = slide2pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide3pos;
                    }
                    else if ((slide.transform.position == slide2pos) && (slide.transform.position.y > jay.transform.position.y))
                    {
                        slide.transform.position = slide4pos;
                    }
                }

                done[300] = true;
            }

            jay.transform.position = slide1pos;
        }*/
    }
}
