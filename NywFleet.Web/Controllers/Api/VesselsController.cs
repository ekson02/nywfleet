using System.Linq;
using System.Web.Http;

namespace NywFleet.Web.Controllers.Api {
    [Authorize]
    public class VesselsController : BaseApiController {

        public IHttpActionResult Get() {
            var vessels = Uow.Vessels.Query().Where(p => p.IsActive).OrderBy(p => p.VesselName).ToList();
            return Ok(vessels);
        }

        public IHttpActionResult Get(int id) {
            var vessels = Uow.Vessels.GetAllWithInclude(p => p.VesselEngines)
                .FirstOrDefault(p => p.VesselId == id);
            return Ok(vessels);
        }


        //public IHttpActionResult Post(LookTestTypeCodes testType) {
        //    var url = Request.GetRequestContext().VirtualPathRoot;
        //    var testTypeInfo = Uow.TestTypeCodes.Query().FirstOrDefault(p => p.TestTypeCd == testType.TestTypeCd);
        //    if (testTypeInfo == null) {
        //        return NotFound();
        //    }
        //    var activeTestVersion = Uow.TestVersions.Query().FirstOrDefault(p => p.TestTypeCd == testType.TestTypeCd && p.IsActive);
        //    if (activeTestVersion == null) {
        //        return NotFound();
        //    }

        //    var questions = Uow.TestConfigurations.GetAllWithInclude(p => p.Question, p => p.Question.Answers).Where(p => p.TestVersionId == activeTestVersion.TestVersionId).OrderBy(p => p.DisplaySeq).Select(p => p.Question).ToList();
        //    var response = InitTestPage(questions, activeTestVersion.TestVersionId);

        //    var userTest = new UserTest {
        //        TestVersionId = activeTestVersion.TestVersionId,
        //        TestTypeCd = testType.TestTypeCd,
        //        UserId = User.Identity.GetUserId(),
        //        CreatedOn = DateTime.Now
        //    };

        //    Uow.UserTests.Add(userTest);
        //    Uow.Commit();
        //    response.TestId = userTest.UserTestId;
        //    response.Titile = testTypeInfo.DisplayName;

        //    response.Descriptions = testTypeInfo.IntroText;
        //    return Ok(response);
        //}

        //public IHttpActionResult Put(TestPageAnswer model) {
        //    var categoryAnswer = JsonConvert.SerializeObject(model.Answers);
        //    var answer = Uow.UserTestAnswers.Query().FirstOrDefault(p => p.UserTestId == model.TestId && p.CategoryCd == model.CurrentCategoryCode);
        //    if (answer == null) {
        //        answer = new UserTestAnswer {
        //            UserTestId = model.TestId,
        //            CategoryCd = model.CurrentCategoryCode,
        //            Answer = categoryAnswer
        //        };
        //        Uow.UserTestAnswers.Add(answer);
        //    } else {
        //        answer.Answer = categoryAnswer;
        //        Uow.UserTestAnswers.Update(answer);
        //    }
        //    Uow.Commit();

        //    var questions = Uow.TestConfigurations.GetAllWithInclude(p => p.Question, p => p.Question.Answers).Where(p => p.TestVersionId == model.TestVersionId).OrderBy(p => p.DisplaySeq).Select(p => p.Question).ToList();
        //    var response = InitTestPage(questions, model.TestVersionId, model.CurrentCategoryCode);
        //    response.TestId = model.TestId;
        //    if (response.IsCompleted) {
        //        response.TestResultUrl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Authority}/user/reports/details/{model.TestId}";
        //        var test = Uow.UserTests.GetAllWithInclude(p => p.UserTestAnswers).FirstOrDefault(p => p.UserTestId == model.TestId && p.UserId == CurrentUserId);
        //        if (test != null) {
        //            TestScoreService.Calculate(test);
        //            Uow.UserTests.Update(test);
        //            Uow.Commit();
        //        }


        //    }
        //    return Ok(response);
        //}

        //private TestPage InitTestPage(List<Question> questions, int testVersionId, string currentCategory = "") {
        //    TestPage response = new TestPage { TestVersionId = testVersionId };
        //    var testCategoryOrdered = questions.DistinctBy(p => p.CategoryCd).Select(p => p.CategoryCd).ToArray();
        //    int currentStep = 0;
        //    if (!string.IsNullOrEmpty(currentCategory)) {
        //        currentStep = Array.IndexOf(testCategoryOrdered, currentCategory);

        //        if (currentStep < testCategoryOrdered.Length - 1) {
        //            currentStep += 1;
        //        } else if (currentStep == testCategoryOrdered.Length - 1) {
        //            response.IsCompleted = true;
        //        }
        //    }
        //    var categories = Uow.Categories.Query().ToList();
        //    response.CurrentCategory = categories.FirstOrDefault(p => p.CategoryCd == testCategoryOrdered.ElementAt(currentStep));
        //    if (currentStep < testCategoryOrdered.Length - 1) {
        //        response.NextCategory = categories.FirstOrDefault(p => p.CategoryCd == testCategoryOrdered.ElementAt(currentStep + 1));
        //    }


        //    response.Questions = questions.Where(p => p.CategoryCd == response.CurrentCategory.CategoryCd).ToList();

        //    return response;
        //}
    }
}
