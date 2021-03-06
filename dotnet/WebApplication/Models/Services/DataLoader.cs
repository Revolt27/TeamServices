﻿using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Repositories;

namespace WebApplication.Models.Services
{
    public class DataLoader : IDataLoader
    {
        #region Fields

        private readonly IConfiguration _configuration;
        private IRepository _repository;

        private readonly Data _data = new Data();

        #endregion

        #region Constructors

        public DataLoader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<Data> GetDataAsync()
        {
            await LoadDataAsync();
            return _data;
        }

        public async Task<Data> GetDataAsync(IRepository repository)
        {
            _repository = repository;

            await LoadDataAsync();
            return _data;
        }

        public async Task LoadDataAsync()
        {
            var queries = _data.GetQueries(_configuration);

            _data.Files = _repository.GetData<Models.DataBase.File>(queries.Where(q
                => q.Name == "Files").FirstOrDefault().Query).Result.ToList();

            _data.Dictionary = (await _repository.GetData<DataBase.Dictionary>(queries.Where(q
                => q.Name == "Dictionary").FirstOrDefault().Query)).ToList();

            _data.Quotes = (await _repository.GetData<DataBase.Quote>(queries.Where(q
                => q.Name == "Quotes").FirstOrDefault().Query)).ToList();

            _data.Links = (await _repository.GetData<DataBase.Link>(queries.Where(q
                => q.Name == "Links").FirstOrDefault().Query)).ToList();

            _data.Projects = (await _repository.GetData<DataBase.Project>(queries.Where(q
                => q.Name == "Projects").FirstOrDefault().Query)).ToList();

            _data.Staff = (await _repository.GetData<DataBase.Staff>(queries.Where(q
                => q.Name == "Staff").FirstOrDefault().Query)).ToList();

            _data.WorkReports = (await _repository.GetData<DataBase.WorkReport>(queries.Where(q
                => q.Name == "WorkReports").FirstOrDefault().Query)).ToList();
        }

        #endregion
    }
}
