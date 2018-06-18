using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using ServiceHub.Batch.Context.Utilities;
using System.Threading.Tasks;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace ServiceHub.Batch.Testing.Service
{
    public class BatchControllerTest : IAsyncLifetime
    {
        /// <summary>
        /// Initialize dummy data Address and Batch models
        /// </summary>
        Batch.Library.Models.Batch testBatch1;
        Batch.Library.Models.Batch testBatch2;
        Batch.Library.Models.Batch testBatch3;

        static ILoggerFactory loggerFactory = new LoggerFactory();
        Batch.Service.Controllers.BatchController controller = new Batch.Service.Controllers.BatchController(new MemoryUtility(), loggerFactory);

        public async Task InitializeAsync()
        {
            await controller.storage.AddBatchAsync(testBatch1);
            await controller.storage.AddBatchAsync(testBatch2);
            await controller.storage.AddBatchAsync(testBatch3);
        }

        public async Task DisposeAsync()
        {
            await controller.storage.DeleteBatchAsync(testBatch1.BatchId);
            await controller.storage.DeleteBatchAsync(testBatch2.BatchId);
            await controller.storage.DeleteBatchAsync(testBatch3.BatchId);
        }
        /// <summary>
        /// Instantiate dummy Address and Batch models
        /// </summary>
        /// 
        public BatchControllerTest()
        {
            testBatch1 = new Batch.Library.Models.Batch()
            {

                BatchId = Guid.NewGuid(),
                BatchName = "1703-dec09-java",
                BatchOccupancy = 17,
                BatchSkill = "Test2",
                StartDate = new DateTime(2017, 12, 9),
                EndDate = new DateTime(2018, 2, 23),
                State = "AK",
                UserIds = new List<Guid> {
                        new Guid("e33ab8fd-b784-412d-8408-0d7fa5d910be")
                }

            };
            testBatch2 = new Batch.Library.Models.Batch()
            {
                BatchId = Guid.NewGuid(),
                BatchName = "1804-apr09-net",
                BatchOccupancy = 21,
                BatchSkill = "Test1",
                StartDate = new DateTime(2018, 4, 9),
                EndDate = new DateTime(2018, 6, 22),
                State = "HI",
                UserIds = new List<Guid> {
                        new Guid("a043c475-a8ea-4421-bb6e-ee94289c67e5")
                }

            };
            testBatch3 = new Batch.Library.Models.Batch()
            {
                BatchId = Guid.NewGuid(),
                BatchName = "1803-mar26-dynamics",
                BatchOccupancy = 22,
                BatchSkill = "Test2",
                StartDate = new DateTime(2018, 3, 26),
                EndDate = new DateTime(2018, 6, 4),
                State = "AK",
                UserIds = new List<Guid> {
                        new Guid("b165e54e-30e3-4f5c-8f94-83e55d8acb3b")
                }
            };
        }

        /// <summary>
        /// Test getting all batches from the database. Compare dummy data from MemoryUtility to BatchController.Get()
        /// </summary>
        [Fact]
        async Task GetAllTest()
        {
            List<Batch.Library.Models.Batch> newBatch = new List<Batch.Library.Models.Batch>();
            newBatch = await controller.storage.GetAllBatchesAsync();

            List<Batch.Library.Models.Batch> newBatch2 = new List<Batch.Library.Models.Batch>();
            var actionResultTask = await controller.Get();
            var res = actionResultTask as OkObjectResult;
            var result = res.Value;
            newBatch2 = (List<Batch.Library.Models.Batch>)result;
            Assert.Equal(newBatch.Count, newBatch2.Count);

        }

        /// <summary>
        /// Create object for test GetBySkill
        /// </summary>
        public static readonly ImmutableList<object[]> SkillTestCases = ImmutableList.Create
        (
            new object[] { "Test1", 1 },
            new object[] { "Test2", 2 }
        );
        /// <summary>
        /// Compare expected return with actual return from GetBySkill(string skill)
        /// </summary>
        /// <param name="skill">Test "Test1" input and "Test2" input</param>
        [Theory]
        [MemberData(nameof(SkillTestCases))]
        async Task GetBySkillTest(string skill, int num)
        {
            List<Batch.Library.Models.Batch> testC = new List<Batch.Library.Models.Batch>();
            var batchSkill = await controller.GetBySkill(skill);
            var res = batchSkill as OkObjectResult;
            var result = res.Value;
            testC = (List<Batch.Library.Models.Batch>)result;

            Assert.Equal(num, testC.FindAll(x => x.BatchSkill == skill).Count);
        }

        /// <summary>
        /// Compare expected result with result from GetByLocation(string state)
        /// </summary>
        [Fact]
        async Task GetByLocationTest()
        {

            List<Batch.Library.Models.Batch> testL = new List<Batch.Library.Models.Batch>();
            var batchLocation = await controller.GetByLocation("AK");
            var res = batchLocation as OkObjectResult;
            var result = res.Value;
            testL = (List<Batch.Library.Models.Batch>)result;

            Assert.Equal(2, testL.Count);
        }
    }
}