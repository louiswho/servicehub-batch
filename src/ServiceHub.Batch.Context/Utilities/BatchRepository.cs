using System;
using MongoDB.Driver;
using ServiceHub.Batch.Library;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    public class BatchRepository : IUtility
    {
        private readonly IMongoCollection<Context.Models.Batch> _batches;

        public BatchRepository(IMongoCollection<Context.Models.Batch> batches)
        {
            _batches = batches;
        }

        /// <summary>
        /// Adds a batch
        /// </summary>
        /// <param name="batch">Batch Model</param>
        /// <returns></returns>
        public async Task AddBatchAsync(Library.Models.Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            await _batches.InsertOneAsync(ModelMapper.ToContextBatchModel(batch));
        }

        /// <summary>
        /// Deletes a batch from the data source, if they exist.
        /// </summary>
        /// <param name="id">Unique Batch identifier</param>
        /// <returns></returns>
        public async Task DeleteBatchAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var filter = Builders<Models.Batch>.Filter.Eq(x => x.BatchId, id);
            await _batches.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Gets all the batches
        /// </summary>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetAllBatchesAsync()
        {
            if (_batches == null)
            {
                throw new ArgumentNullException(nameof(_batches));
            }

            return ModelMapper.ToLibraryList(await _batches.AsQueryable().ToListAsync());
        }

        /// <summary>
        /// Updates a batch
        /// </summary>
        /// <param name="batch">Batch Model</param>
        /// <returns></returns>
        public async Task UpdateBatchAsync(Library.Models.Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            var filter = Builders<Models.Batch>.Filter.Eq(x => x.BatchId, batch.BatchId);
            var update = Builders<Models.Batch>.Update.Set(x => x.State, batch.State);
            await _batches.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// Gets all Batches with the same skill
        /// </summary>
        /// <param name ="skill">Batch Skill</param>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetBatchesBySkillAsync(string skill)
        {
            var skillTask = await _batches.FindAsync(x => x.BatchSkill == skill);
            var skillList = await skillTask.ToListAsync();
            return ModelMapper.ToLibraryList(skillList);
        }

        /// <summary>
        /// Gets all Batches in the same location
        /// </summary> 
        /// <param name="city">Batch City Name</param>
        /// <param name="state">Batch State Name</param>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetBatchesByLocationAsync(string state)
        {
            var stateTask = await _batches.FindAsync(x => x.State == state);
            var stateList = await stateTask.ToListAsync();
            return ModelMapper.ToLibraryList(stateList);
        }
    }
}
