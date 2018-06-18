using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    public class Storage
    {
        /// <summary>
        /// Depndency Injection for classes implementing IUtility
        /// </summary>
        /// <remarks>
        /// Example usage: 
        ///     Storage storage = new Storage(new TestUtility);
        ///     List<Models.Batch> batchList = storage.GetAllBatches();
        /// </remarks>
        /// 
        private IUtility utility;

        /// <value> Inject IUtility class </value>
        public Storage(IUtility utility)
        {
            this.utility = utility;
        }

        /// <value> Get all batches from injected IUtility class repo </value>
        public async Task<List<Library.Models.Batch>> GetAllBatchesAsync()
        {
            return await utility.GetAllBatchesAsync();
        }

        /// <value> Add batch to injected IUtility class repo </value>
        public async Task AddBatchAsync(Library.Models.Batch batch)
        {
            await utility.AddBatchAsync(batch);
        }

        /// <value> Update batch in injected IUtility class repo </value>
        public async Task UpdateBatchAsync(Library.Models.Batch batch)
        {
            await utility.UpdateBatchAsync(batch);
        }

        /// <value> Delete batch from injected IUtility class repo </value>
        public async Task DeleteBatchAsync(Guid id)
        {
            await utility.DeleteBatchAsync(id);
        }

        public async Task<List<Library.Models.Batch>> GetBatchesBySkillAsync(string skill)
        {
            return await utility.GetBatchesBySkillAsync(skill);
        }
        public async Task<List<Library.Models.Batch>> GetBatchesByLocationAsync(string state)
        {
            return await utility.GetBatchesByLocationAsync(state);
        }
    }
}