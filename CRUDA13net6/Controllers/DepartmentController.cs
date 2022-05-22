using Manager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model.CardC;
using Model.Context;
using Newtonsoft.Json;
using System.Data;

namespace CRUDA13net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly ITAPIManager iTAPIManager;
        public DepartmentController(IConfiguration configuration, ITAPIManager _iTAPIManager)
        {
            _configuration = configuration;
            iTAPIManager = _iTAPIManager;
        }

        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"select DepartmentId , DepartmentName from dbo.Departments";//SELECT PaymenyDetailID,CardOwnerName,CardNumber,ExpirationDate,SecurityCode FROM dbo.paymentDetails

        //    DataTable table = new DataTable();
        //    string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    //var table =  cardsDbContext.Departments.ToList();
        //    return new JsonResult(table);
        //}

       // All data
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject(await iTAPIManager.GetAllDepartments()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartmentByID(int id)
        {
            return Ok(JsonConvert.SerializeObject(await iTAPIManager.GetDepartmentByID(id)));
        }


        [HttpPost]
        public async Task<string> Post(Department Dep)
        {
            //string query = @"insert into dbo.Departments values(@DepartmentName)";//SELECT PaymenyDetailID,CardOwnerName,CardNumber,ExpirationDate,SecurityCode FROM dbo.paymentDetails

            //DataTable table = new DataTable();
            //string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myCommand.Parameters.AddWithValue("@DepartmentName", Dep.DepartmentName);
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            return await iTAPIManager.createDepartment(Dep);
        }


        [HttpPut]
        public JsonResult Put(Department Dep)
        {
            string query = @"update dbo.Departments set DepartmentName = @DepartmentName where DepartmentId = @DepartmentId";//SELECT PaymenyDetailID,CardOwnerName,CardNumber,ExpirationDate,SecurityCode FROM dbo.paymentDetails

            DataTable table = new DataTable();
            string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", Dep.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", Dep.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{Id}")]
        public JsonResult Delete(int Id)
        {
            string query = @"delete from  dbo.Departments  where DepartmentId = @DepartmentId";//SELECT PaymenyDetailID,CardOwnerName,CardNumber,ExpirationDate,SecurityCode FROM dbo.paymentDetails

            DataTable table = new DataTable();
            string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
