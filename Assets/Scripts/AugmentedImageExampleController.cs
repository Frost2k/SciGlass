//-----------------------------------------------------------------------
// <copyright file="AugmentedImageExampleController.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    /// Controller for AugmentedImage example.
    public class AugmentedImageExampleController : MonoBehaviour
    {
        public GameObject FitToScanOverlay; // overlay containing the fit to scan user guide
        private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();

	public void Start()
	{
		FitToScanOverlay.SetActive(true);
	}

        /// The Unity Update method.
        public void Update()
        {
            // Check that motion tracking is tracking.
            if (Session.Status != SessionStatus.Tracking) return;

            // Get updated augmented images for this frame.
            Session.GetTrackables<AugmentedImage>(m_TempAugmentedImages, TrackableQueryFilter.Updated);
	    if (m_TempAugmentedImages.Count > 0 && m_TempAugmentedImages[0].Name == "test_earth") 
		SceneManager.LoadScene("SampleScene");
        }
    }
}
