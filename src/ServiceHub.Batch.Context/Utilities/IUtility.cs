using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    /// <summary>
    /// Basic CRUD interface for Batch models
    /// All storage implementations must inherit IUtility
    /// </summary>
    public interface IUtility
    {
        /// <summary>
        /// Returns a list of all the batches that match the specified skill
        /// </summary>
        /// <param name="skill">Batch skill</param>
        /// <returns>List of batches with the same skill</returns>
        Task<List<Library.Models.Batch>> GetBatchesBySkillAsync(string skill);
        /// <summary>
        /// Gets a list of all of the batches that match the specified city and state
        /// </summary>
        /// <param name="state">State</param>
        /// <returns></returns>
        Task<List<Library.Models.Batch>> GetBatchesByLocationAsync(string state);
        /// <summary>
        /// Gets all the batches from the list
        /// </summary>
        /// <returns>A list of all of the batches</returns>
        Task<List<Library.Models.Batch>> GetAllBatchesAsync();
        /// <summary>
        /// Adds a batch to the batch list
        /// </summary>
        /// <param name="batch">Batch object</param>
        Task AddBatchAsync(Library.Models.Batch batch);
        /// <summary>
        /// Modifies the specified batch in the list with new information
        /// </summary>
        /// <param name="batch">Batch object</param>
        Task UpdateBatchAsync(Library.Models.Batch batch);
        /// <summary>
        /// Deletes a batch from the list
        /// </summary>
        /// <param name="id">Batch ID</param>
        Task DeleteBatchAsync(Guid id);
    }
}