using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Library
{
    public static class ModelMapper
    {
        /// <summary>
        /// Converts a list of context Batch models to a list of libary Batch models
        /// </summary>
        /// <param name="ctxList">Context Batch model list</param>
        /// <returns>Library Batch model list</returns>
        public static List<Models.Batch> ToLibraryList(List<Context.Models.Batch> ctxList)
        {
            List<Models.Batch> libList = new List<Models.Batch>();
            foreach (var batch in ctxList)
            {
                Models.Batch libBatchModel = ToLibraryBatchModel(batch);
                if (libBatchModel == null) { return new List<Models.Batch>(); }
                libList.Add(libBatchModel);
            }

            return libList;
        }

        /// <summary>
        /// Converts Context batch model into Library batch model
        /// </summary>
        /// <param name="batchContext">Batch context model</param>
        /// <returns>Batch library model</returns>
        public static Models.Batch ToLibraryBatchModel(Context.Models.Batch batchContext)
        {
            Models.Batch batchLibrary = new Models.Batch();
            batchLibrary.BatchId = batchContext.BatchId;
            batchLibrary.StartDate = batchContext.StartDate;
            batchLibrary.EndDate = batchContext.EndDate;
            batchLibrary.BatchName = batchContext.BatchName;
            batchLibrary.BatchOccupancy = batchContext.BatchOccupancy;
            batchLibrary.BatchSkill = batchContext.BatchSkill;
            batchLibrary.UserIds = batchContext.UserIds;
            batchLibrary.State = batchContext.State;

            if (!batchLibrary.Validate()) { return null; }
            return batchLibrary;
        }

        /// <summary>
        /// Converts Library batch model into Context batch model
        /// </summary>
        /// <param name="batchLibrary">Batch library model</param>
        /// <returns>Batch context model</returns>
        public static Context.Models.Batch ToContextBatchModel(Models.Batch batchLibrary)
        {
            
            if (!batchLibrary.Validate()) { return null; }

            Context.Models.Batch batchContext = new Context.Models.Batch();
            batchContext.BatchId = batchLibrary.BatchId;
            batchContext.StartDate = batchLibrary.StartDate;
            batchContext.EndDate = batchLibrary.EndDate;
            batchContext.BatchName = batchLibrary.BatchName;
            batchContext.BatchOccupancy = batchLibrary.BatchOccupancy;
            batchContext.BatchSkill = batchLibrary.BatchSkill;
            batchContext.UserIds = batchLibrary.UserIds;
            batchContext.State = batchLibrary.State;

            return batchContext;
        }
    }
}