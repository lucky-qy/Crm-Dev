using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeAspNetCoreApp2.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DevExtremeAspNetCoreApp2.Controllers
{

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        public DataContext _context { get; set; }
        public SampleDataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            /// return DataSourceLoader.Load(SampleData.Orders, loadOptions);  
            var emoloyees = _context.SYS_Employees.ToList();
            return DataSourceLoader.Load(emoloyees, loadOptions);


        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(long key)
        {
            var employee = await _context.SYS_Employees.FindAsync(key);
            if (employee != null)
            {
                _context.SYS_Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return StatusCode(409, "��ǰ��Ա��Ϣ������");
            }

            //var f4735 = await _osscrmClient.GetFormmain4735(key);
            //if (f4735.finishedflag > 0)
            //{
            //    return StatusCode(409, "�ú�ͬ������Ϣ���������޷�ɾ��");
            //}
            // await _osscrmClient.DeleteFormmain4735(key);

        }
       
        
        
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(long key, string values)
        { 
            var employeeData = await _context.SYS_Employees.FindAsync(key); 
            JsonConvert.PopulateObject(values,employeeData); 
            await _context.SaveChangesAsync(); 
            return Ok();
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var employee = JsonConvert.DeserializeObject<SYS_Employees>(values); 
            _context.SYS_Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(); 
        }

    }
}