﻿namespace NywFleet.Data.Contracts {
    public interface IFleetUow {
        //IRepository<Question> Questions { get; }
        //IRepository<Answer> QuestionAnswers { get; }
        //IRepository<TestConfiguration> TestConfigurations { get; }
        //IRepository<TestVersion> TestVersions { get; }
        //IRepository<UserTest> UserTests { get; }
        //IRepository<UserTestAnswer> UserTestAnswers { get; }
        //IRepository<LookCategories> Categories { get; }
        //IRepository<LookTestTypeCodes> TestTypeCodes { get; }

        int? UserId { get; set; }

        void Commit();
    }
}