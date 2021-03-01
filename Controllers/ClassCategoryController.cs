///TESTING PURPOSES

//using APIACMS.Repository;
//using ACMS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace APIACMS.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class ClassCategoryController : ControllerBase
//    {
//        private IClassCategoryRepo _classCategory;
//        public ClassCategoryController(IClassCategoryRepo classCategory)
//        {
//            _classCategory = classCategory;
//        }

//        [HttpPost]
//        public IActionResult Create([FromBody] ClassCategory classCategory)
//        {
//            var result = _classCategory.Create(classCategory);

//            return Ok(result);

//        }

//        [HttpGet]
//        public IActionResult GetClassCategory()
//        {
//            var result = _classCategory.FindAll();

//            return Ok(result);
//        }

//        [HttpDelete]
//        public IActionResult DeleteClassCategory([FromBody] ClassCategory classCategory)
//        {
//            var result = _classCategory.Delete(classCategory);

//            return Ok(result);

//        }

//        [HttpPut]
//        public IActionResult UpdateClassCategory([FromBody] ClassCategory classCategory)
//        {
//            var result = _classCategory.Update(classCategory);

//            return Ok(result);

//        }

//    }
//}
