using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ServiceHub.Batch.Context.Models
{
    /// <summary>
    /// Batch model for repository
    /// Contains all information describing any one batch.
    /// </summary>
    /// <remarks>
    /// A batch refers to a training period for Revature associates. Model includes following information:
    /// unique batch id, start/end date, technology stack, location, number of associates and list of associates.
    /// </remarks>
    public class Batch
    {
        /// <value> Unique batch id </value>
        [BsonId]
        public Guid BatchId { get; set; }
        /// <value> Start date of training </value>
        public DateTime? StartDate { get; set; }
        /// <value> Expected training end date </value>
        public DateTime? EndDate { get; set; }
        /// <value> Specific name of batch </value>
        public string BatchName { get; set; }
        /// <value> Total number of people in batch </value>
        public int? BatchOccupancy { get; set; }
        /// <value> Batch technology stack </value>
        public string BatchSkill { get; set; }
        /// <value> State that contains batch </value>
        public string State { get; set; }
        /// <value> List of associate ids in batch </value>
        public List<Guid> UserIds { get; set; }
    }
}