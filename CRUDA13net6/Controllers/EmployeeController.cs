using CRUDA13net6.DBO;
using CRUDA13net6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUDA13net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _environment;
        private readonly CardsDbContext cardsDbContext;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment environment, CardsDbContext cardsDbContext)
        {
            _configuration = configuration;
            _environment = environment;
            this.cardsDbContext = cardsDbContext;
        }

        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"SELECT EmployeeId, EmployeeName,Department,convert(varchar(10),DateOfJoining,120) as DateOfJoining,PhotoFileName FROM dbo.Employees";//SELECT PaymenyDetailID,CardOwnerName,CardNumber,ExpirationDate,SecurityCode FROM dbo.paymentDetails

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
        //    return new JsonResult(table);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cards = await cardsDbContext.Employees.ToListAsync();
            return Ok(cards);
        }


        [HttpPost]
        public JsonResult Post(Employee Dep)
        {
            string query = @"insert into dbo.Employees(EmployeeName,Department,DateOfJoining,PhotoFileName) values(@EmployeeName,@Department,@DateOfJoining,@PhotoFileName)";//SELECT PaymenyDetailID,CardOwnerName,CardNumber,ExpirationDate,SecurityCode FROM dbo.paymentDetails

            DataTable table = new DataTable();
            string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", Dep.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", Dep.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", Dep.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", Dep.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Employee Dep)
        {
            string query = @"update dbo.Employees set EmployeeName = @EmployeeName,Department = @Department,DateOfJoining = @DateOfJoining,PhotoFileName = @PhotoFileName where EmployeeId = @EmployeeId";

            DataTable table = new DataTable();
            string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", Dep.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName", Dep.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", Dep.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", Dep.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", Dep.PhotoFileName);
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
            string query = @"delete from  dbo.Employees  where EmployeeId = @EmployeeId";

            DataTable table = new DataTable();
            string sqlDataSrc = _configuration.GetConnectionString("CardsDbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSrc))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }



        //photos

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var phsycalPath = _environment.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(phsycalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.jpg");
            }
        }
    }
}
