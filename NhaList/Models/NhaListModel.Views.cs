//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(NhaList.Models.NhaListEntities),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySetsaba0dfe9966b9fcb9a0e0781fe8cfc699a28fcdcd8b253f48e2f34004ddad956))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework Power Tools", "0.9.0.0")]
    internal sealed class ViewsForBaseEntitySetsaba0dfe9966b9fcb9a0e0781fe8cfc699a28fcdcd8b253f48e2f34004ddad956 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "aba0dfe9966b9fcb9a0e0781fe8cfc699a28fcdcd8b253f48e2f34004ddad956"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "NhaListModelStoreContainer.GeoSearch")
            {
                return GetView0();
            }

            if (extentName == "NhaListEntities.GeoSearch")
            {
                return GetView1();
            }

            if (extentName == "NhaListModelStoreContainer.Post")
            {
                return GetView2();
            }

            if (extentName == "NhaListEntities.Post")
            {
                return GetView3();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for NhaListModelStoreContainer.GeoSearch.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing GeoSearch
        [NhaListModel.Store.GeoSearch](T1.GeoSearch_Id, T1.GeoSearch_ApproximateAddress, T1.GeoSearch_GoogleResponse, T1.GeoSearch_CreatedOn)
    FROM (
        SELECT 
            T.Id AS GeoSearch_Id, 
            T.ApproximateAddress AS GeoSearch_ApproximateAddress, 
            T.GoogleResponse AS GeoSearch_GoogleResponse, 
            T.CreatedOn AS GeoSearch_CreatedOn, 
            True AS _from0
        FROM NhaListEntities.GeoSearch AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for NhaListEntities.GeoSearch.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing GeoSearch
        [NhaListModel.GeoSearch](T1.GeoSearch_Id, T1.GeoSearch_ApproximateAddress, T1.GeoSearch_GoogleResponse, T1.GeoSearch_CreatedOn)
    FROM (
        SELECT 
            T.Id AS GeoSearch_Id, 
            T.ApproximateAddress AS GeoSearch_ApproximateAddress, 
            T.GoogleResponse AS GeoSearch_GoogleResponse, 
            T.CreatedOn AS GeoSearch_CreatedOn, 
            True AS _from0
        FROM NhaListModelStoreContainer.GeoSearch AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for NhaListModelStoreContainer.Post.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Post
        [NhaListModel.Store.Post](T1.Post_Id, T1.Post_Phone, T1.Post_Email, T1.Post_Text, T1.Post_ApproximateAddress, T1.Post_FormattedAddress, T1.Post_Latitude, T1.Post_Longtitude, T1.Post_CreatedOn)
    FROM (
        SELECT 
            T.Id AS Post_Id, 
            T.Phone AS Post_Phone, 
            T.Email AS Post_Email, 
            T.Text AS Post_Text, 
            T.ApproximateAddress AS Post_ApproximateAddress, 
            T.FormattedAddress AS Post_FormattedAddress, 
            T.Latitude AS Post_Latitude, 
            T.Longtitude AS Post_Longtitude, 
            T.CreatedOn AS Post_CreatedOn, 
            True AS _from0
        FROM NhaListEntities.Post AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for NhaListEntities.Post.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Post
        [NhaListModel.Post](T1.Post_Id, T1.Post_Phone, T1.Post_Email, T1.Post_Text, T1.Post_ApproximateAddress, T1.Post_FormattedAddress, T1.Post_Latitude, T1.Post_Longtitude, T1.Post_CreatedOn)
    FROM (
        SELECT 
            T.Id AS Post_Id, 
            T.Phone AS Post_Phone, 
            T.Email AS Post_Email, 
            T.Text AS Post_Text, 
            T.ApproximateAddress AS Post_ApproximateAddress, 
            T.FormattedAddress AS Post_FormattedAddress, 
            T.Latitude AS Post_Latitude, 
            T.Longtitude AS Post_Longtitude, 
            T.CreatedOn AS Post_CreatedOn, 
            True AS _from0
        FROM NhaListModelStoreContainer.Post AS T
    ) AS T1");
        }
    }
}
