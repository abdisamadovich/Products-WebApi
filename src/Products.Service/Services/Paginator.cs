﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Products.DataAccess.Utils;
using Products.Service.Interfaces;

namespace Products.Service.Services;

public class Paginator : IPaginator
{
    private readonly IHttpContextAccessor _accessor;

    public Paginator(IHttpContextAccessor httpContextAccessor)
    {
        this._accessor = httpContextAccessor;
    }
    public void Paginate(long ItemsCount, PaginationParams @params)
    {
        PaginationMetaData paginationMetaData = new PaginationMetaData();
        paginationMetaData.CurrentPage = @params.PageNumber;
        paginationMetaData.TotalItems = (int)ItemsCount;
        paginationMetaData.PageSize = @params.PageSize;

        paginationMetaData.TotalPages = (int)Math.Ceiling((double)ItemsCount / @params.PageSize);
        paginationMetaData.HasPrevious = paginationMetaData.CurrentPage > 1;
        paginationMetaData.HasNext = paginationMetaData.CurrentPage < paginationMetaData.TotalPages;

        string jsonContent = JsonConvert.SerializeObject(paginationMetaData);
        _accessor.HttpContext!.Response.Headers.Add("X-Pagination", jsonContent);
    }
}
