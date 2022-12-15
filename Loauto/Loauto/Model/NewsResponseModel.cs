using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loauto.Model
{
    class NewsResponseModel
    {
        public EventModel[] Results;
        public class EventModel
        {
            string title;
            string thumbnail;
            string link;
            string startDate;
            string endDate;
            string rewardDate;

            public string Title { get => title; set => title = value; }
            public string Thumbnail { get => thumbnail; set => thumbnail = value; }
            public string Link { get => link; set => link = value; }
            public string StartDate { get => startDate; set => startDate = value; }
            public string EndDate { get => endDate; set => endDate = value; }
            public string RewardDate { get => rewardDate; set => rewardDate = value; }
        }
    }
}
