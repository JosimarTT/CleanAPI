using CleanAPI.Core.QueryFilters;
using System;

namespace CleanAPI.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}