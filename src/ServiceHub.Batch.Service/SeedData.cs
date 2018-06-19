using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHub.Batch.Context.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Service
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BatchRepository>();
            var batches = await context.GetAllBatchesAsync();
            if (batches == null || !batches.Any())
            {
                ILogger logger = ApplicationLogging.CreateLogger();

                try
                {
                    await context.AddBatchAsync(new Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1804-apr09-net",
                        BatchOccupancy = 13,
                        BatchSkill = ".NET",
                        StartDate = new DateTime(2018, 4, 9),
                        EndDate = new DateTime(2018, 6, 22),
                        State = "FL",
                        UserIds = new List<Guid>
                        {
                            new Guid("26aa13da-2d5a-483b-b56c-75e21f22ee42"),
                            new Guid("fd4f8420-98bc-4bb1-9b4b-32e815ea1435"),
                            new Guid("9ed57e9d-c2dc-46fd-a807-5d24fead27d5"),
                            new Guid("3c5ddd41-7f8f-4f62-bd6a-cce52a17c935"),
                            new Guid("ccb93b16-7457-473d-9b60-ed7cd1a79a70"),
                            new Guid("8b7991d3-873c-47dc-b13e-9368f3075eb2"),
                            new Guid("e570d479-7ebb-4fd3-a84e-0ac4737df5e8"),
                            new Guid("ce670145-931d-489c-90ba-dd4d4955c197"),
                            new Guid("a35bc0fb-acb7-4bb1-994b-91bd0acec816"),
                            new Guid("a482586c-4e34-4777-bb39-e955d14b7056"),
                            new Guid("2445983c-6bfb-4fe1-ab40-2075c00b10e9"),
                            new Guid("5020bfb2-3b39-4a01-99e4-d911ec5b1774"),
                            new Guid("4bd42f54-183c-4fd8-845b-17c368527d42")
                        }
                    });
                    await context.AddBatchAsync(new Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1803-mar26-dynamics",
                        BatchOccupancy = 13,
                        BatchSkill = "DYNAMICS",
                        StartDate = new DateTime(2018, 3, 26),
                        EndDate = new DateTime(2018, 6, 4),
                        State = "VA",
                        UserIds = new List<Guid>
                        {
                            new Guid("5e6af9dc-775b-48f2-bb6a-d19fd93abddb"),
                            new Guid("4ace15a2-cba2-4a8b-b7d2-9f31581a6fce"),
                            new Guid("57674adc-57d4-484a-975a-fd29237dd1e0"),
                            new Guid("90378852-6aba-4826-8bfc-a5c02162acce"),
                            new Guid("ee86b5b2-44e7-421a-841e-ae845ca0650f"),
                            new Guid("6d257113-9410-4689-8867-aabfc4e0bec4"),
                            new Guid("d9183b0a-85b9-4d83-b1f6-13ec73473424"),
                            new Guid("a863073b-fba7-44fd-97a3-0bbc5eb57d29"),
                            new Guid("88648c77-4a03-4daa-a074-ce70de3de19f"),
                            new Guid("47ecd86a-0141-4afc-badf-4937b888f9c2"),
                            new Guid("f16c4cdd-bf6a-459c-8cb7-bb637f2f18e8"),
                            new Guid("49d32e96-dcf3-4487-824e-817282db9e78"),
                            new Guid("c9fc2cc0-12e4-414c-863a-0afaa52819a6")
                        }
                    });
                    await context.AddBatchAsync(new Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1703-dec09-java",
                        BatchOccupancy = 15,
                        BatchSkill = "JAVA",
                        StartDate = new DateTime(2017, 12, 9),
                        EndDate = new DateTime(2018, 2, 23),
                        State = "VA",
                        UserIds = new List<Guid>
                        {
                            new Guid("5810f156-35cd-4a62-b1ff-178fe49911a3"),
                            new Guid("f0262d14-23f8-4ae8-8cef-b49cedd078a1"),
                            new Guid("a357c17c-046f-43be-bbd2-92b66a3a7a32"),
                            new Guid("82605602-d7d5-4411-92f1-399b1cf8dd75"),
                            new Guid("ea943cce-522f-447b-9d8d-61427d1498ee"),
                            new Guid("ec8a60b1-12a3-4164-8ea2-edbafb90dbfb"),
                            new Guid("3552bef0-2dda-47b5-a40d-37d252c2d211"),
                            new Guid("12eb725b-1816-4049-8d01-b18314befe65"),
                            new Guid("960327df-a3cc-4d12-aff6-85c68b9bf750"),
                            new Guid("f77f606f-4c0a-4357-807b-f00c1214fdd6"),
                            new Guid("22a25910-91d5-4405-b559-0ce2b8224452"),
                            new Guid("35d12491-3f9f-4e65-8c1a-686102ca33a7"),
                            new Guid("437514f7-2abe-466b-a4e7-d915cddb6a65"),
                            new Guid("0ae84039-ef61-4f93-91f1-6ddb67dbf7ae"),
                            new Guid("7369cd0a-26ad-4b6c-aafe-053613625743")
                        }
                    });
                    await context.AddBatchAsync(new Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1205-mar09-java",
                        BatchOccupancy = 14,
                        BatchSkill = "JAVA",
                        StartDate = new DateTime(2018, 3, 9),
                        EndDate = new DateTime(2018, 5, 25),
                        State = "NY",
                        UserIds = new List<Guid>
                        {
                            new Guid("17936ce0-4ce2-45fc-90a9-583a75289dc2"),
                            new Guid("f6f68e46-20b0-4758-9c6b-10b1e1fba4cb"),
                            new Guid("48cbb3a0-a9ba-41a3-9a79-c3ad8f1bf3ff"),
                            new Guid("3386482d-3db4-4a48-b360-e8ead9a908a2"),
                            new Guid("9ea24f7c-39d8-4a63-98c7-7478eed4e27d"),
                            new Guid("e8c81569-7bc2-4e2f-bd1f-8e03a253c843"),
                            new Guid("d86cd606-f0ac-49ba-920d-8016073c567d"),
                            new Guid("2f8449ec-f6ba-4b5f-aa87-71a5cb79824c"),
                            new Guid("88dad7b7-a195-4fb0-a0ee-348f5d0c7450"),
                            new Guid("a6becbee-71cc-4441-8456-b7961e43de7e"),
                            new Guid("1feffeaa-3e80-471d-8152-0ab1f6f1d829"),
                            new Guid("6c0052d4-f68c-41fa-9760-b7cc64174ed2"),
                            new Guid("d4e160f5-7c81-4746-8e4f-26b917e644ad"),
                            new Guid("22ca2295-6b29-4aef-a857-1e573d215e61")
                        }
                    });
                    await context.AddBatchAsync(new Library.Models.Batch()
                    {
                        BatchId = Guid.NewGuid(),
                        BatchName = "1890-feb25-sdet",
                        BatchOccupancy = 12,
                        BatchSkill = "SDET",
                        StartDate = new DateTime(2017, 2, 25),
                        EndDate = new DateTime(2017, 5, 10),
                        State = "FL",
                        UserIds = new List<Guid>
                        {
                            new Guid("a48ad51e-7e0d-4d9d-bf1f-f4ec659b2d09"),
                            new Guid("c7cae577-3860-4ac5-b775-4ac446e69807"),
                            new Guid("67c7d90a-5114-459f-903c-7bd5a376fe20"),
                            new Guid("2473d113-dba5-4f1f-b059-de5f13c93f09"),
                            new Guid("fe07a3af-c69b-4d5e-ad25-e33285c07957"),
                            new Guid("2dff4f9d-5e4a-4d47-b0ac-8684d575a76e"),
                            new Guid("5de4d23f-bad3-41ce-8836-f900db95d7a7"),
                            new Guid("3d0ce10a-5807-459a-9936-c1e30dd73f05"),
                            new Guid("7e2435e3-b36d-4a75-8a40-94c09e811a3d"),
                            new Guid("8a84a471-d0f0-4556-b49c-dd2fc1f9bdbe"),
                            new Guid("f6b3c4ca-9426-41b1-a9ba-69f64a09708d"),
                            new Guid("b8e7b501-b7d6-45e5-89ef-7bb9280d934f")
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
}