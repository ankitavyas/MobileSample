using MobileApp.Enum;

namespace MobileApp.Models
{
    public class Feedback : BaseDataObject
	{
        FeedbackCategoryEnum category = FeedbackCategoryEnum.General;
		public FeedbackCategoryEnum Category
		{
			get { return category; }
			set { SetProperty(ref category, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}
	}
}
