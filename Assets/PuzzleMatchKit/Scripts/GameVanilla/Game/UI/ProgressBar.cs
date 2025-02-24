// Copyright (C) 2017 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;
using UnityEngine.UI;

namespace GameVanilla.Game.UI
{
    /// <summary>
    /// This class manages the in-game progress bar.
    /// </summary>
    public class ProgressBar : MonoBehaviour
    {
        public Image progressBarImage;
        public ProgressStar star1Image;
        public ProgressStar star2Image;
        public ProgressStar star3Image;

        public int star1;
        public int star2;
        public int star3;

        /// <summary>
        /// Sets the data for the progress bar.
        /// </summary>
        /// <param name="score1">The score to reach the first star.</param>
        /// <param name="score2">The score to reach the second star.</param>
        /// <param name="score3">The score to reach the third star.</param>
        public void Fill(int score1, int score2, int score3)
        {
            progressBarImage.fillAmount = 0;

            star1 = score1;
            star2 = score2;
            star3 = score3;

            UpdateProgressBar(0);
        }

        /// <summary>
        /// Updates the progress bar with the specified score.
        /// </summary>
        /// <param name="score">The current score.</param>
        public void UpdateProgressBar(int score)
        {
            progressBarImage.fillAmount = GetProgressValue(score) / 100.0f;

            if (score >= star1)
            {
                star1Image.Activate();
            }
            if (score >= star2)
            {
                star2Image.Activate();
            }
            if (score >= star3)
            {
                star3Image.Activate();
            }

            star1Image.transform.localPosition = progressBarImage.transform.localPosition +
                                                 new Vector3(
                                                     progressBarImage.rectTransform.rect.width *
                                                     (GetProgressValue(star1) / 100.0f) - 10.0f, 0, 0);
            star2Image.transform.localPosition = progressBarImage.transform.localPosition +
                                                 new Vector3(
                                                     progressBarImage.rectTransform.rect.width *
                                                     (GetProgressValue(star2) / 100.0f) - 10.0f, 0, 0);
            star3Image.transform.localPosition = progressBarImage.transform.localPosition +
                                                 new Vector3(progressBarImage.rectTransform.rect.width - 10.0f, 0, 0);
        }

        /// <summary>
        /// Returns the progress of the bar at the specified value.
        /// </summary>
        /// <param name="value">The value to use as a reference for the progress.</param>
        /// <returns></returns>
        private int GetProgressValue(int value)
        {
            const int oldMin = 0;
            var oldMax = star3;
            const int newMin = 0;
            const int newMax = 100;
            var oldRange = oldMax - oldMin;
            const int newRange = newMax - newMin;
            var newValue = (((value - oldMin) * newRange) / oldRange) + newMin;
            return newValue;
        }
    }
}
