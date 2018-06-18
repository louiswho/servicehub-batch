using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHub.Batch.Context.Utilities;
using ServiceHub.Batch.Service;
using System;
using System.Collections.Generic;
using System.Linq;

public static class SeedData
{
    private static ILogger logger;

    public static async void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<BatchRepository>();
        if (await context.GetAllBatchesAsync() == null || !(await context.GetAllBatchesAsync()).Any())
        {
            logger = ApplicationLogging.CreateLogger();

            try
            {
                await context.AddBatchAsync(
                    new ServiceHub.Batch.Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1804-apr09-net",
                        BatchOccupancy = 21,
                        BatchSkill = ".NET",
                        StartDate = new DateTime(2018, 4, 9),
                        EndDate = new DateTime(2018, 6, 22),
                        State = "FL",
                        UserIds = new List<Guid> {
                        new Guid("a043c475-a8ea-4421-bb6e-ee94289c67e5"),
                        new Guid("94060e03-7278-4d6a-a5ec-c22ae85cbb8b"),
                        new Guid("35e333b3-8f04-4093-907c-37e13078200f"),
                        new Guid("0c807213-8004-4323-a097-a9f023dce0ab"),
                        new Guid("d84bc0d6-8496-4cf0-bc5e-5f19c6ce01ca"),
                        new Guid("6d886dcc-3712-43bd-b372-f0d30143bde7"),
                        new Guid("53b54c1b-2030-489d-840b-38f11ecc6085"),
                        new Guid("a2c3b01c-fe5d-4b31-9822-39714f831412"),
                        new Guid("d94d0d9c-40d3-4b65-a852-a21742f5776f"),
                        new Guid("ff77467f-4d6b-441f-9662-8c2636293908"),
                        new Guid("e6c47b83-d608-46c1-bb19-9623f331f47d"),
                        new Guid("c71685b7-dca1-40f2-8f93-022c63a4622c"),
                        new Guid("37ab32cc-26df-478a-8cfa-cc9d3563a0f2"),
                        new Guid("8d76e671-814a-4d23-bd3b-8f55dc532a47"),
                        new Guid("b29dfabd-20c9-4a21-84cb-25dc9463a2b1"),
                        new Guid("be7e8bce-da50-4a07-961e-0a180e4b9303"),
                        new Guid("f2ddb323-1ac4-4049-baee-d1b1274e0070"),
                        new Guid("a6020109-cceb-43c0-abd5-56de213cb8b3"),
                        new Guid("e49e1fa0-9cde-4a80-a1b5-8b10918cad71"),
                        new Guid("822c472b-4ded-4a8f-ad8a-ffd7cede1b76"),
                        new Guid("2c3399ab-29a2-4c9b-98c0-7fb60d1400d9")
                        }
                    });

                await context.AddBatchAsync(
                new ServiceHub.Batch.Library.Models.Batch()
                {
                    BatchId = Guid.NewGuid(),
                    BatchName = "1803-mar26-dynamics",
                    BatchOccupancy = 22,
                    BatchSkill = "Dynamics",
                    StartDate = new DateTime(2018, 3, 26),
                    EndDate = new DateTime(2018, 6, 4),
                    State = "VA",
                    UserIds = new List<Guid> {
                        new Guid("b165e54e-30e3-4f5c-8f94-83e55d8acb3b"),
                        new Guid("d4b50c4c-06bd-46f7-824c-00329af3366d"),
                        new Guid("cbf7223e-8996-428e-a221-7b2030cbf2b4"),
                        new Guid("1fac76fd-7fa3-4417-90fa-23267000ae9a"),
                        new Guid("c329f3af-c302-4fe6-a73f-7f1f93815c17"),
                        new Guid("dcc68954-3dde-4b0b-afdc-65c32a27cc77"),
                        new Guid("724fb5ac-9edc-45a0-b16a-d180f44403b3"),
                        new Guid("22a3dcf1-a05f-46c7-a1f7-d813c0f8f729"),
                        new Guid("2ae4b78e-7405-4fe8-b476-3b11fbf9f9c2"),
                        new Guid("d99e449e-0d7a-4901-908f-9a1244a822e6"),
                        new Guid("fc55df63-467e-40fc-9165-c6b9b29b2c63"),
                        new Guid("3095a9bb-63e7-410f-adaa-83ee59b7d4b9"),
                        new Guid("70925a0c-89fd-4233-a23d-7b5fb80bef42"),
                        new Guid("d4d20c37-7ea9-41ad-84ba-2a0097200069"),
                        new Guid("33270a95-7591-444f-b3d0-c37c72473a8e"),
                        new Guid("2f7ae9f2-f528-4ffd-8738-7b5bd633bdc0"),
                        new Guid("d1a22a63-0c83-490d-84eb-3ce2107a1965"),
                        new Guid("10756f25-481e-43ba-b560-581159ee14ce"),
                        new Guid("5bc164a4-27fd-43ac-9e49-052a5b621b8a"),
                        new Guid("605a1e5d-49b3-400a-946c-d811a0d29454"),
                        new Guid("16eed2f4-627e-46a9-ba8d-684886decbfd"),
                        new Guid("522d473b-2294-4151-9b81-885cbcef8d82")
                        }
                });
                await context.AddBatchAsync(
                    new ServiceHub.Batch.Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1703-dec09-java",
                        BatchOccupancy = 17,
                        BatchSkill = "Java",
                        StartDate = new DateTime(2017, 12, 9),
                        EndDate = new DateTime(2018, 2, 23),
                        State = "VA",
                        UserIds = new List<Guid> {
                        new Guid("e33ab8fd-b784-412d-8408-0d7fa5d910be"),
                        new Guid("fa228d7a-3754-45cd-83b7-79c1e93996a7"),
                        new Guid("ead96b6c-de0d-4cf8-a112-516915abee8f"),
                        new Guid("6e35d28f-fd41-4230-a42e-82b3dbcccf04"),
                        new Guid("af9ea656-ab1b-4d01-94f1-8ad07960136d"),
                        new Guid("20a69a47-921b-42ff-a88f-83e71b5bdd06"),
                        new Guid("ce6af605-98bd-4bcc-97c4-9cfcd6781ecf"),
                        new Guid("2a1a98ea-12a6-4570-9202-e95a3eac6486"),
                        new Guid("5e371598-043c-4235-8c3b-aaf805cd5430"),
                        new Guid("788f76ef-09ca-4dfe-a527-408d1483c834"),
                        new Guid("0550e1a0-9ee8-487d-88b5-80f55744aeb2"),
                        new Guid("eafc925a-890f-4c94-8423-13178f9382dc"),
                        new Guid("9bf77209-a1cc-4bc5-be38-43c27ac8168a"),
                        new Guid("9681a308-e80d-41c4-af6a-b78b5b9c8fb2"),
                        new Guid("3991c055-25fb-4bfe-a00d-c5d18b381f34"),
                        new Guid("38954181-fe8c-4c72-be41-2324fd59530d"),
                        new Guid("67bb921c-b537-4b2c-833c-f219be6e5882")
                        }
                    });
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }
}