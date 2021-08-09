using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Mandelbrot : MonoBehaviour
{
    double height, width;
    double rStart, iStart;
    int maxIterations;
    int zoom;

    Texture2D displayTexture;
    public Image myImage;

    // Start is called before the first frame update
    void Start()
    {
        width = 4.5;
        height = width * (Screen.height / Screen.width);
        rStart = -2.0;
        iStart = -1.25;
        zoom = 10;
        maxIterations = 100;

        displayTexture = new Texture2D(Screen.width, Screen.height);

        RunMandelbrot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rStart = rStart + (Input.mousePosition.x - (Screen.width / 2.0)) / Screen.width * width;
            iStart = iStart + (Input.mousePosition.y - (Screen.height / 2.0)) / Screen.height * height;

            RunMandelbrot();
        }

        if (Input.GetMouseButtonDown(0))
        {
            double wFactor = width * 5 / zoom;
            double hFactor = height * 5 / zoom;

            width -= wFactor;
            height -= hFactor;
            rStart += wFactor / 2.0;
            iStart += hFactor / 2.0;
            RunMandelbrot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            double wFactor = width * -5 / zoom;
            double hFactor = height * -5 / zoom;

            width -= wFactor;
            height -= hFactor;
            rStart += wFactor / 2.0;
            iStart += hFactor / 2.0;

            RunMandelbrot();
        }
    }

    private int MandelbrotFunction(double x, double y)
    {
        int iteration = 0;

        Complex z = new Complex(0, 0);
        Complex c = new Complex(x, y);

        for (int i = 0; i < maxIterations; i++)
        {
            z = z * z + c; // z2 = z1^2 + c

            if (Complex.Abs(z) > 2)
            {
                break;
            }
            else
                iteration++;
        }

        return iteration;
    }

    private void RunMandelbrot()
    {
        for (int x = 0; x < displayTexture.width; x++)
        {
            for (int y = 0; y < displayTexture.height; y++)
            {
                double mandelbrotX = rStart + width * x / displayTexture.width;
                double mandelbrotY = iStart + height * y / displayTexture.height;

                displayTexture.SetPixel(x, y, SetColor(MandelbrotFunction(mandelbrotX, mandelbrotY)));
            }
        }

        displayTexture.Apply();
        myImage.sprite = Sprite.Create(displayTexture, new Rect(0, 0, displayTexture.width, displayTexture.height),
            new UnityEngine.Vector2(0.5f, 0.5f));
    }

    private Color SetColor(int value)
    {
        UnityEngine.Vector4 calcColor = new UnityEngine.Vector4(0, 0, 0, 1f);

        if(value < maxIterations)
        {
            int colorNo = value % 16;

            switch (colorNo)
            {
                case 0:
                    {
                        calcColor[0] = 66.0f / 255.0f;
                        calcColor[1] = 30.0f / 255.0f;
                        calcColor[2] = 15.0f / 255.0f;

                        break;
                    }

                case 1:
                    {
                        calcColor[0] = 25.0f / 255.0f;
                        calcColor[1] = 7.0f / 255.0f;
                        calcColor[2] = 26.0f / 255.0f;

                        break;
                    }

                case 2:
                    {
                        calcColor[0] = 9.0f / 255.0f;
                        calcColor[1] = 1.0f / 255.0f;
                        calcColor[2] = 47.0f / 255.0f;

                        break;
                    }

                case 3:
                    {
                        calcColor[0] = 4.0f / 255.0f;
                        calcColor[1] = 4.0f / 255.0f;
                        calcColor[2] = 73.0f / 255.0f;

                        break;
                    }

                case 4:
                    {
                        calcColor[0] = 0.0f / 255.0f;
                        calcColor[1] = 7.0f / 255.0f;
                        calcColor[2] = 100.0f / 255.0f;

                        break;
                    }

                case 5:
                    {
                        calcColor[0] = 12.0f / 255.0f;
                        calcColor[1] = 44.0f / 255.0f;
                        calcColor[2] = 138.0f / 255.0f;

                        break;
                    }

                case 6:
                    {
                        calcColor[0] = 24.0f / 255.0f;
                        calcColor[1] = 82.0f / 255.0f;
                        calcColor[2] = 177.0f / 255.0f;

                        break;
                    }

                case 7:
                    {
                        calcColor[0] = 57.0f / 255.0f;
                        calcColor[1] = 125.0f / 255.0f;
                        calcColor[2] = 209.0f / 255.0f;

                        break;
                    }

                case 8:
                    {
                        calcColor[0] = 134.0f / 255.0f;
                        calcColor[1] = 181.0f / 255.0f;
                        calcColor[2] = 229.0f / 255.0f;

                        break;
                    }

                case 9:
                    {
                        calcColor[0] = 211.0f / 255.0f;
                        calcColor[1] = 236.0f / 255.0f;
                        calcColor[2] = 248.0f / 255.0f;

                        break;
                    }

                case 10:
                    {
                        calcColor[0] = 241.0f / 255.0f;
                        calcColor[1] = 233.0f / 255.0f;
                        calcColor[2] = 191.0f / 255.0f;

                        break;
                    }

                case 11:
                    {
                        calcColor[0] = 248.0f / 255.0f;
                        calcColor[1] = 201.0f / 255.0f;
                        calcColor[2] = 95.0f / 255.0f;

                        break;
                    }

                case 12:
                    {
                        calcColor[0] = 255.0f / 255.0f;
                        calcColor[1] = 170.0f / 255.0f;
                        calcColor[2] = 0.0f / 255.0f;

                        break;
                    }

                case 13:
                    {
                        calcColor[0] = 204.0f / 255.0f;
                        calcColor[1] = 128.0f / 255.0f;
                        calcColor[2] = 0.0f / 255.0f;

                        break;
                    }

                case 14:
                    {
                        calcColor[0] = 153.0f / 255.0f;
                        calcColor[1] = 87.0f / 255.0f;
                        calcColor[2] = 0.0f / 255.0f;

                        break;
                    }

                case 15:
                    {
                        calcColor[0] = 106.0f / 255.0f;
                        calcColor[1] = 52.0f / 255.0f;
                        calcColor[2] = 3.0f / 255.0f;

                        break;
                    }
            }
        }

        return calcColor;
    }
}
