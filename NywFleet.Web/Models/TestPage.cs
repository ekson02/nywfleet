using System.Collections.Generic;

namespace NywFleet.Web.Models {
    public class TestPage {
        public string Titile { get; set; }
        public int TestId { get; set; }
        public int TestVersionId { get; set; }
        public string UserId { get; set; }
        public string Descriptions { get; set; }
        public bool IsCompleted { get; set; }
        public string TestResultUrl { get; set; }
        //public LookCategories CurrentCategory { get; set; }
        //public LookCategories NextCategory { get; set; }
        //public List<Question> Questions { get; set; }

    }
}