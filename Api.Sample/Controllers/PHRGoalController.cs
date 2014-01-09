using System;
using System.Collections.Generic;
using Api.Sample.Controllers.Base;
using Api.Sample.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;

namespace Api.Sample.Controllers
{
    [RoutePrefix("records/{recordId}/goals")]
    public class PHRGoalController : BaseApiController
    {
        #region GET

        /// <summary>
        /// Retrieve Goals 
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="TrackerType"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [GET("")]
        public IEnumerable<PHRGoal> Get(string uuid, DateTime startDate, DateTime endDate, int TrackerType, bool status)
        {
            return new[] { new PHRGoal() };
        }

        /// <summary>
        /// Retrieve Goals 
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [GET("")]
        public IEnumerable<PHRGoal> Get(string recordId)
        {
            return new[] {new PHRGoal() };
        }

        /// <summary>
        /// Get a specific Goal 
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [GET("{id}")]
        public PHRGoal Get(string recordId, string Id)
        {
            return new PHRGoal();
        }

        #endregion

        #region PUT

        /// <summary>
        /// Update a BMI goal
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="id"></param>
        /// <param name="goal"></param>
        [PUT("{id}")]
        public void Put(string recordId, string id, PHRGoal goal)
        {
         
        }

        #endregion

        #region POST

        /// <summary>
        /// Add a BMI goal
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        [POST("")]
        public PHRGoal AddGoal(string recordId, PHRGoal goal)
        {
            return new PHRGoal();
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Delete a BMI goal
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="id"></param>
        [DELETE("{id}")]
        public void DeleteGoal(int recordId, int id)
        {
        }

        #endregion
    }
}