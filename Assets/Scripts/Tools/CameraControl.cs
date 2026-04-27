using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Tools
{
    public class CameraControl
    {
        private Camera cam = Camera.main;
        public Camera Cam { get => cam; }

        public void SetupCamera(int wid, int he)
        {
            int width;
            int height;

            if (wid > 6)
                width = 6;
            else 
                width = wid;

            if (he > 6)
                height = 6;
            else 
                height = he;

            cam.orthographic = false;
            cam.fieldOfView = 35f;
            cam.transform.rotation = Quaternion.Euler(50, 0, 0);
            cam.transform.position = new Vector3 (width * HexMetrics.innerRadius, 95f, -50f);

        }

    }
}
