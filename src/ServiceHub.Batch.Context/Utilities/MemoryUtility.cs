﻿using ServiceHub.Batch.Library;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    public class MemoryUtility : IUtility
    {
        /// <value>Create the memList List for use with CRUD functions</value>
        private static List<Models.Batch> memList = new List<Models.Batch>();

        /// <summary>
        /// Gets all the batches from the list
        /// </summary>
        /// <returns>A list of all of the batches</returns>
        public async Task<List<Library.Models.Batch>> GetAllBatchesAsync()
        {
            return await Task.FromResult(ModelMapper.ToLibraryList(memList));
        }
        /// <summary>
        /// Adds a batch to the batch list
        /// </summary>
        /// <param name="batch">Batch object</param>
        public async Task AddBatchAsync(Library.Models.Batch batch)
        {
            memList.Add(ModelMapper.ToContextBatchModel(batch));
        }
        /// <summary>
        /// Modifies the specified batch in the list with new information
        /// </summary>
        /// <param name="batch">Batch object</param>
        public async Task UpdateBatchAsync(Library.Models.Batch batch)
        {
            int index = memList.FindIndex(b => b.BatchId == batch.BatchId);
            if (index >= 0)
                memList[index] = ModelMapper.ToContextBatchModel(batch);
        }
        /// <summary>
        /// Deletes a batch from the list
        /// </summary>
        /// <param name="id">Batch ID</param>
        public async Task DeleteBatchAsync(Guid id)
        {
            memList.Remove(memList.Find(x => x.BatchId == id));
        }
        /// <summary>
        /// Returns a list of all the batches that match the specified skill
        /// </summary>
        /// <param name="skill">Batch skill</param>
        /// <returns>List of batches with the same skill</returns>
        public async Task<List<Library.Models.Batch>> GetBatchesBySkillAsync(string skill)
        {
            return await Task.FromResult(ModelMapper.ToLibraryList(memList.FindAll(x => x.BatchSkill == skill)));
        }
        /// <summary>
        /// Gets a list of all of the batches that match the specified city and state
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetBatchesByLocationAsync(string state)
        {
            return await Task.FromResult(ModelMapper.ToLibraryList(memList.FindAll(x => x.State == state)));
        }
    }
}