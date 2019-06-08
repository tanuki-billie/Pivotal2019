using UnityEngine;

namespace ElementStudio.Pivotal.Menu
{
    public class FeedbackButton : MonoBehaviour
    {
        public string feedbackURL;
        public void OpenFeedback()
        {
            Application.OpenURL(feedbackURL);
        }
    }
}