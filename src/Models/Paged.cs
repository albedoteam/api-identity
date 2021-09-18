﻿namespace Identity.Api.Models
{
    using System.Collections.Generic;
    using AlbedoTeam.Identity.Contracts.Common;

    public class Paged<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RecordsInPage { get; set; }
        public int TotalPages { get; set; }
        public string FilterBy { get; set; }
        public string OrderBy { get; set; }
        public Sorting Sorting { get; set; }
        public List<T> Items { get; set; }
    }
}