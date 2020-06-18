using EmployeeService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIDbConnect;

namespace WebAPIDemo.Controllers
{
    public class employeesController : ApiController
    {
        //[BasicAuthentication]
       // [Authorize]
        public HttpResponseMessage GetEmployee()
        {
            EmpEntities entities = new EmpEntities();
            var employees = entities.employees.ToList();
            var msg = Request.CreateResponse(HttpStatusCode.Accepted, employees);
            return msg;
        }


       // [Authorize]
        [Route("api/employees/GetFirstEmp")]
        public employee Get()
        {
            EmpEntities entities = new EmpEntities();
            var employees = entities.employees.FirstOrDefault();
            var msg = Request.CreateResponse(HttpStatusCode.Accepted, employees);
            return employees;
        }


        public employee GetEmployeeById(int id)
        {
            EmpEntities entities = new EmpEntities();
            return entities.employees.FirstOrDefault(x => x.id == id);
        }

        [HttpPost]
        public HttpResponseMessage PostEmployee([FromBody]employee emp)
        {
            try
            {
                using (EmpEntities entities = new EmpEntities())
                {
                    entities.employees.Add(emp);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, emp);
                    message.Headers.Location = new Uri(Request.RequestUri + emp.id.ToString());
                    return message;
                }
            }
            catch (Exception ex)

            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                using (EmpEntities entities = new EmpEntities())
                {
                    var employee = entities.employees.FirstOrDefault(x => x.id == id);
                    if (employee != null)
                    {
                        entities.employees.Remove(employee);
                        entities.SaveChanges();
                        var message = Request.CreateResponse(HttpStatusCode.OK,"Deleteed Successfully!!");
                        return message;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Emp not found :"+id);
                    }
                }
            }
            catch (Exception ex)

            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage EditEmployee(int id,[FromBody]employee emp)
        {
            try
            {
                using (EmpEntities entities = new EmpEntities())
                {
                    var eachEmployee = entities.employees.FirstOrDefault(x => x.id == id);
                    if (eachEmployee != null)
                    {
                        eachEmployee.id = emp.id;
                        eachEmployee.ename = emp.ename;
                        eachEmployee.dept_id = emp.dept_id;
                        entities.SaveChanges();
                        var message = Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully!!");
                        return message;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Emp not found :" + id);
                    }
                }
            }
            catch (Exception ex)

            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //private EmpEntities db = new EmpEntities();

        //// GET: api/employees
        //public IQueryable<employee> Getemployees()
        //{
        //    return db.employees;
        //}

        //// GET: api/employees/5
        //[ResponseType(typeof(employee))]
        //public IHttpActionResult Getemployee(int id)
        //{
        //    employee employee = db.employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employee);
        //}

        //// PUT: api/employees/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putemployee(int id, employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != employee.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!employeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/employees
        //[ResponseType(typeof(employee))]
        //public IHttpActionResult Postemployee(employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.employees.Add(employee);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (employeeExists(employee.id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = employee.id }, employee);
        //}

        //// DELETE: api/employees/5
        //[ResponseType(typeof(employee))]
        //public IHttpActionResult Deleteemployee(int id)
        //{
        //    employee employee = db.employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    db.employees.Remove(employee);
        //    db.SaveChanges();

        //    return Ok(employee);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool employeeExists(int id)
        //{
        //    return db.employees.Count(e => e.id == id) > 0;
        //}
    }
}