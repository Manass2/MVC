using SEDC.PizzaApp.ViewModels.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IFeedbackService
    {
        List<FeedbackViewModel> GetAllFeedbacks();
        bool FeedbackNumberValidation(string email);
        void CreateFeedback(FeedbackViewModel feedbackViewModel);
        FeedbackViewModel GetFeedbackForEditing(int value);
        void EditFeedback(FeedbackViewModel feedbackViewModel);
        FeedbackViewModel GetFeedbackId(int value);
        void DeleteFeedback(int id);
    }
}
